string word;
Console.Write("Enter a word: ");
word = Console.ReadLine();

var includedFilesNames = new List<string>();

string folderPath = @"C:\AirMirData";
string[] filePaths = Directory.GetFiles(folderPath);

foreach (string filePath in filePaths)
{
    StreamReader sr = System.IO.File.OpenText(filePath);
    string contents = sr.ReadToEnd();

    if (contents.Contains(word))
    {
        sr.Close();
        includedFilesNames.Add(filePath);
    }
    else
        sr.Close();
}

if (includedFilesNames.Count > 0)
    includedFilesNames.ForEach(fileName => Console.WriteLine(fileName + "\n"));
else
    Console.WriteLine("File Not Found");

Console.ReadLine();
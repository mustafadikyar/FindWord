string word;
Console.Write("Enter a word: ");
word = Console.ReadLine();

var includedFilesNames = new List<string>();

string folderPath = @"C:\AirMirData";
string[] filePaths = Directory.GetFiles(folderPath);

int count = 0;

foreach (string filePath in filePaths)
{
    count++;
    Console.WriteLine($"{count} file has been readed.");


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
    includedFilesNames.ForEach(fileName => Console.WriteLine(fileName));
else
    Console.WriteLine("File Not Found");

Console.ReadLine();
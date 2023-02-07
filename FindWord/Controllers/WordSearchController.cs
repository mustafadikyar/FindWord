using Microsoft.AspNetCore.Mvc;

namespace FindWord.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WordSearchController : ControllerBase
{
    [HttpPost("/search-from-file")]
    public IActionResult SearchFromFile(List<IFormFile> files, string word)
    {
        var includedFilesNames = new List<string>();

        files.ForEach(file =>
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string contents = reader.ReadToEnd();

                if (contents.Contains(word))
                    includedFilesNames.Add(file.FileName);
            }
        });

        if (includedFilesNames.Count > 0)
            return Ok(includedFilesNames);

        return NotFound();
    }

    [HttpGet("/search-from-folder")]
    public IActionResult SearchFromFolder(string word)
    {
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
            return Ok(includedFilesNames);

        return NotFound();
    }
}
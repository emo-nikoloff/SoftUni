/*Write a program that traverses a given directory for all files with the given extension. Search through the first level of the directory only. Write information about each found file in a text
file named report.txt and it should be saved on the Desktop. The files should be grouped by their extension. Extensions should be ordered by the count of their files descending, then by name
alphabetically. Files under an extension should be ordered by their size. report.txt should be saved on the Desktop. Ensure the desktop path is always valid, regardless of the user.*/
using System.Text;

namespace _04._Directory_Traversal;

class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\Емо Николов\Desktop\Проекти\SoftUni\C#\3. Programming Advanced\Advanced";
        string reportFileName = @"..\..\..\Files\report.txt";

        string reportContent = TraverseDirectory(path);
        Console.WriteLine(reportContent);

        WriteReportToDesktop(reportContent, reportFileName);
    }

    public static string TraverseDirectory(string inputFolderPath)
    {
        DirectoryInfo directory = new(inputFolderPath);

        Dictionary<string, List<FileInfo>> extensions = new();

        foreach (FileInfo file in directory.GetFiles())
        {
            if (!extensions.ContainsKey(file.Extension))
            {
                extensions.Add(file.Extension, new());
            }
            extensions[file.Extension].Add(file);
        }

        StringBuilder content = new();

        foreach ((string extension, List<FileInfo> files) in extensions.OrderByDescending(e => e.Value.Count).ThenBy(e => e.Key))
        {
            content.AppendLine($"{extension}");
            foreach (FileInfo file in files.OrderByDescending(f => f.Length))
            {
                content.AppendLine($"--{file.Name} - {file.Length / 1024}kb");
            }
        }

        return content.ToString().TrimEnd();
    }

    public static void WriteReportToDesktop(string textContent, string reportFileName)
    {
        string filePath = Path.GetFullPath(reportFileName);
        using StreamWriter writer = new(filePath);
        writer.Write(textContent);
    }
}

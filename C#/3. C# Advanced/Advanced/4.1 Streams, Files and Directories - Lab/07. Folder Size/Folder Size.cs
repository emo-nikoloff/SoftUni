/*You are given a folder in the file system (e. g. TestFolder). Calculate the size of all files in the folder and its subfolders. The result should be written to another text (e. g. оutput.txt)
file in kilobytes.*/
namespace _07._Folder_Size;

class Program
{
    static void Main(string[] args)
    {
        string folderPath = @"..\..\..\Files\TestFolder";
        string outputPath = @"..\..\..\Files\output.txt";

        GetFolderSize(folderPath, outputPath);
    }

    public static void GetFolderSize(string folderPath, string outputFilePath)
    {
        DirectoryInfo directory = new DirectoryInfo(folderPath);
        double sum = 0;
        foreach (FileInfo file in directory.GetFiles())
        {
            sum += file.Length;
        }

        foreach (DirectoryInfo dir in directory.GetDirectories())
        {
            foreach (FileInfo file in dir.GetFiles())
            {
                sum += file.Length;
            }
        }

        double sumInKb = sum / 1024;

        File.WriteAllText(outputFilePath, $"{sumInKb} KB");
    }
}

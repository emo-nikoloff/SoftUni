/*Write a method, which copies a directory with files (without its subdirectories) to another directory. The input folder and the output folder should be given as parameters from the console.
If the output folder already exists, first delete it (together with all its content).*/
namespace _05._Copy_Directory;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @$"{Console.ReadLine()}";
        string outputPath = @$"{Console.ReadLine()}";

        CopyAllFiles(inputPath, outputPath);
    }

    public static void CopyAllFiles(string inputPath, string outputPath)
    {
        DirectoryInfo outputDirectory = new DirectoryInfo(outputPath);
        if (outputDirectory.Exists)
        {
            outputDirectory.Delete();
        }
        outputDirectory.Create();

        DirectoryInfo directory = new(inputPath);
        FileInfo[] files = directory.GetFiles();

        foreach (FileInfo file in files)
        {
            string destinationPath = Path.Combine(outputPath, file.Name);
            file.CopyTo(destinationPath);
        }
    }
}

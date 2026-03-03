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

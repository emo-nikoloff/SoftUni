namespace _02._Line_Numbers;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"..\..\..\Files\input.txt";
        string outputPath = @"..\..\..\Files\output.txt";

        RewriteFileWithLineNumbers(inputPath, outputPath);
    }

    public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
    {
        StreamReader reader = new(inputFilePath);
        using (reader)
        {
            int lineNumber = 0;
            string line = reader.ReadLine();

            StreamWriter writer = new(outputFilePath);
            using (writer)
            {
                while (line != null)
                {
                    writer.WriteLine($"{++lineNumber}. {line}");
                    line = reader.ReadLine();
                }
            }
        }
    }
}

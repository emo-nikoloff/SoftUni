/*Write a program that reads a text file (e. g. input.txt) and inserts line numbers in front of each of its lines. The result should be written to another text file (e. g. output.txt).
Use StreamReader and StreamWriter.*/
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

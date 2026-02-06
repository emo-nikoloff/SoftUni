namespace _02._Line_Numbers;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Users\Емо Николов\Desktop\Проекти\SoftUni\C#\3. Programming Advanced\Advanced\4.1 Streams, Files and Directories - Lab\02. Line Numbers\Files\input.txt";
        string outputPath = @"C:\Users\Емо Николов\Desktop\Проекти\SoftUni\C#\3. Programming Advanced\Advanced\4.1 Streams, Files and Directories - Lab\02. Line Numbers\Files\output.txt";

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

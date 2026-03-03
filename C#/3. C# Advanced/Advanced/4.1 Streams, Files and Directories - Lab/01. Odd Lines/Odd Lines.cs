namespace _01._Odd_Lines;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = @"..\..\..\Files\input.txt";
        string outputFilePath = @"..\..\..\Files\output.txt";
        ExtractOddLines(inputFilePath, outputFilePath);
    }
    public static void ExtractOddLines(string inputFilePath, string outputFilePath)
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
                    if (lineNumber % 2 != 0)
                    {
                        writer.WriteLine(line);
                    }
                    lineNumber++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}

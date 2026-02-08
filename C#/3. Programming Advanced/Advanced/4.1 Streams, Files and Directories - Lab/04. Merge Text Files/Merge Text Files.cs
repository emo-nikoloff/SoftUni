namespace _04._Merge_Text_Files;

class Program
{
    static void Main(string[] args)
    {
        string firstInputFilePath = @"..\..\..\Files\input1.txt";
        string secondInputFilePath = @"..\..\..\Files\input2.txt";
        string outputFilePath = @"..\..\..\Files\output.txt";

        MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
    }

    public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
    {
        using StreamReader firstFileReader = new(firstInputFilePath);
        using StreamReader secondFileReader = new(secondInputFilePath);
        using StreamWriter writer = new(outputFilePath);

        while (true)
        {
            string lineOne = firstFileReader.ReadLine();
            string lineTwo = secondFileReader.ReadLine();
            if (lineOne == null && lineTwo == null)
            {
                break;
            }
            if (lineOne != null)
            {
                writer.WriteLine(lineOne);
            }
            if (lineTwo != null)
            {
                writer.WriteLine(lineTwo);
            }
        }
    }
}

/*Write a program that reads a text file (e. g. text.txt) and inserts line numbers in front of each of its lines and count all the letters and punctuation marks. The result should be written to
another text file (e. g. output.txt). Use the static class File to read and write all the lines of the input and output files.*/
namespace _02._Line_Numbers;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = @"..\..\..\Files\text.txt";
        string outputFilePath = @"..\..\..\Files\output.txt";

        ProcessLines(inputFilePath, outputFilePath);
    }

    public static void ProcessLines(string inputFilePath, string outputFilePath)
    {
        using StreamReader reader = new(inputFilePath);
        using StreamWriter writer = new(outputFilePath);

        string line = string.Empty;

        int lineNumber = 1, lettersCount = 0, punctuationsCount = 0;

        while ((line = Console.ReadLine()) != null)
        {
            foreach (char letter in line)
            {
                if (char.IsLetter(letter))
                {
                    lettersCount++;
                }
                else if (char.IsPunctuation(letter))
                {
                    punctuationsCount++;
                }
            }

            writer.WriteLine($"Line {lineNumber}: {line} ({lettersCount})({punctuationsCount})");
        }
    }
}

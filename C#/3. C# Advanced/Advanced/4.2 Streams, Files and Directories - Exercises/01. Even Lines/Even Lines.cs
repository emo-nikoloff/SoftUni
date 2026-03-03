using System.Text;

namespace _01._Even_Lines;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = @"..\..\..\Files\text.txt";

        Console.WriteLine(ProcessLines(inputFilePath));
    }

    public static string ProcessLines(string inputFilePath)
    {
        StringBuilder result = new();
        char[] punctuation = { '-', ',', '.', '!', '?' };

        using StreamReader reader = new(inputFilePath);

        string line = string.Empty;
        int lineNumber = 0;
        while ((line = reader.ReadLine()) != null)
        {
            if (lineNumber % 2 == 0)
            {
                line = punctuation.Aggregate(line, (c1, c2) => c1.Replace(c2, '@'));
                List<string> lineParts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                lineParts.Reverse();
                lineParts.ForEach(t => result.Append($"{t} "));
                result.AppendLine();
            }
            lineNumber++;
        }

        return result.ToString().TrimEnd();
    }
}

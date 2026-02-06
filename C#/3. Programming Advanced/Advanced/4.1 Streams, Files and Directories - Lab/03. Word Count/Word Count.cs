namespace _03._Word_Count;

class Program
{
    static void Main(string[] args)
    {
        string wordPath = @"C:\Users\Емо Николов\Desktop\Проекти\SoftUni\C#\3. Programming Advanced\Advanced\4.1 Streams, Files and Directories - Lab\03. Word Count\Files\words.txt";
        string textPath = @"C:\Users\Емо Николов\Desktop\Проекти\SoftUni\C#\3. Programming Advanced\Advanced\4.1 Streams, Files and Directories - Lab\03. Word Count\Files\text.txt";
        string outputPath = @"C:\Users\Емо Николов\Desktop\Проекти\SoftUni\C#\3. Programming Advanced\Advanced\4.1 Streams, Files and Directories - Lab\03. Word Count\Files\output.txt";

        CalculateWordCounts(wordPath, textPath, outputPath);
    }

    public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
    {
        Dictionary<string, int> occurences = new();

        using (StreamReader wordsReader = new(wordsFilePath))
        {
            List<string> words = wordsReader.ReadToEnd().Split().ToList();
            foreach (string word in words)
            {
                if (!occurences.ContainsKey(word))
                {
                    occurences.Add(word, 0);
                }
            }

            using (StreamReader textReader = new(textFilePath))
            {
                while (!textReader.EndOfStream)
                {
                    char[] punctuationSymbols = { ' ', '.', ',', '-', '?', '!' };
                    foreach (string word in textReader.ReadLine().Split(punctuationSymbols))
                    {
                        if (words.Contains(word.ToLower()))
                        {
                            occurences[word.ToLower()]++;
                        }
                    }
                }

                using (StreamWriter writer = new(outputFilePath))
                {
                    foreach ((string word, int count) in occurences.OrderByDescending(x => x.Value))
                    {
                        Console.WriteLine($"{word} - {count}");
                    }
                }
            }
        }
    }
}

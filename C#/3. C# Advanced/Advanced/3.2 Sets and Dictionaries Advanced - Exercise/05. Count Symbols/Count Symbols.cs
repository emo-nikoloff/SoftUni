namespace _05._Count_Symbols;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Dictionary<char, int> occurences = new();
        for (int i = 0; i < input.Length; i++)
        {
            char character = input[i];
            if (!occurences.ContainsKey(character))
            {
                occurences.Add(character, 1);
                continue;
            }
            occurences[character]++;
        }

        foreach ((char character, int count) in occurences.OrderBy(c => c.Key))
        {
            Console.WriteLine($"{character}: {count} time/s");
        }
    }
}

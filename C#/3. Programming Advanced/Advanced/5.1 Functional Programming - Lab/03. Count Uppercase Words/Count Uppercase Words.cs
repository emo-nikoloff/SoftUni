namespace _03._Count_Uppercase_Words;

class Program
{
    static void Main(string[] args)
    {
        string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Predicate<string> check = x => char.IsUpper(x[0]);
        foreach (string word in words.Where(w => check(w)))
        {
            Console.WriteLine(word);
        }
    }
}

/*Create a program that reads a line of text from the console. Print all the words that start with an uppercase letter in the same order you've received them in the text.*/
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

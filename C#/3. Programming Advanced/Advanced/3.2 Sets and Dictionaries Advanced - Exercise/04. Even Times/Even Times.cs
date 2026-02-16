/*Create a program that prints a number from a collection, which appears an even number of times in it. On the first line, you will be given n – the count of integers you will receive. On the
next n lines, you will be receiving the numbers. It is guaranteed that only one of them appears an even number of times. Your task is to find that number and print it in the end.*/
namespace _04._Even_Times;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        Dictionary<int, int> occurences = new();
        for (int i = 1; i <= count; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (!occurences.ContainsKey(number))
            {
                occurences.Add(number, 1);
                continue;
            }
            occurences[number]++;
        }

        Console.WriteLine(occurences.Single(n => n.Value % 2 == 0).Key);
    }
}

/*Create a program that keeps all the unique chemical elements. On the first line, you will be given a number n - the count of input lines that you are going to receive. On the next n lines, you
will be receiving chemical compounds, separated by a single space. Your task is to print all the unique ones in ascending order:*/
namespace _03._Periodic_Table;

class Program
{
    static void Main(string[] args)
    {
        int inputs = int.Parse(Console.ReadLine());

        HashSet<string> elements = new();
        for (int i = 1; i <= inputs; i++)
        {
            string[] input = Console.ReadLine().Split();
            foreach (string element in input)
            {
                elements.Add(element);
            }
        }
        Console.WriteLine(string.Join(" ", elements.OrderBy(e => e)));
    }
}

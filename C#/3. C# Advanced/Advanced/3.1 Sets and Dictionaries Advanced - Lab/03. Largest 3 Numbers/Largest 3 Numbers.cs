/*Read a list of integers and print the largest 3 of them. If there are less than 3, print all of them.*/
namespace _03._Largest_3_Numbers;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] sorted = numbers.OrderByDescending(n => n).Take(3).ToArray();
        Console.WriteLine($"{string.Join(" ", sorted)}");
    }
}

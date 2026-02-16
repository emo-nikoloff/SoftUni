/*Create a program that reads one line of integers separated by ", ". Then prints the even numbers of that sequence sorted in increasing order.*/
namespace _01._Sort_Even_Numbers;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).Where(n => n % 2 == 0).OrderBy(n => n).ToArray();
        Console.WriteLine(string.Join(", ", numbers));
    }
}

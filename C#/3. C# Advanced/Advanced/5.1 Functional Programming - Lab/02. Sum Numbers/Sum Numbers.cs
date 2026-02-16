/*Create a program that reads a line of integers separated by ", ". Print on two lines the count of numbers and their sum.*/
namespace _02._Sum_Numbers;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        Console.WriteLine(numbers.Length);
        Console.WriteLine(numbers.Sum());
    }
}

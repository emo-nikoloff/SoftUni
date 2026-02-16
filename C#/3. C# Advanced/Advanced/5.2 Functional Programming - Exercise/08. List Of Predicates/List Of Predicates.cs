/*Find all numbers in the range 1…N that are divisible by the numbers of a given sequence. On the first line, you will be given an integer N – which is the end of the range. On the second line,
you will be given a sequence of integers which are the dividers. Use predicates / functions.*/
namespace _08._List_Of_Predicates;

class Program
{
    static void Main(string[] args)
    {
        int end = int.Parse(Console.ReadLine());
        int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Func<int[], int, bool> isDivisible = (dividers, number) => dividers.All(n => number % n == 0);

        List<int> numbers = new();
        for (int i = 1; i <= end; i++)
        {
            numbers.Add(i);
        }
        Console.WriteLine(string.Join(' ', numbers.Where(n => isDivisible(dividers, n))));
    }
}

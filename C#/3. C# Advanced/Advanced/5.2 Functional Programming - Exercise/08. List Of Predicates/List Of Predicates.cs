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

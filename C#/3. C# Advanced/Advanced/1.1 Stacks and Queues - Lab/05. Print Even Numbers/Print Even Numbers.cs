namespace _05._Print_Even_Numbers;

class Program
{
    static void Main(string[] args)
    {
        int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Queue<int> queue = new(array.Where(x => x % 2 == 0));
        Console.WriteLine(string.Join(", ", queue));
    }
}

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

namespace _06._Record_Unique_Names;

class Program
{
    static void Main(string[] args)
    {
        int people = int.Parse(Console.ReadLine());
        HashSet<string> uniqueNames = new();
        for (int i = 1; i <= people; i++)
        {
            string name = Console.ReadLine();
            uniqueNames.Add(name);
        }

        foreach (string name in uniqueNames)
        {
            Console.WriteLine(name);
        }
    }
}

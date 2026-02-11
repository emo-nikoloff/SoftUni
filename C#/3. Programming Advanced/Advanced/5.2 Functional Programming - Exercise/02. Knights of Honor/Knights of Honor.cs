namespace _02._Knights_of_Honor;

class Program
{
    static void Main(string[] args)
    {
        Action<string> print = name => Console.WriteLine($"Sir {name}");
        string[] input = Console.ReadLine().Split();
        foreach (string name in input)
        {
            print(name);
        }
    }
}

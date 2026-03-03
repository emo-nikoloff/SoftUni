namespace _01._Action_Print;

class Program
{
    static void Main(string[] args)
    {
        Action<string> print = name => Console.WriteLine(name);
        string[] input = Console.ReadLine().Split();
        foreach (string name in input)
        {
            print(name);
        }
    }
}

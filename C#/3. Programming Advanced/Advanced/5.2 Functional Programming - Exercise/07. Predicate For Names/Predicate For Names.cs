namespace _07._Predicate_For_Names;

class Program
{
    static void Main(string[] args)
    {
        int nameLength = int.Parse(Console.ReadLine());
        Predicate<string> predicate = name => name.Length <= nameLength;
        List<string> names = Console.ReadLine().Split().Where(name => predicate(name)).ToList();
        names.ForEach(Console.WriteLine);
    }
}

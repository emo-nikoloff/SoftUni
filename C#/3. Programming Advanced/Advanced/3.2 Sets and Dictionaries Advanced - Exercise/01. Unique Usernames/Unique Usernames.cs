namespace _01._Unique_Usernames;

class Program
{
    static void Main(string[] args)
    {
        int peopleCount = int.Parse(Console.ReadLine());
        HashSet<string> people = new();

        for (int i = 1; i <= peopleCount; i++)
        {
            string name = Console.ReadLine();
            people.Add(name);
        }

        foreach (string person in people)
        {
            Console.WriteLine(person);
        }
    }
}

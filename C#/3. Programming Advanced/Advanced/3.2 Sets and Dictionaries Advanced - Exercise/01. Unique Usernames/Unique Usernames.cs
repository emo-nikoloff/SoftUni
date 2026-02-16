/*Create a program that reads from the console a sequence of N usernames and keeps a collection only of the unique ones. On the first line, you will be given an integer N. On the next N lines,
you will receive one username per line. Print the collection on the console in order of insertion:*/
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

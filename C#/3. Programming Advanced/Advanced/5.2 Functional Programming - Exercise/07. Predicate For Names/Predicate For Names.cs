/*Write a program that filters a list of names according to their length. On the first line, you will be given an integer n, representing a name's length. On the second line, you will be given
some names as strings separated by space. Write a function that prints only the names whose length is less than or equal to n.*/
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

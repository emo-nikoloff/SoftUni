/*Create a program that traverses a collection of names and returns the first name, whose sum of characters is equal to or larger than a given number N, which will be given on the first line.
Use a function that accepts another function as one of its parameters. Start by building a regular function to hold the basic logic of the program. Something along the lines of
Func<string, int, bool>. Afterward, create your main function which should accept the first function as one of its parameters.*/
namespace _11._TriFunction;

class Program
{
    static void Main(string[] args)
    {
        int limitNumber = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split();

        Func<string[], Func<string, int, bool>, string> firstOccurrence = (names, predicate) =>
        {
            foreach (string name in names)
            {
                int charsSum = 0;
                foreach (char letter in name)
                {
                    charsSum += letter;
                }

                if (predicate(name, charsSum))
                {
                    return name;
                }
            }

            return null;
        };

        Console.WriteLine(firstOccurrence(names, (name, sum) => sum >= limitNumber));
    }
}

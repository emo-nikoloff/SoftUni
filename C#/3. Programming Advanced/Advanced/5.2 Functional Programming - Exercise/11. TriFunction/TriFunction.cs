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

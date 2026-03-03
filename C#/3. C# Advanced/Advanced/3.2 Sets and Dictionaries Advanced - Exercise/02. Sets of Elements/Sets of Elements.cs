namespace _02._Sets_of_Elements;

class Program
{
    static void Main(string[] args)
    {
        int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int firstSetLength = sizes[0];
        int secondSetLength = sizes[1];

        HashSet<int> firstSet = new();
        for (int i = 1; i <= firstSetLength; i++)
        {
            int number = int.Parse(Console.ReadLine());
            firstSet.Add(number);
        }

        HashSet<int> secondSet = new();
        for (int i = 1; i <= secondSetLength; i++)
        {
            int number = int.Parse(Console.ReadLine());
            secondSet.Add(number);
        }

        HashSet<int> repeatingNumbers = new();
        foreach (int numberFirstSet in firstSet)
        {
            foreach (int numberSecondSet in secondSet)
            {
                if (numberFirstSet == numberSecondSet)
                {
                    repeatingNumbers.Add(numberFirstSet);
                    break;
                }
            }
        }
        Console.WriteLine(string.Join(" ", repeatingNumbers));
    }
}

/*Create a program that prints a set of elements. On the first line, you will receive two numbers - n and m, which represent the lengths of two separate sets. On the next n + m lines, you will
receive n numbers, which are the numbers in the first set, and m numbers, which are in the second set. Find all the unique elements that appear in both of them and print them in the order in
which they appear in the first set - n. For example:
Set with length n = 4: {1, 3, 5, 7}
Set with length m = 3: {3, 4, 5}
Set that contains all the elements that repeat in both sets -> {3, 5}*/
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

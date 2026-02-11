namespace _04._Find_Evens_or_Odds;

class Program
{
    static void Main(string[] args)
    {
        int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int start = range[0], end = range[1];

        string numberType = Console.ReadLine();

        Predicate<int> predicate = null;
        switch (numberType)
        {
            case "odd":
                predicate = number => number % 2 != 0;
                break;
            case "even":
                predicate = number => number % 2 == 0;
                break;
            default:
                predicate = number => false;
                break;
        }

        for (int i = start; i <= end; i++)
        {
            if (predicate(i))
            {
                Console.Write($"{i} ");
            }
        }
    }
}

namespace _03._Custom_Min_Function;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Func<int[], int> smallestNumber = numbers =>
        {
            int minNumber = int.MaxValue;

            foreach (int number in numbers)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            return minNumber;
        };
        Console.WriteLine(smallestNumber(numbers));
    }
}

/*Create a simple program that reads from the console a set of integers and prints back on the console the smallest number from the collection. Use Func<T, T>.*/
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

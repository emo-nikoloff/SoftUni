namespace _06._Reverse_And_Exclude;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        int digit = int.Parse(Console.ReadLine());

        Func<List<int>, List<int>> reverse = numbers =>
        {
            int[] numbersArray = numbers.ToArray();
            for (int i = 0; i < numbersArray.Length / 2; i++)
            {
                int temp = numbersArray[i];
                numbersArray[i] = numbersArray[numbersArray.Length - 1 - i];
                numbersArray[numbersArray.Length - 1 - i] = temp;
            }
            return numbersArray.ToList();
        };
        Predicate<int> isDivisible = number => number % digit == 0;

        numbers = reverse(numbers.Where(n => !isDivisible(n)).ToList());
        Console.WriteLine(string.Join(" ", numbers));
    }
}

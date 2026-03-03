namespace _01._Count_Same_Values_in_Array;

class Program
{
    static void Main(string[] args)
    {
        double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
        Dictionary<double, int> countNumbers = new();

        foreach (double number in numbers)
        {
            if (countNumbers.ContainsKey(number))
            {
                countNumbers[number]++;
            }
            else
            {
                countNumbers.Add(number, 1);
            }
        }

        foreach (KeyValuePair<double, int> number in countNumbers)
        {
            Console.WriteLine($"{number.Key} - {number.Value} times");
        }
    }
}

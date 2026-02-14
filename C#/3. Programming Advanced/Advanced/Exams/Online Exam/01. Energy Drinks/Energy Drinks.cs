namespace _01._Energy_Drinks;

class Program
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Stack<int> milligramsCaffeine = new(input);

        input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Queue<int> energyDrinks = new(input);

        int maximumCaffeine = 0;
        while (milligramsCaffeine.Count > 0)
        {
            if (energyDrinks.Count <= 0)
            {
                break;
            }

            int milligrams = milligramsCaffeine.Pop();
            int drinks = energyDrinks.Dequeue();

            if (maximumCaffeine + (milligrams * drinks) <= 300)
            {
                maximumCaffeine += milligrams * drinks;
            }
            else
            {
                energyDrinks.Enqueue(drinks);
                if (maximumCaffeine - 30 >= 0)
                {
                    maximumCaffeine -= 30;
                }
            }
        }

        if (energyDrinks.Count == 0)
        {
            Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
        }
        else
        {
            Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
        }
        Console.WriteLine($"Stamat is going to sleep with {maximumCaffeine} mg caffeine.");
    }
}

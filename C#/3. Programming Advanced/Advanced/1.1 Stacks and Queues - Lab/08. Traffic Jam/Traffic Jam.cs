namespace _08._Traffic_Jam;

class Program
{
    static void Main(string[] args)
    {
        int passingCars = int.Parse(Console.ReadLine());
        Queue<string> carsQueue = new();

        string input = string.Empty;
        int carsCount = 0;
        while ((input = Console.ReadLine()) != "end")
        {
            if (input == "green")
            {
                for (int i = 1; i <= passingCars && carsQueue.Count > 0; i++)
                {
                    Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                    carsCount++;
                }
            }
            else
            {
                carsQueue.Enqueue(input);
            }
        }
        Console.WriteLine($"{carsCount} cars passed the crossroads.");
    }
}

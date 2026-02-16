/*Create a program that simulates the queue that forms during a traffic jam. During a traffic jam, only N cars can pass the crossroads when the light goes green. Then the program reads the
vehicles that arrive one by one and adds them to the queue. When the light goes green N number of cars pass the crossroads and for each, a message "{car} passed!" is displayed. When the "end"
command is given, terminate the program and display a message with the total number of cars that passed the crossroads.*/
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

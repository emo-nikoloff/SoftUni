namespace _06._Supermarket;

class Program
{
    static void Main(string[] args)
    {
        string input = string.Empty;
        Queue<string> customers = new();
        while ((input = Console.ReadLine()) != "End")
        {
            if (input != "Paid")
            {
                customers.Enqueue(input);
            }
            else
            {
                while (customers.Count > 0)
                {
                    Console.WriteLine(customers.Dequeue());
                }
            }
        }
        Console.WriteLine($"{customers.Count} people remaining.");
    }
}

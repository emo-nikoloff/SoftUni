/*You are given a sequence of input strings, each staying on a separate line. Each input string holds either a customer name, or the command “Paid” or the command “End”.
Your task is to read and process the input:
· When you receive a customer name, add it to the queue
· When you receive the "Paid" command, print the customer names from the queue (each at separate line), then empty the queue
· When you receive the "End" command, print the count of the remaining customers from the queue in the format: "{count} people remaining." and stop processing the commands*/
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

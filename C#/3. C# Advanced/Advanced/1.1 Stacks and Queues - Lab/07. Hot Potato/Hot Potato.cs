namespace _07._Hot_Potato;

class Program
{
    static void Main(string[] args)
    {
        string[] kids = Console.ReadLine().Split();
        int tosses = int.Parse(Console.ReadLine());
        Queue<string> circle = new(kids);

        while (circle.Count > 1)
        {
            for (int i = 1; i < tosses; i++)
            {
                circle.Enqueue(circle.Dequeue());
            }
            Console.WriteLine($"Removed {circle.Dequeue()}");
        }
        Console.WriteLine($"Last is {circle.Dequeue()}");
    }
}

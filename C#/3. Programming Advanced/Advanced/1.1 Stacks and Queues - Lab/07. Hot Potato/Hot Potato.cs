/*Hot potato is a game in which children form a circle and start passing a hot potato. The counting starts with the first kid. Every nth toss the child left with the potato leaves the game.
When a kid leaves the game, it passes the potato along to its next neighbor. This continues until there is only one kid left. Create a program that simulates the game of Hot Potato.
Print every kid that is removed from the circle. In the end, print the kid that is left last.*/
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

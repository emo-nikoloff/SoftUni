namespace _04._Fast_Food;

class Program
{
    static void Main(string[] args)
    {
        int quantity = int.Parse(Console.ReadLine());
        int[] ordersInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Queue<int> orders = new(ordersInput);

        Console.WriteLine(orders.Max());

        while (orders.Count > 0)
        {
            if (orders.Peek() <= quantity)
            {
                int order = orders.Dequeue();
                quantity -= order;
            }
            else
            {
                break;
            }
        }

        if (orders.Count > 0)
        {
            Console.Write("Orders left:");
            while (orders.Count > 0)
            {
                Console.Write($" {orders.Dequeue()}");
            }
        }
        else
        {
            Console.WriteLine("Orders complete");
        }
    }
}

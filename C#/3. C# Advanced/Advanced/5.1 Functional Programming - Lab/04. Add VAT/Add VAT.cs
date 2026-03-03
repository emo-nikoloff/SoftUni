namespace _04._Add_VAT;

class Program
{
    static void Main(string[] args)
    {
        double[] prices = Console.ReadLine().Split(", ").Select(double.Parse).Select(n => n + n * 0.2).ToArray();
        foreach (double price in prices)
        {
            Console.WriteLine($"{price:f2}");
        }
    }
}

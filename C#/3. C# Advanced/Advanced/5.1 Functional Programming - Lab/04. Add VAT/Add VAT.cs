/*Create a program that reads one line of double prices separated by ", ". Print the prices with added VAT for all of them. Format them to 2 signs after the decimal point. The order of the prices
must be the same. VAT is equal to 20% of the price.*/
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

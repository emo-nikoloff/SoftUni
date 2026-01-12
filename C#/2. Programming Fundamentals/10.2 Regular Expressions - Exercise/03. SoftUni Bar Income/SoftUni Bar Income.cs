/*Let's take a break and visit the game bar at SoftUni. It is about time for the people behind the bar to go home and you are the person who has to draw the line and calculate the money from the
products that were sold throughout the day. Until you receive a line with the text "end of shift", you will be given lines of input. But before processing that line, you have to do some validations
first.
Each valid order should have a customer, product, count and a price:
· A valid customer's name should be surrounded by '%' and must start with a capital letter, followed by lower-case letters.
· A valid product contains any word character and must be surrounded by '<' and '>' .
· A valid count is an integer, surrounded by '|'.
· A valid price is any real number followed by '$'.
The parts of a valid order should appear in the order given: customer, product, count and price.
Between each part there can be other symbols, except '|', '$', '%' and '.'.
For each valid line, print on the console: "{customerName}: {product} - {totalPrice}".
When you receive "end of shift" print the total amount of money for the day, rounded to 2 decimal places in the following format: "Total income: {income}".
· Strings that you have to process until you receive text "end of shift".
· Print all of the valid lines in the format "{customerName}: {product} - {totalPrice}".
· After receiving "end of shift", print the total amount of money for the day, rounded to 2 decimal places in the following format: "Total income: {income}".
· Allowed working time / memory: 100ms / 16MB.*/
using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income;

class Program
{
    static void Main(string[] args)
    {
        string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+|\d+\.\d+)\$";
        string input;

        double total = 0;

        while ((input = Console.ReadLine()) != "end of shift")
        {
            foreach (Match match in Regex.Matches(input, pattern))
            {
                Order order = new();

                order.Customer = match.Groups["customer"].Value;
                order.Product = match.Groups["product"].Value;
                order.Count = int.Parse(match.Groups["count"].Value);
                order.Price = double.Parse(match.Groups["price"].Value);

                total += order.TotalPrice();

                Console.WriteLine($"{order.Customer}: {order.Product} - {order.TotalPrice():f2}");
            }
        }

        Console.WriteLine($"Total income: {total:f2}");
    }
}

class Order
{
    public string Customer { get; set; }
    public string Product { get; set; }
    public int Count { get; set; }
    public double Price { get; set; }

    public double TotalPrice()
    {
        return Count * Price;
    }
}

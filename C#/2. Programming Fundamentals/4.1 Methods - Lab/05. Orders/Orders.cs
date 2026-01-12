/*Create a program that calculates and prints the total price of an order. The method should receive two parameters:
· A string, representing a product - "coffee", "water", "coke", "snacks"
· An integer, representing the quantity of the product
The prices for a single item of each product are:
· coffee – 1.50
· water – 1.00
· coke – 1.40
· snacks – 2.00
Print the result, rounded to the second decimal place.
*Hints
1. Read the first two lines
2. Create a method to pass the two variables in
3. Print the result in the method*/
using System;

namespace _05._Orders;

class Program
{
    static void Main(string[] args)
    {
        string product = Console.ReadLine();
        int quantity = int.Parse(Console.ReadLine());

        TotalPrice(product, quantity);
    }

    static void TotalPrice(string product, int quantity)
    {
        double totalPrice;
        switch (product)
        {
            case "coffee":
                totalPrice = quantity * 1.5;
                Console.WriteLine($"{totalPrice:f2}");
                break;
            case "water":
                totalPrice = quantity * 1.0;
                Console.WriteLine($"{totalPrice:f2}");
                break;
            case "coke":
                totalPrice = quantity * 1.4;
                Console.WriteLine($"{totalPrice:f2}");
                break;
            case "snacks":
                totalPrice = quantity * 2.0;
                Console.WriteLine($"{totalPrice:f2}");
                break;
        }
    }
}

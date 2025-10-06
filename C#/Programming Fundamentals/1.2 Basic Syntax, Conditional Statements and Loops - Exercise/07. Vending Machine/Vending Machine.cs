/*Write a program that accumulates coins. Until the "Start" command is given, you will receive coins, and only the valid ones should be accumulated. Valid coins are:
· 0.1, 0.2, 0.5, 1 and 2
If an invalid coin is inserted, print "Cannot accept {money}" and continue to the next line.
On the next lines, until the "End" command is given, you will start receiving products, which a customer wants to buy. The vending machine has only:
· "Nuts" with a price of 2.0
· "Water" with a price of 0.7
· "Crisps" with a price of 1.5
· "Soda" with a price of 0.8
· "Coke" with a price of 1.0
If the customer tries to purchase a not existing product, print "Invalid product".
When a customer has enough money to buy the selected product, print "Purchased {product name}", otherwise print "Sorry, not enough money" and continue to the next line.
When the "End" command is given print the reminding balance, formatted to the second decimal point: "Change: {money left}".*/
using System;
namespace _07._Vending_Machine;

class Program
{
    static void Main(string[] args)
    {
        string input;

        double sum = 0;
        while ((input = Console.ReadLine()) != "Start")
        {
            double coin = double.Parse(input);
            if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
            {
                sum += coin;
            }
            else
            {
                Console.WriteLine($"Cannot accept {coin}");
            }
        }

        while ((input = Console.ReadLine()) != "End")
        {
            double price = 0;

            bool isValidProduct = true;
            switch (input)
            {
                case "Nuts":
                    price = 2;
                    break;
                case "Water":
                    price = 0.7;
                    break;
                case "Crisps":
                    price = 1.5;
                    break;
                case "Soda":
                    price = 0.8;
                    break;
                case "Coke":
                    price = 1;
                    break;
                default:
                    Console.WriteLine("Invalid product");
                    isValidProduct = false;
                    break;
            }

            if (!isValidProduct)
            {
                continue;
            }

            if (sum >= price)
            {
                sum -= price;
                Console.WriteLine($"Purchased {input.ToLower()}");
            }
            else
            {
                Console.WriteLine("Sorry, not enough money");
            }
        }

        Console.WriteLine($"Change: {sum:f2}");
    }
}

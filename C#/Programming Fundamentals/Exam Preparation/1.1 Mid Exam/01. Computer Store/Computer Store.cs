/*Write a program that prints you a receipt for your new computer. You will receive the parts' prices (without tax) until you receive what type of customer this is - special or regular. Once you
receive the type of customer you should print the receipt.
The taxes are 20% of each part's price you receive.
If the customer is special, he has a 10% discount on the total price with taxes.
If a given price is not a positive number, you should print "Invalid price!" on the console and continue with the next price.
If the total price is equal to zero, you should print "Invalid order!" on the console.
· You will receive numbers representing prices (without tax) until input "special" or "regular":
· The receipt should be in the following format:
"Congratulations you've just bought a new computer!
Price without taxes: {total price without taxes}$
Taxes: {total amount of taxes}$
-----------
Total price: {total price with taxes}$"

Note: All prices should be displayed to the second digit after the decimal point! The discount is applied only to the total price. Discount is only applicable to the final price!*/
using System;

namespace _01._Computer_Store;

class Program
{
    static void Main(string[] args)
    {
        string input;

        double totalPriceWithoutTaxes = 0, totalTaxes = 0;

        while ((input = Console.ReadLine()) != "special" && input != "regular")
        {
            double partPrice = double.Parse(input);
            if (partPrice < 0)
            {
                Console.WriteLine("Invalid price!");
                continue;
            }

            totalPriceWithoutTaxes += partPrice;
            totalTaxes += partPrice * 0.2;
        }

        double totalPriceWithTaxes = totalPriceWithoutTaxes + totalTaxes;

        if (totalPriceWithTaxes == 0)
        {
            Console.WriteLine("Invalid order!");
            return;
        }

        if (input == "special")
        {
            totalPriceWithTaxes -= totalPriceWithTaxes * 0.1;
        }

        Console.WriteLine("Congratulations you've just bought a new computer!");
        Console.WriteLine($"Price without taxes: {totalPriceWithoutTaxes:f2}$");
        Console.WriteLine($"Taxes: {totalTaxes:f2}$");
        Console.WriteLine("-----------");
        Console.WriteLine($"Total price: {totalPriceWithTaxes:f2}$");
    }
}

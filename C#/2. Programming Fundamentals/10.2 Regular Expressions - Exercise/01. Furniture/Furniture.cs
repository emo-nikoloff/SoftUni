/*Create a program to calculate the total cost of different types of furniture. You will be given some lines of input, until you receive the line "Purchase". For the line to be valid it should be in
the following format:
">>{furniture name}<<{price}!{quantity}"
The price can be a floating-point number or a whole number. Store the names of the furniture and the total price. At the end, print each bought furniture on a separate line in the format:
"Bought furniture:
{1st name}
{2nd name}
…"
And on the last line, print the following: "Total money spend: {spend money}", formatted to the second decimal point.*/
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture;

class Program
{
    static void Main(string[] args)
    {
        string input;
        string pattern = @">>(?<furniture>[A-Za-z]+)<<(?<price>\d+|\d+\.\d+)!(?<quantity>\d+)";
        List<Furniture> furnitures = new();

        while ((input = Console.ReadLine()) != "Purchase")
        {
            foreach (Match match in Regex.Matches(input, pattern))
            {
                string name = match.Groups["furniture"].Value;
                double price = double.Parse(match.Groups["price"].Value);
                int quantity = int.Parse(match.Groups["quantity"].Value);

                Furniture furniture = new(name, price, quantity);

                furnitures.Add(furniture);
            }
        }

        Console.WriteLine("Bought furniture:");

        double totalPrice = 0;

        foreach (Furniture furniture in furnitures)
        {
            Console.WriteLine(furniture.Name);
            totalPrice += furniture.GetTotal();
        }

        Console.WriteLine($"Total money spend: {totalPrice:f2}");
    }
}

class Furniture
{
    public Furniture(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public double GetTotal()
    {
        return Price * Quantity;
    }
}

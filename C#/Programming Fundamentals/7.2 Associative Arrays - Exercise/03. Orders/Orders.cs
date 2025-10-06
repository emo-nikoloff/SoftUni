/*Create a program that keeps the information about products and their prices. Each product has a name, a price and a quantity. If the product doesn't exist yet, add it with its starting quantity.
If you receive a product, which already exists, increase its quantity by the input quantity and if its price is different, replace the price as well.
You will receive products' names, prices and quantities on new lines. Until you receive the command "buy", keep adding items. When you do receive the command "buy", print the items with their names
and the total price of all the products with that name.
· Until you receive "buy", the products will be coming in the format: "{name} {price} {quantity}".
· The product data is always delimited by a single space.
· Print information about each product in the following format: "{productName} -> {totalPrice}"
· Format the average grade to the 2nd digit after the decimal separator.*/
using System;
using System.Collections.Generic;

namespace _03._Orders;

class Program
{
    static void Main(string[] args)
    {
        string command;
        Dictionary<string, Product> productsPrice = new();

        while ((command = Console.ReadLine()) != "buy")
        {
            string[] commandParts = command.Split();
            string productName = commandParts[0];
            double productPrice = double.Parse(commandParts[1]);
            int productQuantity = int.Parse(commandParts[2]);

            Product product = new(productName, productPrice, productQuantity);

            if (productsPrice.ContainsKey(productName))
            {
                productsPrice[productName].Quantity += productQuantity;
                productsPrice[productName].Price = productPrice;
                continue;
            }
            productsPrice[productName] = product;
        }

        foreach ((string prName, Product productTotalPrice) in productsPrice)
        {
            Console.WriteLine($"{prName} -> {productTotalPrice.Price * productTotalPrice.Quantity:f2}");
        }
    }
}

class Product
{
    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}

/*Define a class Item, which contains these properties: Name and Price.
Define a class Box, which contains these properties: Serial Number, Item, Item Quantity and Price for a Box.
Until you receive "end", you will be receiving data in the following format: "{Serial Number} {Item Name} {Item Quantity} {itemPrice}"
The Price of one box has to be calculated: itemQuantity * itemPrice.
Print all the boxes ordered descending by price for a box, in the following format:
{boxSerialNumber}
-- {boxItemName} - ${boxItemPrice}: {boxItemQuantity}
-- ${boxPrice}
The price should be formatted to the 2nd digit after the decimal separator.*/
using System;
using System.Collections.Generic;

namespace _06._Store_Boxes;

class Program
{
    static void Main(string[] args)
    {
        string data;
        List<Box> boxes = new();

        while ((data = Console.ReadLine()) != "end")
        {
            string[] dataParts = data.Split();

            Box box = new();
            box.SerialNumber = dataParts[0];
            box.Item.Name = dataParts[1];
            box.Quantity = int.Parse(dataParts[2]);
            box.Item.Price = double.Parse(dataParts[3]);

            boxes.Add(box);
        }

        boxes.Sort((firstBox, secondBox) => secondBox.PriceBox.CompareTo(firstBox.PriceBox));

        foreach (Box box in boxes)
        {
            Console.WriteLine(box.SerialNumber);
            Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
            Console.WriteLine($"-- ${box.PriceBox:f2}");
        }
    }
}

class Item
{
    public string Name { get; set; }
    public double Price { get; set; }
}

class Box
{
    public Box()
    {
        Item = new();
    }

    public string SerialNumber { get; set; }
    public Item Item { get; set; }
    public int Quantity { get; set; }
    public double PriceBox
    {
        get
        {
            return Quantity * Item.Price;
        }
    }
}
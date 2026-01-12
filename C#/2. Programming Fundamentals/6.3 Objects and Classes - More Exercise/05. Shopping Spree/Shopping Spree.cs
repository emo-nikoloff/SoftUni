/*Create two classes: class Person and class Product. Each person should have a name, money and a bag of products. Each product should have a name and a cost.
Create a program, in which each command corresponds to a person buying a product. If the person can afford a product, add it to his bag. If a person doesn't have enough money, print an appropriate
message: "{Person} can't afford {Product}".
On the first two lines, you are given all people and all products. After all purchases, print every person in the order of appearance and all products that they have bought, also in order of
appearance. If nothing was bought, print the name of the person followed by "Nothing bought".*/
using System;
using System.Collections.Generic;

namespace _05._Shopping_Spree;

class Program
{
    static void Main(string[] args)
    {
        string[] people = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
        string[] products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

        int peopleNumber = people.Length;
        int productsNumber = products.Length;

        List<Person> peopleList = new();
        List<Product> productsList = new();

        for (int i = 0; i < peopleNumber; i++)
        {
            string[] individual = people[i].Split("=");
            string personName = individual[0];
            int personBudget = int.Parse(individual[1]);

            Person person = new(personName, personBudget);
            peopleList.Add(person);
        }

        for (int i = 0; i < productsNumber; i++)
        {
            string[] item = products[i].Split("=");
            string productName = item[0];
            int productPrice = int.Parse(item[1]);

            Product product = new(productName, productPrice);
            productsList.Add(product);
        }

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] commandArgs = command.Split();
            string buyer = commandArgs[0];
            string bought = commandArgs[1];

            Person purchaser = peopleList.Find(p => p.Name == buyer);
            Product purchased = productsList.Find(p => p.Name == bought);
            purchaser.Buy(purchased);
        }

        foreach (Person person in peopleList)
        {
            Console.WriteLine(person);
        }
    }
}

class Person
{
    public Person(string name, int money)
    {
        Name = name;
        Money = money;
        Products = new();
    }

    public string Name { get; set; }
    public int Money { get; set; }
    public List<Product> Products { get; set; }

    public override string ToString()
    {
        if (Products.Count > 0)
        {
            return $"{Name} - {string.Join(", ", Products)}";
        }
        else
        {
            return $"{Name} - Nothing bought";
        }
    }

    public void Buy(Product item)
    {
        if (Money - item.Price >= 0)
        {
            Money -= item.Price;
            Products.Add(item);
            Console.WriteLine($"{Name} bought {item.Name}");
        }
        else
        {
            Console.WriteLine($"{Name} can't afford {item.Name}");
        }
    }
}

class Product
{
    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; }
    public int Price { get; set; }

    public override string ToString()
    {
        return Name;
    }
}

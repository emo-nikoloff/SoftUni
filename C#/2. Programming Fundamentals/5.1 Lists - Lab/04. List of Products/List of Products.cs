/*Read a number n and n lines of products. Print a numbered list of all the products ordered by name.
*Hints
First, we need to read the number n from the console.
Then we need to create our list of strings, because the products are strings.
Then we need to iterate n times and read our current product.
The next step is to add the current product to the list.
After we finish reading the products, we sort our list alphabetically.
· The sort method sorts the list in ascending order.
Finally, we have to print our sorted list. To do that we loop through the list.
· We use i + 1 because we want to start counting from 1, we put the '.', and finally, we put the actual product.*/
using System;
using System.Collections.Generic;

namespace _04._List_of_Products;

class Program
{
    static void Main(string[] args)
    {
        int products = int.Parse(Console.ReadLine());

        List<string> productsList = new();
        for (int i = 1; i <= products; i++)
        {
            string product = Console.ReadLine();
            productsList.Add(product);
        }

        productsList.Sort();
        for (int i = 0; i < products; i++)
        {
            Console.WriteLine($"{i + 1}.{productsList[i]}");
        }
    }
}

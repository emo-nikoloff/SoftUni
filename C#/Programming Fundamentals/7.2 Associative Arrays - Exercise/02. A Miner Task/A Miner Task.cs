/*You will be given a sequence of strings, each on a new line. Every odd line on the console is representing a resource (e.g. Gold, Silver, Copper and so on) and every even - quantity. Your task is to
collect the resources and print them each on a new line.
Print the resources and their quantities in the following format:
"{resource} –> {quantity}"*/
using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task;

class Program
{
    static void Main(string[] args)
    {
        string input;
        Dictionary<string, int> resourcesQuantity = new();

        while ((input = Console.ReadLine()) != "stop")
        {
            int quantity = int.Parse(Console.ReadLine());

            if (resourcesQuantity.ContainsKey(input))
            {
                resourcesQuantity[input] += quantity;
                continue;
            }
            resourcesQuantity[input] = quantity;
        }

        foreach ((string material, int count) in resourcesQuantity)
        {
            Console.WriteLine($"{material} -> {count}");
        }
    }
}

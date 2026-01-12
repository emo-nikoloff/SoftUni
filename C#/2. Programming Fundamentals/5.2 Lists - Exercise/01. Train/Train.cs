/*On the first line, we will receive a list of wagons (integers). Each integer represents the number of passengers that are currently in each wagon of the passenger train. On the next line, you will
receive the max capacity of a wagon, represented as a single integer. Until you receive the "end" command, you will be receiving two types of input:
· Add {passengers} – add a wagon to the end of the train with the given number of passengers.
· {passengers} – find a single wagon to fit all the incoming passengers (starting from the first wagon).
In the end, print the final state of the train (all the wagons separated by a space).*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train;

class Program
{
    static void Main(string[] args)
    {
        List<int> wagonsWithPassengers = Console.ReadLine().Split().Select(int.Parse).ToList();
        int maxCapacityOfWagon = int.Parse(Console.ReadLine());
        string command;

        while ((command = Console.ReadLine()) != "end")
        {
            string[] commandParts = command.Split();

            switch (commandParts[0])
            {
                case "Add":
                    int newWagonWithPassengers = int.Parse(commandParts[1]);
                    wagonsWithPassengers.Add(newWagonWithPassengers);
                    break;
                default:
                    int passengers = int.Parse(commandParts[0]);
                    for (int i = 0; i < wagonsWithPassengers.Count; i++)
                    {
                        if (wagonsWithPassengers[i] + passengers <= maxCapacityOfWagon)
                        {
                            wagonsWithPassengers[i] += passengers;
                            break;
                        }
                    }
                    break;
            }
        }

        Console.WriteLine(string.Join(" ", wagonsWithPassengers));
    }
}

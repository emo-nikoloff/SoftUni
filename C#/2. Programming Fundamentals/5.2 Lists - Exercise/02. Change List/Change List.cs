/*Create a program, that reads a list of integers from the console and receives commands to manipulate the list.
Your program may receive the following commands:
· Delete {element} – delete all elements in the array, which are equal to the given element.
· Insert {element} {position} – insert the element at the given position.
You should exit the program when you receive the "end" command. Print all numbers in the array, separated by a single whitespace.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        string command;

        while ((command = Console.ReadLine()) != "end")
        {
            string[] commandParts = command.Split();

            switch (commandParts[0])
            {
                case "Delete":
                    int equalNumber = int.Parse(commandParts[1]);
                    numbers.RemoveAll(number => number == equalNumber);
                    break;
                case "Insert":
                    int number = int.Parse(commandParts[1]);
                    int index = int.Parse(commandParts[2]);
                    numbers.Insert(index, number);
                    break;
            }
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}

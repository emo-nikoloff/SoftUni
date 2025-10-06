/*Create a program that reads a list of integers. Then until you receive "end", you will receive different commands:
· Add {number}: add a number to the end of the list.
· Remove {number}: remove a number from the list.
· RemoveAt {index}: remove a number at a given index.
· Insert {number} {index}: insert a number at a given index.
Note: All the indices will be valid!
When you receive the "end" command, print the final state of the list (separated by spaces).
*Hints
First let us read the list from the console.
· We split the string we have received from the console, then we loop through each of the elements and parse them to integers.
· This returns IEnumerable<int> (a collection of integers) and we have to keep it in the form of a list.
Next, we go through the input using a while loop and a switch case statement for the different commands.
· We stop the cycle, if the line is ended, otherwise, we split the input string into tokens.
Now, let us implement each of the commands.
· For each of the commands, except "Insert", tokens[1] is the number / index.
· For the "Insert" command we receive a number and an index (tokens[1], tokens[2]).
Finally, we print the numbers, joined by a single space.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics;

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
                case "Add":
                    int numberToAdd = int.Parse(commandParts[1]);
                    numbers.Add(numberToAdd);
                    break;
                case "Remove":
                    int numberToRemove = int.Parse(commandParts[1]);
                    numbers.Remove(numberToRemove);
                    break;
                case "RemoveAt":
                    int indexToRemove = int.Parse(commandParts[1]);
                    numbers.RemoveAt(indexToRemove);
                    break;
                case "Insert":
                    int numberToInsert = int.Parse(commandParts[1]);
                    int indexToInsert = int.Parse(commandParts[2]);
                    numbers.Insert(indexToInsert, numberToInsert);
                    break;
            }
        }
        Console.WriteLine(string.Join(" ", numbers));
    }
}

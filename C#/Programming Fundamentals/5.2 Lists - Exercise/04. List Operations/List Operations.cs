/*The first input line will hold a list of integers. Until we receive the "End" command, we will be given operations we have to apply to the list.
The possible commands are:
· Add {number} – add the given number to the end of the list
· Insert {number} {index} – insert the number at the given index
· Remove {index} – remove the number at the given index
· Shift left {count} – first number becomes last. This has to be repeated the specified number of times
· Shift right {count} – last number becomes first. To be repeated the specified number of times
Note: the index given may be outside of the bounds of the array. In that case print: "Invalid index".*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] commandParts = command.Split();

            switch (commandParts[0])
            {
                case "Add":
                    int numberToAdd = int.Parse(commandParts[1]);
                    numbers.Add(numberToAdd);
                    break;
                case "Insert":
                    int numberToInsert = int.Parse(commandParts[1]);
                    int indexToInsert = int.Parse(commandParts[2]);
                    if (indexToInsert < 0 || indexToInsert > numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(indexToInsert, numberToInsert);
                    }
                    break;
                case "Remove":
                    int indexToRemove = int.Parse(commandParts[1]);
                    if (indexToRemove < 0 || indexToRemove > numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(indexToRemove);
                    }
                    break;
                case "Shift":
                    int shiftPositions = int.Parse(commandParts[2]);
                    shiftPositions %= numbers.Count;
                    List<int> shiftPart = new();
                    switch (commandParts[1])
                    {
                        case "left":
                            shiftPart = numbers.GetRange(0, shiftPositions);
                            numbers.RemoveRange(0, shiftPositions);
                            numbers.InsertRange(numbers.Count, shiftPart);
                            break;
                        case "right":
                            shiftPart = numbers.GetRange(numbers.Count - shiftPositions, shiftPositions);
                            numbers.RemoveRange(numbers.Count - shiftPositions, shiftPositions);
                            numbers.InsertRange(0, shiftPart);
                            break;
                    }
                    break;
            }
        }
        Console.WriteLine(string.Join(" ", numbers));
    }
}

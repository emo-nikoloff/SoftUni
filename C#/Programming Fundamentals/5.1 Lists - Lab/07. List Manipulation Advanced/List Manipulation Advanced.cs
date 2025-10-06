/*Next, we are going to implement more complicated list commands, extending the previous task. Again, read a list and keep reading commands until you receive "end":
· Contains {number} – check if the list contains the number and if so - print "Yes", otherwise print "No such number".
· PrintEven – print all the even numbers, separated by a space.
· PrintOdd – print all the odd numbers, separated by a space.
· GetSum – print the sum of all the numbers.
· Filter {condition} {number} – print all the numbers that fulfill the given condition. The condition will be either '<', '>', ">=", "<=".
After the end command, print the list only if you have made some changes to the original list. Changes are made only from the commands from the previous task.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        string command;

        bool isChanged = false;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] commandParts = command.Split();
            switch (commandParts[0])
            {
                case "Add":
                    int numberToAdd = int.Parse(commandParts[1]);
                    numbers.Add(numberToAdd);
                    isChanged = true;
                    break;
                case "Remove":
                    int numberToRemove = int.Parse(commandParts[1]);
                    numbers.Remove(numberToRemove);
                    isChanged = true;
                    break;
                case "RemoveAt":
                    int indexToRemove = int.Parse(commandParts[1]);
                    numbers.RemoveAt(indexToRemove);
                    isChanged = true;
                    break;
                case "Insert":
                    int numberToInsert = int.Parse(commandParts[1]);
                    int indexToInsert = int.Parse(commandParts[2]);
                    numbers.Insert(indexToInsert, numberToInsert);
                    isChanged = true;
                    break;

                case "Contains":
                    int numberToCheck = int.Parse(commandParts[1]);
                    if (numbers.Contains(numberToCheck))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                    break;
                case "PrintEven":
                    PrintEven(numbers);
                    break;
                case "PrintOdd":
                    PrintOdd(numbers);
                    break;
                case "GetSum":
                    int sumNumbers = numbers.Sum();
                    Console.WriteLine(sumNumbers);
                    break;
                case "Filter":
                    string condition = commandParts[1];
                    int borderNumber = int.Parse(commandParts[2]);
                    List<int> filteredList = Filter(numbers, condition, borderNumber);
                    Console.WriteLine(string.Join(" ", filteredList));
                    break;
            }
        }

        if (isChanged)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    static void PrintEven(List<int> numbers)
    {
        List<int> evenNumbersList = new();

        foreach (int number in numbers)
        {
            if (number % 2 == 0 && number != 0)
            {
                evenNumbersList.Add(number);
            }
        }

        Console.WriteLine(string.Join(" ", evenNumbersList));
    }

    static void PrintOdd(List<int> numbers)
    {
        List<int> oddNumbersList = new();

        foreach (int number in numbers)
        {
            if (number % 2 != 0)
            {
                oddNumbersList.Add(number);
            }
        }

        Console.WriteLine(string.Join(" ", oddNumbersList));
    }

    static List<int> Filter(List<int> numbers, string condition, int borderNumber)
    {
        List<int> filteredNumbersList = new();

        foreach (int number in numbers)
        {
            switch (condition)
            {
                case "<":
                    if (number < borderNumber)
                    {
                        filteredNumbersList.Add(number);
                    }
                    break;
                case ">":
                    if (number > borderNumber)
                    {
                        filteredNumbersList.Add(number);
                    }
                    break;
                case ">=":
                    if (number >= borderNumber)
                    {
                        filteredNumbersList.Add(number);
                    }
                    break;
                case "<=":
                    if (number <= borderNumber)
                    {
                        filteredNumbersList.Add(number);
                    }
                    break;
            }
        }

        return filteredNumbersList;
    }
}

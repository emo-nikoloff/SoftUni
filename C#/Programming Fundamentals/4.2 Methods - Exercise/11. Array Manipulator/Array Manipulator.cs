/*Peter has finally become a junior developer and has received his first task. It's about manipulating an array of integers. He is not quite happy about it, since he hates manipulating arrays. They are
going to pay him a lot of money, though, and he is willing to give somebody half of it if they help him do his job. You, on the other hand, love arrays (and money), so you decide to try your luck.
The array may be manipulated by one of the following commands
· exchange {index} – splits the array after the given index and exchanges the places of the two resulting sub-arrays. E.g. [1, 2, 3, 4, 5] -> exchange 2 -> result: [4, 5, 1, 2, 3]
    o If the index is outside the boundaries of the array, print "Invalid index"
· max even/odd – returns the INDEX of the max even/odd element -> [1, 4, 8, 2, 3] -> max odd -> print 4
· min even/odd – returns the INDEX of the min even/odd element -> [1, 4, 8, 2, 3] -> min even > print 3
    o If there are two or more equal min/max elements, return the index of the rightmost one
    o If a min/max even/odd element cannot be found, print "No matches"
· first {count} even/odd – returns the first {count} elements -> [1, 8, 2, 3] -> first 2 even -> print [8, 2]
· last {count} even/odd – returns the last {count} elements -> [1, 8, 2, 3] -> last 2 odd -> print [1, 3]
    o If the count is greater than the array length, print "Invalid count"
    o If there are not enough elements to satisfy the count, print as many as you can. If there are zero even/odd elements, print an empty array "[]"
· end – stop taking input and print the final state of the array
· The input data should be read from the console.
· On the first line, the initial array is received as a line of integers, separated by a single space.
· On the next lines, until the command "end" is received, you will receive the array manipulation commands.
· The input data will always be valid and in the format described. There is no need to check it explicitly.
· The output should be printed on the console.
· On a separate line, print the output of the corresponding command.
· On the last line print the final array in square brackets with its elements separated by a comma and a space .
· See the examples below to get a better understanding of your task.*/
using System;
using System.Linq;

namespace _11._Array_Manipulator;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string command;

        while ((command = Console.ReadLine()) != "end")
        {
            string[] commandParts = command.Split();
            switch (commandParts[0])
            {
                case "exchange":
                    int index = int.Parse(commandParts[1]);
                    numbers = Exchange(numbers, index);
                    break;
                case "max":
                    string maxType = commandParts[1];
                    PrintMaxNumberIndex(numbers, maxType);
                    break;
                case "min":
                    string minType = commandParts[1];
                    PrintMinNumberIndex(numbers, minType);
                    break;
                case "first":
                    int firstCount = int.Parse(commandParts[1]);
                    string firstType = commandParts[2];
                    PrintFirstElements(numbers, firstCount, firstType);
                    break;
                case "last":
                    int lastCount = int.Parse(commandParts[1]);
                    string lastType = commandParts[2];
                    PrintLastElements(numbers, lastCount, lastType);
                    break;
            }
        }
        Console.WriteLine($"[{string.Join(", ", numbers)}]");
    }

    static bool CheckRange(int[] array, int index)
    {
        return index < 0 || index >= array.Length;
    }

    static int[] Exchange(int[] array, int index)
    {
        if (CheckRange(array, index))
        {
            Console.WriteLine("Invalid index");
            return array;
        }

        int[] changedArray = new int[array.Length];
        int changedArrayIndex = 0;

        for (int i = index + 1; i <= array.Length - 1; i++)
        {
            changedArray[changedArrayIndex++] = array[i];
        }

        for (int i = 0; i <= index; i++)
        {
            changedArray[changedArrayIndex++] = array[i];
        }

        return changedArray;
    }

    static bool IsOddOrEven(string type, int number)
    {
        return (type == "even" && number % 2 == 0) ||
        (type == "odd" && number % 2 != 0);

    }

    static void PrintNotDefaultIndex(int index)
    {
        if (index != -1)
        {
            Console.WriteLine(index);
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }

    static void PrintMaxNumberIndex(int[] array, string type)
    {
        int maxIndex = -1, maxNumber = int.MinValue;
        for (int i = 0; i < array.Length; i++)
        {
            int number = array[i];
            if (IsOddOrEven(type, number))
            {
                if (number >= maxNumber)
                {
                    maxNumber = number;
                    maxIndex = i;
                }
            }
        }
        PrintNotDefaultIndex(maxIndex);
    }

    static void PrintMinNumberIndex(int[] array, string type)
    {
        int minIndex = -1, minNumber = int.MaxValue;
        for (int i = 0; i < array.Length; i++)
        {
            int number = array[i];
            if (IsOddOrEven(type, number))
            {
                if (number <= minNumber)
                {
                    minNumber = number;
                    minIndex = i;
                }
            }
        }
        PrintNotDefaultIndex(minIndex);
    }

    static void PrintFirstElements(int[] array, int count, string type)
    {
        if (count > array.Length)
        {
            Console.WriteLine("Invalid count");
            return;
        }

        string firstElements = string.Empty;
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            int number = array[i];
            if (IsOddOrEven(type, number))
            {
                firstElements += $"{number}, ";
                counter++;
                if (counter == count)
                {
                    break;
                }
            }
        }
        Console.WriteLine($"[{firstElements.Trim(' ', ',')}]");
    }

    static void PrintLastElements(int[] array, int count, string type)
    {
        if (count > array.Length)
        {
            Console.WriteLine("Invalid count");
            return;
        }

        string lastElements = string.Empty;
        int counter = 0;
        for (int i = array.Length - 1; i >= 0; i--)
        {
            int number = array[i];
            if (IsOddOrEven(type, number))
            {
                lastElements = $"{number}, " + lastElements;
                counter++;
                if (counter == count)
                {
                    break;
                }
            }
        }
        Console.WriteLine($"[{lastElements.Trim(' ', ',')}]");
    }
}

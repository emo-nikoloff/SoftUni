/*Create a program to append several arrays of numbers one after another.
· Arrays are separated by '|'
· Their values are separated by spaces (' ', one or several)
· Take all arrays starting from the rightmost and going to the left and place them in a new array in that order*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays;

class Program
{
    static void Main(string[] args)
    {
        List<string> arrays = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

        List<string> symbols = new();

        for (int i = arrays.Count - 1; i >= 0; i--)
        {
            List<string> currentArray = arrays[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            symbols.AddRange(currentArray);

        }

        Console.WriteLine(string.Join(" ", symbols));
    }
}

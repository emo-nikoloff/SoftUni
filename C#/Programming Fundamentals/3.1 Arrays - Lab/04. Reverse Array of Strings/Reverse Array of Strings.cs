/*Create a program that reads an array of strings, reverses it, and prints its elements. The input consists of a sequence of space-separated strings. Print the output on a single line (space separated)*/
using System;

namespace _04._Reverse_Array_of_Strings;

class Program
{
    static void Main(string[] args)
    {
        string[] elements = Console.ReadLine().Split();

        for (int i = 0; i < elements.Length / 2; i++)
        {
            string tempElement = elements[i];
            elements[i] = elements[elements.Length - 1 - i];
            elements[elements.Length - 1 - i] = tempElement;
        }
        Console.WriteLine(string.Join(" ", elements));
    }
}

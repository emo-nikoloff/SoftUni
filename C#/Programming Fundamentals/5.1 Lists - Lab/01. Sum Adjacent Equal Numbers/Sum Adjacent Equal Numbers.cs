/*Create a program to sum all of the adjacent equal numbers in a list of decimal numbers, starting from left to right.
· After two numbers are summed, the result could be equal to some of its neighbors and should be summed as well (see the examples below)
· Always sum the leftmost two equal neighbors (if several couples of equal neighbors are available)
*Hints
Read a list of numbers.
Iterate through the elements. Check if the number at the current index is equal to the next number. If it is, aggregate the numbers and reset the loop, otherwise don't do anything.
Finally, you have to print the numbers joined by a single space.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sum_Adjacent_Equal_Numbers;

class Program
{
    static void Main(string[] args)
    {
        List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

        for (int i = 0; i < numbers.Count - 1; i++)
        {
            if (numbers[i] == numbers[i + 1])
            {
                numbers[i] += numbers[i + 1];
                numbers.RemoveAt(i + 1);
                i = -1;
            }
        }
        Console.WriteLine(string.Join(" ", numbers));
    }
}

/*Read a list of integers, remove all negative numbers from it and print the remaining elements in reversed order. If there are no elements left in the list, print "empty".
*Hints
Read a list of integers.
Remove all negative numbers.
If the list count is equal to 0, print "empty", otherwise print all numbers joined by space.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

        for (int i = numbers.Count - 1; i >= 0; i--)
        {
            if (numbers[i] < 0)
            {
                numbers.RemoveAt(i);
            }
        }

        numbers.Reverse();

        if (numbers.Count == 0)
        {
            Console.WriteLine("empty");
        }
        else
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

/*Read two arrays and determine whether they are identical or not. The arrays are identical, if all their elements are equal. If the arrays are identical, find the sum of the elements of one of them
and print the following message to the console: "Arrays are identical. Sum: {sum}". Otherwise, find the first index where the arrays differ and print the following message to the console:
"Arrays are not identical. Found difference at {index} index".
*Hints
First, we need to read two arrays.
Iterate through arrays and compare elements. If the elements are not equal print the required message and break the loop.
Think about how to solve the other part of the problem.*/
using System;
using System.Linq;

namespace _07._Equal_Arrays;

class Program
{
    static void Main(string[] args)
    {
        int[] firstArrayOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] secondArrayOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int sum = 0;
        for (int i = 0; i < firstArrayOfNumbers.Length; i++)
        {
            if (firstArrayOfNumbers[i] != secondArrayOfNumbers[i])
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                return;
            }
            sum += firstArrayOfNumbers[i];
        }
        Console.WriteLine($"Arrays are identical. Sum: {sum}");
    }
}

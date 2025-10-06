/*Create a program that determines if an element exists in an array for which the sum of all elements to its left is equal to the sum of all elements to its right. If there are no elements to the left
or right, their sum is considered to be 0. Print the index of the element that satisfies the condition or "no" if there is no such element.*/
using System;
using System.Linq;

namespace _06._Equal_Sum;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for (int i = 0; i < numbers.Length; i++)
        {
            int leftSum = 0, rightSum = 0;
            for (int j = 0; j <= i; j++)
            {
                leftSum += numbers[j];
            }

            for (int j = numbers.Length - 1; j >= i; j--)
            {
                rightSum += numbers[j];
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine("no");
    }
}

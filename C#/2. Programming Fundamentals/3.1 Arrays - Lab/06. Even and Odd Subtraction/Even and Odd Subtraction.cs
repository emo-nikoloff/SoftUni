/*Create a program that calculates the difference between the sum of the even and the sum of the odd numbers in an array.
*Hints
First, we need to read the array.
We will need two variables – even and odd sum.
Iterate through all elements in the array with for loop.
Check the current number – if it is even, add it to the even sum, otherwise add It to the odd sum.
Print the difference.*/
using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int evenSum = 0, oddSum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                evenSum += numbers[i];
            }
            else if (numbers[i] % 2 != 0)
            {
                oddSum += numbers[i];
            }
        }
        Console.WriteLine(evenSum - oddSum);
    }
}

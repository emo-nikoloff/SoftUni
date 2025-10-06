/*Read n numbers and print them in reverse order, separated by a single space.
*Hints
First, we need to read n from the console.
Create an array of integers with n size.
Read n numbers using for loop.
Set number to the corresponding index.
Print the array in reversed order.*/
using System;

namespace _02._Print_Numbers_in_Reverse_Order;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());

        int[] numbers = new int[magicNumber];

        for (int i = 0; i < magicNumber; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        for (int i = magicNumber - 1; i > -1; i--)
        {
            Console.Write($"{numbers[i]} ");
        }
    }
}

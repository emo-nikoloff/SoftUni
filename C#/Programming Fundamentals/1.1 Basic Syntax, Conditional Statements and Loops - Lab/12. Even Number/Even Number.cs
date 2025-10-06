/*Create a program that reads a sequence of numbers. If the number is even, print its absolute value in the following format: "The number is: {number}" and terminate
 the program. If the number is odd, print "Please write an even number." and continue reading numbers.*/
using System;

namespace _12._Even_Number;

class Program
{
    static void Main(string[] args)
    {
        int number;
        while (true)
        {
            number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine($"The number is: {Math.Abs(number)}");
                break;
            }

            Console.WriteLine("Please write an even number.");
        }
    }
}
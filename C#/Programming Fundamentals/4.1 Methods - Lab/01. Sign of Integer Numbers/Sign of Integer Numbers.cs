/*A single integer is given, create a method that checks if the given number is positive, negative, or zero. As a result print:
· For positive number: "The number {number} is positive. "
· For negative number: "The number {number} is negative. "
· For zero number: "The number {number} is zero. "*/
using System;

namespace _01._Sign_of_Integer_Numbers;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());

        SignNumber(magicNumber);
    }

    static void SignNumber(int number)
    {
        if (number == 0)
        {
            Console.WriteLine($"The number {number} is zero.");
        }
        else if (number > 0)
        {
            Console.WriteLine($"The number {number} is positive.");
        }
        else
        {
            Console.WriteLine($"The number {number} is negative.");
        }
    }
}

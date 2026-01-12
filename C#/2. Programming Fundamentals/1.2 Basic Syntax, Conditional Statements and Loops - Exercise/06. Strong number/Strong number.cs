/*Write a program that receives a single integer and calculates if it's strong or not. A number is strong, if the sum of the factorials of each
digit is equal to the number itself.
Example: 145 is a strong number, because 1! + 4! + 5! = 145.
Print "yes", if the number is strong and "no", if the number is not strong*/
using System;

namespace _06._Strong_number;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());

        int initialNumber = magicNumber;
        int sum = 0;
        while (magicNumber > 0)
        {
            int lastDigit = magicNumber % 10;
            magicNumber /= 10;

            int factorial = 1;
            for (int i = 1; i <= lastDigit; i++)
            {
                factorial *= i;
            }

            sum += factorial;
        }

        if (sum == initialNumber)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}

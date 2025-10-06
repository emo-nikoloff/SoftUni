/*A number is special when its sum of digits is 5, 7 or 11.
Write a program to read an integer n and for all numbers in the range 1…n to print the number and if it is special or not (True / False).
*Hints
To calculate the sum of digits of given number num, you might repeat the following: sum the last digit (num % 10) and remove it (num = num / 10)
until num reaches 0.*/
using System;

namespace _05._Special_Numbers;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());

        for (int number = 1; number <= magicNumber; number++)
        {
            int firstDigit = number / 10;
            int lastDigit = number % 10;
            int specialNumber = firstDigit + lastDigit;

            bool isSpecialNumber = specialNumber == 5 || specialNumber == 7 || specialNumber == 11;

            if (isSpecialNumber)
            {
                Console.WriteLine($"{number} -> True");
                continue;
            }
            Console.WriteLine($"{number} -> False");
        }
    }
}

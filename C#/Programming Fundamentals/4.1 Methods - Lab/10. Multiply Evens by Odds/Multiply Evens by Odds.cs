/*Create a program that multiplies the sum of all even digits of a number by the sum of all odd digits of the same number:
· Create a method called GetMultipleOfEvenAndOdds()
· Create a method GetSumOfEvenDigits()
· Create GetSumOfOddDigits()
· You may need to use Math.Abs() for negative numbers*/
using System;

namespace _10._Multiply_Evens_by_Odds;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = Math.Abs(int.Parse(Console.ReadLine()));

        int magicResult = GetMultipleOfEvenAndOdds(magicNumber);
        Console.WriteLine(magicResult);
    }

    static int GetSumOfEvenDigits(int number)
    {
        int evenSum = 0;
        while (number > 0)
        {
            int lastDigit = number % 10;
            if (lastDigit % 2 == 0)
            {
                evenSum += lastDigit;
            }
            number /= 10;
        }
        return evenSum;
    }
    static int GetSumOfOddDigits(int number)
    {
        int oddSum = 0;
        while (number > 0)
        {
            int lastDigit = number % 10;
            if (lastDigit % 2 != 0)
            {
                oddSum += lastDigit;
            }
            number /= 10;
        }
        return oddSum;
    }

    static int GetMultipleOfEvenAndOdds(int number)
    {
        int result = GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
        return result;
    }
}

/*A top number is an integer that holds the following properties:
· Its sum of digits is divisible by 8, e.g. 8, 17, 88
· Holds at least one odd digit, e.g. 232, 707, 87578
· Some examples of top numbers are: 17, 161, 251, 4310, 123200
Create a program to print all top numbers in the range [1…n].
You will receive a single integer from the console, representing the end value.*/
using System;

namespace _10._Top_Number;

class Program
{
    static void Main(string[] args)
    {
        int range = int.Parse(Console.ReadLine());
        for (int number = 17; number <= range; number++)
        {
            if (IsTopNumber(number))
            {
                Console.WriteLine(number);
            }
        }
    }

    static bool IsDivisibleByEight(int number)
    {
        int sumDigits = 0;
        while (number > 0)
        {
            int lastDigit = number % 10;
            sumDigits += lastDigit;
            number /= 10;
        }

        if (sumDigits % 8 == 0)
        {
            return true;
        }
        return false;
    }

    static bool HasOddDigit(int number)
    {
        while (number > 0)
        {
            int lastDigit = number % 10;
            if (lastDigit % 2 != 0)
            {
                return true;
            }
            number /= 10;
        }
        return false;
    }

    static bool IsTopNumber(int number)
    {
        if (IsDivisibleByEight(number) && HasOddDigit(number))
        {
            return true;
        }
        return false;
    }
}

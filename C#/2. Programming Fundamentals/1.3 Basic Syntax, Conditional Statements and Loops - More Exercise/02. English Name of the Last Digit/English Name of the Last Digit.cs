/*Create a method that returns the English spelling of the last digit of a given number. Write a program that reads an integer and prints the
returned value from this method.*/
using System;

namespace _02._English_Name_of_the_Last_Digit;

class Program
{
    static string LastDigitSpelling(int number)
    {
        int lastDigit = Math.Abs(number) % 10;
        switch (lastDigit)
        {
            case 0:
                return "zero";
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            case 9:
                return "nine";
            default:
                return "unknown";
        }
    }

    static void Main(string[] args)
    {
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            Console.WriteLine(LastDigitSpelling(number));
        }
    }
}

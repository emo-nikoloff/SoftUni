/*You are given a number num1, num2 and num3. Write a program that finds if num1 * num2 * num3 (the product) is negative, positive or zero. Try to do this WITHOUT multiplying the 3 numbers.*/
using System;

namespace _05._Multiplication_Sign;

class Program
{
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());

        string productSign = GetSign(firstNumber, secondNumber, thirdNumber);
        Console.WriteLine(productSign);
    }

    static string GetSign(int firstNumber, int secondNumber, int thirdNumber)
    {
        if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
        {
            return "zero";
        }

        int counterNegative = 0;
        if (firstNumber < 0)
        {
            counterNegative++;
        }
        if (secondNumber < 0)
        {
            counterNegative++;
        }
        if (thirdNumber < 0)
        {
            counterNegative++;
        }

        if (counterNegative % 2 == 0)
        {
            return "positive";
        }
        return "negative";
    }
}
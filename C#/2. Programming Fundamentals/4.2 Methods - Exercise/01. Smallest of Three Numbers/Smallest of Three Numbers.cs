/*Create a method that prints out the smallest of three integer numbers.*/
using System;

namespace _01._Smallest_of_Three_Numbers;

class Program
{
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());

        int smallestNumber = GetSmallestNumber(firstNumber, secondNumber);
        smallestNumber = GetSmallestNumber(smallestNumber, thirdNumber);

        Console.WriteLine(smallestNumber);
    }

    static int GetSmallestNumber(int firstNumber, int secondNumber)
    {
        if (firstNumber < secondNumber)
        {
            return firstNumber;
        }
        else
        {
            return secondNumber;
        }
    }
}

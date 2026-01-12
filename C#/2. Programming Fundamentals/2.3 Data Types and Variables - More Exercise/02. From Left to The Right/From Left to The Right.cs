/*You will receive a number that represents how many lines we will get as input. On the next N lines, you will receive a string with 2 numbers, separated by a single space. You need to compare them.
If the left number is greater than the right number, you need to print the sum of all digits in the left number, otherwise, print the sum of all digits in the right number.*/
using System;

namespace _02._From_Left_to_The_Right;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());

        for (int line = 1; line <= lines; line++)
        {
            string twoNumbers = Console.ReadLine();
            string[] parts = twoNumbers.Split(' ');

            long firstNumber = long.Parse(parts[0]);
            long secondNumber = long.Parse(parts[1]);

            long sumDigits = 0;
            if (firstNumber > secondNumber)
            {
                firstNumber = Math.Abs(firstNumber);
                while (firstNumber > 0)
                {
                    long lastDigit = firstNumber % 10;
                    firstNumber /= 10;
                    sumDigits += lastDigit;
                }
            }
            else
            {
                secondNumber = Math.Abs(secondNumber);
                while (secondNumber > 0)
                {
                    long lastDigit = secondNumber % 10;
                    secondNumber /= 10;
                    sumDigits += lastDigit;
                }
            }
            Console.WriteLine(sumDigits);
        }
    }
}

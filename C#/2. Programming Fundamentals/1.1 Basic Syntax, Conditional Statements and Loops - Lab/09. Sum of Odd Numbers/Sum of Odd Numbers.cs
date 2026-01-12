/*Create a program that prints on a new line the next n odd numbers (starting from 1). On the last row print the sum of all n odd numbers.
A single number n is read from the console, indicating how many odd numbers need to be printed.
Print the next n odd numbers, starting from 1, separated by new lines. On the last line, print the sum of these numbers.
· n will be in the interval [1…100]*/
using System;

namespace _09._Sum_of_Odd_Numbers;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber;
        while (true)
        {
            magicNumber = int.Parse(Console.ReadLine());
            if (magicNumber > 1 || magicNumber < 100)
            {
                break;
            }

            Console.WriteLine("Try again!");
        }

        int oddNumber = 1;
        int sum = 0;
        int counter = 0;
        while (counter < magicNumber)
        {
            if (oddNumber % 2 != 0)
            {
                sum += oddNumber;
                Console.WriteLine(oddNumber);
                counter++;
            }

            oddNumber++;
        }

        Console.WriteLine($"Sum: {sum}");
    }
}
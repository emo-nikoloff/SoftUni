/*Create a program that receives an integer as an input. Print the 10 times table for this integer. See the examples below for more information.
Print every row of the table in the following format:
{theInteger} X {times} = {product}
· The integer will be in the interval [1…100]*/
using System;

namespace _10._Multiplication_Table;

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

        for (int multiplier = 1; multiplier <= 10; multiplier++)
        {
            Console.WriteLine($"{magicNumber} X {multiplier} = {magicNumber * multiplier}");
        }
    }
}
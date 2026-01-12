/*Rewrite the program from the previous task so it can receive the multiplier from the console. Print the table with the multiplier in the interval from the given number
to 10. If the given multiplier is more than 10, print only one row with the integer, the given multiplier, and the product. See the examples below for more information.
Print every row of the table in the following format:
{theInteger} X {times} = {product}
· The integer will be in the interval [1…100]*/
using System;

namespace _11._Multiplication_Table_2._0;

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

        int multiplier = int.Parse(Console.ReadLine());

        if (multiplier <= 10)
        {
            for (; multiplier <= 10; multiplier++)
            {
                Console.WriteLine($"{magicNumber} X {multiplier} = {magicNumber * multiplier}");
            }
        }
        else
        {
            Console.WriteLine($"{magicNumber} X {multiplier} = {magicNumber * multiplier}");
        }
    }
}
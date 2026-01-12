/*Create a program to enter n numbers and calculate and print their exact sum (without rounding)
*Hints
Use Decimal to not lose precision.*/
using System;

namespace _03._Exact_Sum_of_Real_Numbers;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());

        decimal sum = 0;
        for (int i = 0; i < magicNumber; i++)
        {
            decimal number = decimal.Parse(Console.ReadLine());
            sum += number;
        }
        Console.WriteLine(sum);
    }
}

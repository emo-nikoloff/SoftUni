/*Write a program, which receives a number – n and prints a triangle from 1 to n.
· n will be in the interval [1...20].*/
using System;

namespace _08._Triangle_of_Numbers;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber;
        while (true)
        {
            magicNumber = int.Parse(Console.ReadLine());
            if (magicNumber >= 1 && magicNumber <= 20)
            {
                break;
            }
            Console.WriteLine("Try again!");
        }

        for (int i = 1; i <= magicNumber; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}

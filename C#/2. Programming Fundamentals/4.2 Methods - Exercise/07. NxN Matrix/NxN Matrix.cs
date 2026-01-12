/*Create a method that receives a single integer n and prints an NxN matrix using this number as a filler.*/
using System;

namespace _07._NxN_Matrix;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());

        Matrix(magicNumber);
    }

    static void Matrix(int number)
    {
        for (int i = 1; i <= number; i++)
        {
            for (int j = 1; j <= number; j++)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}

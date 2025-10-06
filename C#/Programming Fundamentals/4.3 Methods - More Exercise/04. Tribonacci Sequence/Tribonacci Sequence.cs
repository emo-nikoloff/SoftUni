/*In the "Tribonacci" sequence, every number is formed by the sum of the previous 3 numbers.
You are given a number num. Write a program that prints num numbers from the Tribonacci sequence, on a single line, starting from 1. The input comes as a parameter named num. The value num will always
be a positive integer.*/
using System;

namespace _04._Tribonacci_Sequence;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        int[] result = Tribonacci(number);
        Console.WriteLine(string.Join(" ", result));
    }

    static int[] Tribonacci(int number)
    {
        int[] numbers = new int[number];
        if (number == 0)
        {
            return numbers;
        }

        if (number >= 1)
        {
            numbers[0] = 1;
        }
        if (number >= 2)
        {
            numbers[1] = 1;
        }
        if (number >= 3)
        {
            numbers[2] = 2;
        }

        for (int i = 3; i < number; i++)
        {
            numbers[i] = numbers[i - 1] + numbers[i - 2] + numbers[i - 3];
        }
        return numbers;
    }
}


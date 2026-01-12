/*Create a program that receives three real numbers and sorts them in descending order. Print each number on a new line.*/
using System;

namespace _01._Sort_Numbers;

class Program
{
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());

        int[] numbers = { firstNumber, secondNumber, thirdNumber };
        Array.Sort(numbers);
        Array.Reverse(numbers);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
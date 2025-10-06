/*Create a program to find all the top integers in an array. A top integer is an integer that is greater than all the elements to its right.*/
using System;
using System.Linq;

namespace _05._Top_Integers;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for (int i = 0; i < numbers.Length; i++)
        {
            bool isGeater = true;
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] <= numbers[j])
                {
                    isGeater = false;
                    break;
                }
            }

            if (isGeater)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}

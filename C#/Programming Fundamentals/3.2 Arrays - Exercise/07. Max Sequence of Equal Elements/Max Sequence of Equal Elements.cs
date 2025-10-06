/*Create a program that finds the longest sequence of equal elements in an array of integers. If several equal sequences are present in the array, print out the leftmost one.*/
using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int longestSequence = 0, counter = 1, index = 0;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] == numbers[i + 1])
            {
                counter++;
            }

            if (counter > longestSequence)
            {
                longestSequence = counter;
                index = i;
            }

            if (numbers[i] != numbers[i + 1])
            {
                counter = 1;
            }
        }

        for (int i = 1; i <= longestSequence; i++)
        {
            Console.Write($"{numbers[index]} ");
        }
    }
}

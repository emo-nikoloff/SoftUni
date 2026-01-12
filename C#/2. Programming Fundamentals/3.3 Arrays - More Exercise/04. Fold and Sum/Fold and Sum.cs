/*Read an array of 4*k integers, fold it like shown below, and print the sum of the upper and lower two rows (each holding 2*k integers):
*Hints
· Create the first row after folding: the first k numbers reversed, followed by the last k numbers reversed.
· Create the second row after folding: the middle 2*k numbers.
· Sum the first and the second rows.*/
using System;
using System.Linq;

namespace _04._Fold_and_Sum;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int k = numbers.Length / 4;

        int[] upperRow = new int[k];
        int[] lowerRow = new int[k];
        int[] firstRow = new int[k * 2];
        int[] secondRow = new int[k * 2];
        int[] resultNumbers = new int[k * 2];

        for (int i = 0; i < k; i++)
        {
            upperRow[i] = numbers[k - 1 - i];
            lowerRow[i] = numbers[numbers.Length - 1 - i];
        }

        for (int i = 0; i < k; i++)
        {
            firstRow[i] = upperRow[i];
            firstRow[i + k] = lowerRow[i];
        }

        for (int i = 0; i < k * 2; i++)
        {
            secondRow[i] = numbers[k + i];
        }

        for (int i = 0; i < k * 2; i++)
        {
            resultNumbers[i] = firstRow[i] + secondRow[i];
        }

        Console.WriteLine(string.Join(" ", resultNumbers));
    }
}

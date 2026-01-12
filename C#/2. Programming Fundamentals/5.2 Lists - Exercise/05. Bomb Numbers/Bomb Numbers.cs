/*Create a program that reads a sequence of numbers and a special bomb number holding a certain power. Your task is to detonate every occurrence of the special bomb number and according to its power
the numbers to its left and right. The bomb power refers to how many numbers to the left and right will be removed, no matter their values. Detonations are performed from left to right and all the
detonated numbers disappear. Finally, print the sum of the remaining elements in the sequence.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        int[] bombData = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int bombNumber = bombData[0], bombPower = bombData[1];

        while (numbers.Contains(bombNumber))
        {
            int bombIndex = numbers.IndexOf(bombNumber);

            int leftIndex = Math.Max(0, bombIndex - bombPower);
            int rightIndex = Math.Min(numbers.Count - 1, bombIndex + bombPower);

            int range = rightIndex - leftIndex + 1;
            numbers.RemoveRange(leftIndex, range);
        }
        Console.WriteLine(numbers.Sum());
    }
}

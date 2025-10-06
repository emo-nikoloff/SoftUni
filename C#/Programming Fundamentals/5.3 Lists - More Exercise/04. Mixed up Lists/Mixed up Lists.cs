/*Write a program that mixes up two lists by some rules. You will receive two lines of input, each one being a list of numbers. The mixing rules are:
· Start from the beginning of the first list and the ending of the second.
· Add element from the first and element from the second.
· In the end, there will always be a list, in which there are 2 elements are remaining.
· These elements will be the range of the elements you need to print.
· Loop through the result list and take only the elements that fulfill the condition.
· Print the elements ordered in ascending order and separated by a space.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists;

class Program
{
    static void Main(string[] args)
    {
        List<int> firstListNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<int> secondListNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();

        int neededLength = Math.Min(firstListNumbers.Count, secondListNumbers.Count);
        List<int> resultNumbers = new();

        for (int i = 0, j = secondListNumbers.Count - 1; i < neededLength && j >= 0; i++, j--)
        {
            resultNumbers.Add(firstListNumbers[i]);
            resultNumbers.Add(secondListNumbers[j]);
        }

        int lowerRange = 0, UpperRange = 0;
        if (firstListNumbers.Count > secondListNumbers.Count)
        {
            firstListNumbers.RemoveRange(0, neededLength);
            lowerRange = Math.Min(firstListNumbers[0], firstListNumbers[1]);
            UpperRange = Math.Max(firstListNumbers[0], firstListNumbers[1]);
        }
        else if (firstListNumbers.Count < secondListNumbers.Count)
        {
            secondListNumbers.RemoveRange(secondListNumbers.Count - neededLength, neededLength);
            lowerRange = Math.Min(secondListNumbers[0], secondListNumbers[1]);
            UpperRange = Math.Max(secondListNumbers[0], secondListNumbers[1]);
        }

        resultNumbers.RemoveAll(number => number <= lowerRange || number >= UpperRange);
        resultNumbers.Sort();

        Console.WriteLine(string.Join(" ", resultNumbers));
    }
}

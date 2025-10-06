/*Read a list of integers and print them in ascending order, along with their number of occurrences.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers;

class Program
{
    static void Main(string[] args)
    {
        double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
        SortedDictionary<double, int> numbersCounts = new();

        foreach (double number in numbers)
        {
            if (numbersCounts.ContainsKey(number))
            {
                numbersCounts[number]++;
                continue;
            }
            numbersCounts.Add(number, 1);
        }

        foreach (KeyValuePair<double, int> numberCount in numbersCounts)
        {
            Console.WriteLine($"{numberCount.Key} -> {numberCount.Value}");
        }
    }
}

/*Create a program that extracts all elements from a given sequence of words that are present in it an odd number of times (case-insensitive).
· Words are given on a single line, space-separated.
· Print the result elements in lowercase, in their order of appearance.*/
using System;
using System.Collections.Generic;

namespace _02._Odd_Occurrences;

class Program
{
    static void Main(string[] args)
    {
        string[] words = Console.ReadLine().Split();
        Dictionary<string, int> wordsCounts = new();

        foreach (string word in words)
        {
            string loweredWord = word.ToLower();
            if (wordsCounts.ContainsKey(loweredWord))
            {
                wordsCounts[loweredWord]++;
                continue;
            }
            wordsCounts.Add(loweredWord, 1);
        }

        foreach (KeyValuePair<string, int> wordCount in wordsCounts)
        {
            int counter = wordCount.Value;
            if (counter % 2 != 0)
            {
                Console.Write(wordCount.Key + " ");
            }
        }
    }
}

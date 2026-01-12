/*Create a program that counts all characters in a string, except for space (' ').
Print all the occurrences in the following format:
"{char} -> {occurrences}"*/
using System;
using System.Collections.Generic;

namespace Test_Field;

class Program
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine();
        Dictionary<char, int> charsCount = new();

        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == ' ')
            {
                continue;
            }

            if (charsCount.ContainsKey(word[i]))
            {
                charsCount[word[i]]++;
                continue;
            }
            charsCount.Add(word[i], 1);
        }

        foreach ((char letter, int count) in charsCount)
        {
            Console.WriteLine($"{letter} -> {count}");
        }
    }
}

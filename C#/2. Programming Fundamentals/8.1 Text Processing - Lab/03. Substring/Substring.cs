/*On the first line, you will receive a string. On the second line, you will receive a second string. Create a program that removes all of the occurrences of the first string in the second, until
there is no match. At the end print the remaining string.*/
using System;

namespace _03._Substring;

class Program
{
    static void Main(string[] args)
    {
        string wordToRemove = Console.ReadLine();
        string word = Console.ReadLine();

        while (word.Contains(wordToRemove))
        {
            int wordToRemoveIndex = word.IndexOf(wordToRemove);
            word = word.Remove(wordToRemoveIndex, wordToRemove.Length);
        }

        Console.WriteLine(word);
    }
}

/*Create a program that takes a text and a string of banned words. All words included in the ban list should be replaced with a string of asterisks '*', whose length must be equal to the word's length.
The entries in the ban list will be separated by a comma and space ", ". The ban list should be entered on the first input line and the text on the second input line.*/
using System;

namespace _04._Text_Filter;

class Program
{
    static void Main(string[] args)
    {
        string[] bannedWords = Console.ReadLine().Split(", ");
        string text = Console.ReadLine();

        foreach (string bannedWord in bannedWords)
        {
            string replacement = new string('*', bannedWord.Length);

            text = text.Replace(bannedWord, replacement);
        }

        Console.WriteLine(text);
    }
}

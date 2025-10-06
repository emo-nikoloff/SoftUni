/*You will be given a series of strings, until you receive an "end" command. Write a program that reverses strings and prints each pair on a separate line in the format "{word} = {reversed word}".*/
using System;

namespace _01._Reverse_Strings;

class Program
{
    static void Main(string[] args)
    {
        string input = string.Empty;

        while ((input = Console.ReadLine()) != "end")
        {
            string reversedWord = Reversed(input);
            Console.WriteLine($"{input} = {reversedWord}");
        }
    }

    static string Reversed(string word)
    {
        string reversed = string.Empty;

        for (int i = word.Length - 1; i >= 0; i--)
        {
            reversed += word[i];
        }

        return reversed;
    }
}

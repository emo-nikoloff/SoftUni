/*Create a program that reads a string from the console and replaces any sequence of the same letter with a single corresponding letter.*/
using System;

namespace _06._Replace_Repeating_Chars;

class Program
{
    static void Main(string[] args)
    {
        string sequence = Console.ReadLine();

        string finalSequence = string.Empty;

        for (int i = 0; i < sequence.Length - 1; i++)
        {
            if (sequence[i] != sequence[i + 1])
            {
                finalSequence += sequence[i];
            }
        }

        if (sequence.Length > 0)
        {
            finalSequence += sequence[sequence.Length - 1];
        }

        Console.WriteLine(finalSequence);
    }
}

/*Create a program that translates messages from Morse code to English (capital letters). Use this page to help you (without the numbers). The words will be separated by a space (' '). There will be a
'|' character which you should replace with ' ' (space).*/
using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Morse_Code_Translator;

class Program
{
    static void Main(string[] args)
    {
        string morseText = Console.ReadLine();

        string[] morseParts = morseText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, char> morseToLetters = new()
        {
            { ".-", 'A' },
            { "-...", 'B' },
            { "-.-.", 'C' },
            { "-..", 'D' },
            { ".", 'E' },
            { "..-.", 'F' },
            { "--.", 'G' },
            { "....", 'H' },
            { "..", 'I' },
            { ".---", 'J' },
            { "-.-", 'K' },
            { ".-..", 'L' },
            { "--", 'M' },
            { "-.", 'N' },
            { "---", 'O' },
            { ".--.", 'P' },
            { "--.-", 'Q' },
            { ".-.", 'R' },
            { "...", 'S' },
            { "-", 'T' },
            { "..-", 'U' },
            { "...-", 'V' },
            { ".--", 'W' },
            { "-..-", 'X' },
            { "-.--", 'Y' },
            { "--..", 'Z' },
        };

        StringBuilder realText = new();

        foreach (string morsePart in morseParts)
        {
            if (morseToLetters.ContainsKey(morsePart))
            {
                realText.Append(morseToLetters[morsePart]);
            }
            else
            {
                realText.Append(' ');
            }
        }

        Console.WriteLine(realText);
    }
}

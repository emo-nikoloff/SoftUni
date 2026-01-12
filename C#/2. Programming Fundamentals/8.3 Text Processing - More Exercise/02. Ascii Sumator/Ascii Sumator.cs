/*Create a program that prints a sum of all characters between two given characters (their ASCII code). On the first line, you will get a character. On the second line, you get another character.
On the last line, you get a random string. Find all the characters between the two given and print their ASCII sum.*/
using System;

namespace _02._Ascii_Sumator;

class Program
{
    static void Main(string[] args)
    {
        char startSymbol = char.Parse(Console.ReadLine());
        char endSymbol = char.Parse(Console.ReadLine());
        string str = Console.ReadLine();

        int charsSum = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] > startSymbol && str[i] < endSymbol)
            {
                charsSum += str[i];
            }
        }

        Console.WriteLine(charsSum);
    }
}

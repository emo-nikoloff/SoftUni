/*Create a program that receives a single string and prints all the digits on the first line, on the second – all the letters, and on the third – all the other characters. There will always be at least
one digit, one letter and one other character.*/
using System;

namespace _05._Digits__Letters_and_Other;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        string digits = string.Empty;
        string letters = string.Empty;
        string symbols = string.Empty;

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                digits += input[i];
            }
            else if (char.IsLetter(input[i]))
            {
                letters += input[i];
            }
            else
            {
                symbols += input[i];
            }
        }

        Console.WriteLine(digits);
        Console.WriteLine(letters);
        Console.WriteLine(symbols);
    }
}

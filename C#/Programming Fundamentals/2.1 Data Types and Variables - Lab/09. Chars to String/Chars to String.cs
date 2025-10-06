/*Create a program that reads 3 lines of input. On each line, you get a single character. Combine all the characters into one string and print it
on the console.*/
using System;

namespace _09._Chars_to_String;

class Program
{
    static void Main(string[] args)
    {
        char firstChar = char.Parse(Console.ReadLine());
        char secondChar = char.Parse(Console.ReadLine());
        char thirdChar = char.Parse(Console.ReadLine());
        string allChars = string.Empty;

        allChars += firstChar;
        allChars += secondChar;
        allChars += thirdChar;

        Console.WriteLine(allChars);
    }
}

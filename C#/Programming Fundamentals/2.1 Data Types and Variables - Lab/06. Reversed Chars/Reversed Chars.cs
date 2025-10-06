/*Create a program that takes 3 lines of characters and prints them in reversed order with a space between them.*/
using System;

namespace _06._Reversed_Chars;

class Program
{
    static void Main(string[] args)
    {
        char firstChar = char.Parse(Console.ReadLine());
        char secondChar = char.Parse(Console.ReadLine());
        char thirdChar = char.Parse(Console.ReadLine());

        Console.WriteLine($"{thirdChar} {secondChar} {firstChar}");
    }
}

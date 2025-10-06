/*You will receive a single string. Create a method that prints the character found at its middle. If the length of the string is even, there are two middle characters.*/
using System;

namespace _06._Middle_Characters;

class Program
{
    static void Main(string[] args)
    {
        string @string = Console.ReadLine();

        string middleCharacter = GetMiddleCharacter(@string);
        Console.WriteLine(middleCharacter);
    }

    static string GetMiddleCharacter(string str)
    {
        int middleIndex = str.Length / 2;
        string result = $"{str[middleIndex]}";

        if (str.Length % 2 == 0)
        {
            result = $"{str[middleIndex - 1]}" + result;
        }
        return result;
    }
}

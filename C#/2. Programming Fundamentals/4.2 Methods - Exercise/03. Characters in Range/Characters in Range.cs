/*Create a method that receives two characters and prints all the characters between them according to ASCII (on a single line).
NOTE: If the second letter's ASCII value is less than that of the first one, then the two initial letters should be swapped.*/
using System;

namespace _03._Characters_in_Range;

class Program
{
    static void Main(string[] args)
    {
        char firstChar = char.Parse(Console.ReadLine());
        char secondChar = char.Parse(Console.ReadLine());

        GetCharsInRange(firstChar, secondChar);
    }

    static void GetCharsInRange(char firstChar, char secondChar)
    {
        if (firstChar < secondChar)
        {
            while (firstChar < secondChar - 1)
            {
                firstChar++;
                Console.Write(firstChar + " ");
            }
        }
        else if (firstChar > secondChar)
        {
            while (secondChar < firstChar - 1)
            {
                secondChar++;
                Console.Write(secondChar + " ");
            }
        }
    }
}

/*Create a method that receives two parameters:
· A string
· A number n (integer) represents how many times the string will be repeated
The method should return a new string, containing the initial one, repeated n times without space.
*Hints
1. First, read the string and the repeat count n
2. Then create the method and pass the variables to it
3. In the main method, print the result*/
using System;

namespace _07._Repeat_String;

class Program
{
    static void Main(string[] args)
    {
        string str = Console.ReadLine();
        int repeat = int.Parse(Console.ReadLine());

        string repeatedString = RepeatString(str, repeat);
        Console.WriteLine(repeatedString);
    }

    static string RepeatString(string word, int count)
    {
        string result = string.Empty;
        for (int i = 0; i < count; i++)
        {
            result += word;
        }
        return result;
    }
}

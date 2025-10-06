/*Create a program which reverses a string and prints it on the console.*/
using System;

namespace _04._Reverse_String;

class Program
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine();

        for (int i = word.Length - 1; i > -1; i--)
        {
            Console.Write(word[i]);
        }
    }
}

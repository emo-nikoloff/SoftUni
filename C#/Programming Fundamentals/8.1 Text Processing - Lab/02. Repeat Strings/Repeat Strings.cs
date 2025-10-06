/*Create a program that reads an array of strings. Each string is repeated N times, where N is the length of the string. Print the concatenated string.*/
using System;

namespace _02._Repeat_Strings;

class Program
{
    static void Main(string[] args)
    {
        string[] strArray = Console.ReadLine().Split();

        for (int i = 0; i < strArray.Length; i++)
        {
            string word = strArray[i];

            for (int j = 0; j < word.Length; j++)
            {
                Console.Write(word);
            }
        }
    }
}

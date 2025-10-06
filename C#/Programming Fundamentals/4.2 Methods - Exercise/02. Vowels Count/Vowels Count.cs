/*Create a method that receives a single string and prints out the number of vowels contained in it.*/
using System;

namespace _02._Vowels_Count;

class Program
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine();

        GetVowels(word);
    }

    static void GetVowels(string word)
    {
        int counter = 0;
        foreach (char letter in word)
        {
            if ("aeiouAEIOU".Contains(letter))
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}

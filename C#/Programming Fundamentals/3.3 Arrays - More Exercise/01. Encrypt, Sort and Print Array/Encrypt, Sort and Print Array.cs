/*Write a program that reads a sequence of strings from the console. Encrypt every string by summing:
· The code of each vowel multiplied by the string length
· The code of each consonant divided by the string length
Sort the number sequence in ascending order and print it in the console.
On the first line, you will always receive the number of strings you have to read.*/
using System;

namespace _01._Encrypt__Sort_and_Print_Array;

class Program
{
    static void Main(string[] args)
    {
        int strings = int.Parse(Console.ReadLine());

        int[] results = new int[strings];
        for (int i = 0; i < strings; i++)
        {
            string word = Console.ReadLine();

            int sum = 0;
            foreach (char letter in word)
            {
                if ("aeiouAEIOU".Contains(letter))
                {
                    int vowel = letter * word.Length;
                    sum += vowel;
                }
                else
                {
                    int consonant = letter / word.Length;
                    sum += consonant;
                }
            }
            results[i] = sum;
        }
        Array.Sort(results);
        for (int i = 0; i < results.Length; i++)
        {
            Console.WriteLine(results[i]);
        }
    }
}

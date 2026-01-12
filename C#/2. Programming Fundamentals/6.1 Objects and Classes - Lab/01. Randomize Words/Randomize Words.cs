/*You will be given a string that will contain words separated by a single space. Randomize their order and print each word on a new line.
*Hints
· Split the input string by (space) and create an array of words.
· Create a random number generator – an object rnd of type Random.
· In a for loop exchange each number at positions 0, 1,…,words.Length-1 by a number at random position. To generate a random number in range use rnd.Next(minValue, maxValue). Note that by definition
minValue is inclusive, but maxValue is exclusive.
· Print each word in the array on new line.*/
using System;

namespace _01._Randomize_Words;

class Program
{
    static void Main(string[] args)
    {
        string[] words = Console.ReadLine().Split();

        Random random = new();

        for (int i = 0; i < words.Length; i++)
        {
            int randomIndex = random.Next(0, words.Length);

            Swap(i, randomIndex, words);
        }

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }

    static void Swap(int firstIndex, int secondIndex, string[] words)
    {
        string temp = words[firstIndex];
        words[firstIndex] = words[secondIndex];
        words[secondIndex] = temp;
    }
}

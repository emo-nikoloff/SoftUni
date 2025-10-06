/*Create a method that takes two strings as arguments and returns the sum of their character codes multiplied. Multiply str1[0] with str2[0] and add to the total sum. Then continue with the next two
characters. If one of the strings is longer than the other, add the remaining character codes to the total sum without multiplication.*/
using System;

namespace _02._Character_Multiplier;

class Program
{
    static void Main(string[] args)
    {
        string[] strings = Console.ReadLine().Split();

        string firstString = strings[0];
        string secondString = strings[1];

        int result = SumCharsOfStrings(firstString, secondString);
        Console.WriteLine(result);
    }

    static int SumCharsOfStrings(string first, string second)
    {
        int totalSum = 0;
        int minLength = Math.Min(first.Length, second.Length);

        for (int i = 0; i < minLength; i++)
        {
            totalSum += first[i] * second[i];
        }

        string longerString = GetLongerString(first, second);

        for (int i = minLength; i < longerString.Length; i++)
        {
            totalSum += longerString[i];
        }

        return totalSum;
    }

    static string GetLongerString(string first, string second)
    {
        return first.Length > second.Length ? first : second;
    }
}

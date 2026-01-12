/*You will be given a list of numbers and a string. For each element of the list you must calculate the sum of its digits and take the element, corresponding to that index from the text. If the index
is greater than the length of the text, start counting from the beginning (so that you always have a valid index). After you get that element from the text, you must remove the character you have
taken from it (so for the next index the text will be with one characterless).*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Messaging;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        string @string = Console.ReadLine();

        int stringLength = @string.Length;
        string result = string.Empty;

        for (int i = 0; i < numbers.Count; i++)
        {
            int number = numbers[i];
            int sumDigits = 0;

            while (number > 0)
            {
                int lastDigit = number % 10;
                sumDigits += lastDigit;
                number /= 10;
            }

            int index = sumDigits % stringLength;
            char removedChar = @string[index];

            @string = @string.Remove(index, 1);
            result += removedChar;
        }
        Console.WriteLine(result);
    }
}

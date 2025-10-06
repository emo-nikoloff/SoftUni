/*Create a program that reads positive integers until you receive the "END" command. For each number, print whether the number is a palindrome or not. A palindrome is a number that reads the same
backward as forward, such as 323 or 1001.*/
using System;

namespace _09._Palindrome_Integers;

class Program
{
    static void Main(string[] args)
    {
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            bool isPalindrome = PalindromeCheck(input);
            Console.WriteLine(isPalindrome.ToString().ToLower());
        }
    }

    static bool PalindromeCheck(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == input[input.Length - 1 - i])
            {
                continue;
            }
            return false;
        }
        return true;
    }
}

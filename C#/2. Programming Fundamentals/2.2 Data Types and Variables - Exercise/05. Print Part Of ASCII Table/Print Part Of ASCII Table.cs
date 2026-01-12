/*Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints part of the ASCII table of characters at the console. On the first line
of input, you will receive the char index you should start with, and on the second line - the index of the last character you should print.*/
using System;

namespace _05._Print_Part_Of_ASCII_Table;

class Program
{
    static void Main(string[] args)
    {
        int startingCharPosition = int.Parse(Console.ReadLine());
        int endingCharPosition = int.Parse(Console.ReadLine());

        while (startingCharPosition <= endingCharPosition)
        {
            char symbol = (char)startingCharPosition;
            Console.Write($"{symbol} ");
            startingCharPosition++;
        }
    }
}

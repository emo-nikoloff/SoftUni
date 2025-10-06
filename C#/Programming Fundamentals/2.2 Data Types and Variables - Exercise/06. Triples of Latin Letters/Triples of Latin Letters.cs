/*Create a program that receives an integer n and print all triples of the first n small Latin letters, ordered alphabetically.
*Hints
Perform 3 nested loops from 0 to n-1.
For each iteration generate new letters.*/
using System;

namespace _06._Triples_of_Latin_Letters;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < magicNumber; i++)
        {
            for (int j = 0; j < magicNumber; j++)
            {
                for (int k = 0; k < magicNumber; k++)
                {
                    char firstChar = (char)('a' + i);
                    char secondChar = (char)('a' + j);
                    char thirdChar = (char)('a' + k);

                    Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                }
            }
        }
    }
}

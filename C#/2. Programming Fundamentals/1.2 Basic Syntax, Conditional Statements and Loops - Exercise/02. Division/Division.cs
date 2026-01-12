/*You will be given an integer, write a program which checks if the given integer is divisible by 2 or 3, or 6, or 7, or 10 without a remainder.
You should always take the bigger division:
· If the number is divisible by both 2, 3, and 6, you should print the division by 6 only.
· If a number is divisible by 2 and 10, you should print the division by 10.
If the number is not divisible by any of the given numbers, print "Not divisible". Otherwise, print "The number is divisible by {number}".*/
using System;

namespace _02._Division;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());
        if (magicNumber % 10 == 0)
        {
            Console.WriteLine("The number is divisible by 10");
        }
        else if (magicNumber % 7 == 0)
        {
            Console.WriteLine("The number is divisible by 7");
        }
        else if (magicNumber % 6 == 0)
        {
            Console.WriteLine("The number is divisible by 6");
        }
        else if (magicNumber % 3 == 0)
        {
            Console.WriteLine("The number is divisible by 3");
        }
        else if (magicNumber % 2 == 0)
        {
            Console.WriteLine("The number is divisible by 2");
        }
        else
        {
            Console.WriteLine("Not divisible");
        }
    }
}

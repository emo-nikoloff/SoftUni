/*You are given a program that checks if numbers in a given range [2...N] are prime. For each number is printed "{number} -> {true or false}". The code, however, is not very well written.
Your job is to modify it in a way that is easy to read and understand.

Sample Code:
int ___Do___ = int.Parse(Console.ReadLine());
for (int takoa = 2; takoa <= ___Do___; takoa++)
    {
        bool takovalie = true;
        for (int cepitel = 2; cepitel < takoa; cepitel++)
        {
            if (takoa % cepitel == 0)
            {
                takovalie = false;
                break;
            }
        }
        Console.WriteLine("{0} -> {1}", takoa, takovalie);
    }*/
using System;

namespace _04._Refactoring___Prime_Checker;

class Program
{
    static void Main(string[] args)
    {
        int limiter = int.Parse(Console.ReadLine());

        for (int number = 2; number <= limiter; number++)
        {
            bool isPrime = true;
            for (int divider = 2; divider < number; divider++)
            {
                if (number % divider == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            Console.WriteLine("{0} -> {1}", number, isPrime.ToString().ToLower());
        }
    }
}

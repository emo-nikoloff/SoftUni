/*You will receive a number N in the range [0…1000]. Calculate the Factorial of N and print out the result.
*Hints
Use the class BigInteger from the built-in .NET library System.Numerics.dll.
1. Import the namespace "System.Numerics".
2. Use the type BigInteger to calculate the number factorial.
3. Loop from 2 to N and multiply every number with factorial.*/
using System;
using System.Numerics;

namespace _02._Big_Factorial;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());

        BigInteger factorial = 1;

        for (int i = 2; i <= magicNumber; i++)
        {
            factorial *= i;
        }

        Console.WriteLine(factorial);
    }
}

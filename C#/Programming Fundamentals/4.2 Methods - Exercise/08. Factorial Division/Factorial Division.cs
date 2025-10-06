/*Read two integers. Calculate the factorial of each number. Divide the first result by the second and print the result of the division formatted to the second decimal point.*/
using System;

namespace _08._Factorial_Division;

class Program
{
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        double result = Factorial(firstNumber) / Factorial(secondNumber);
        Console.WriteLine($"{result:f2}");
    }

    static double Factorial(int number)
    {
        double result = 1;
        for (int i = number; i >= 1; i--)
        {
            result *= i;
        }
        return result;
    }
}

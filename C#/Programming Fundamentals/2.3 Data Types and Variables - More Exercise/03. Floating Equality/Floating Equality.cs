/*Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001. Note that we cannot directly compare two floating-point numbers a and b by a == b, because of the
nature of the floating- point arithmetic. Therefore, we assume two numbers are equal if they are more close to each other than some fixed constant eps.
You will receive two lines, each containing a floating-point number. Your task is to compare the values of the two numbers.*/
using System;

namespace _03._Floating_Equality;

class Program
{
    static void Main(string[] args)
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());

        const double eps = 0.000001;

        bool equalWithPrecision = Math.Abs(firstNumber - secondNumber) < eps;
        Console.WriteLine(equalWithPrecision);
    }
}

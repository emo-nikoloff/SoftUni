/*Create a method, which receives two numbers as parameters:
· The first number – the base
· The second number – the power
The method should return the base raised to the given power.
*Hints
1. As usual, read the input.
2. Create a method that will have two parameters - the number and the power, and will return a result of type double:
3. Print the result.*/
using System;

namespace _08._Math_Power;

class Program
{
    static void Main(string[] args)
    {
        double number = double.Parse(Console.ReadLine());
        int power = int.Parse(Console.ReadLine());

        double result = RaiseToPower(number, power);
        Console.WriteLine(result);
    }

    static double RaiseToPower(double number, int power)
    {
        double result = Math.Pow(number, power);
        return result;
    }
}

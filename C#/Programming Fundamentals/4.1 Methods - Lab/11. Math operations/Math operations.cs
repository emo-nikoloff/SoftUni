/*Write a method that receives two numbers and an operator, calculates the result and returns it. You will be given three lines of input. The first will be the first number, the second one will be the
operator and the last one will be the second number.
The possible operators are: /, *, + and -.
*Hint
1. Read the inputs and create a method that returns a double (the result of the operation)*/
using System;

namespace _11._Math_operations;

class Program
{
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        string operation = Console.ReadLine();
        int secondNumber = int.Parse(Console.ReadLine());

        double result = Calculate(firstNumber, operation, secondNumber);
        Console.WriteLine(result);
    }

    static double Calculate(int firstNumber, string operation, int secondNumber)
    {
        double result = 0;
        switch (operation)
        {
            case "/":
                result = firstNumber / secondNumber;
                break;
            case "*":
                result = firstNumber * secondNumber;
                break;
            case "+":
                result = firstNumber + secondNumber;
                break;
            case "-":
                result = firstNumber - secondNumber;
                break;
        }
        return result;
    }
}

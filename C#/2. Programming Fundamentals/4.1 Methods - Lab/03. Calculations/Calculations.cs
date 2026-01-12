/*Create a program that receives three lines of input:
· On the first line – a string – "add", "multiply", "subtract", "divide".
· On the second line – a number.
· On the third line – another number.
You should create four methods (for each calculation) and invoke the corresponding method depending on the command. The method should also print the result (needs to be void).
*Hints
1. Read the command on the first line, and the two numbers, and then make an if/switch statement for each type of calculation
2. Then create the four methods and print the result*/
using System;

namespace _03._Calculations;

class Program
{
    static void Main(string[] args)
    {
        string operation = Console.ReadLine();
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        switch (operation)
        {
            case "add":
                Add(firstNumber, secondNumber);
                break;
            case "multiply":
                Multiply(firstNumber, secondNumber);
                break;
            case "subtract":
                Subtract(firstNumber, secondNumber);
                break;
            case "divide":
                Divide(firstNumber, secondNumber);
                break;
        }
    }

    static void Add(int firstNumber, int secondNumber)
    {
        Console.WriteLine(firstNumber + secondNumber);
    }
    static void Multiply(int firstNumber, int secondNumber)
    {
        Console.WriteLine(firstNumber * secondNumber);
    }
    static void Subtract(int firstNumber, int secondNumber)
    {
        Console.WriteLine(firstNumber - secondNumber);
    }
    static void Divide(int firstNumber, int secondNumber)
    {
        Console.WriteLine(firstNumber / secondNumber);
    }
}

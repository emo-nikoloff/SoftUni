/*You will receive 3 integers. Create a method that returns the sum of the first two integers and another method that subtracts the third integer from the result of the sum method.*/
using System;

namespace _05._Add_and_Subtract;

class Program
{
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());

        int result = SubtractionFromTheFirstTwo(firstNumber, secondNumber, thirdNumber);
        Console.WriteLine(result);
    }

    static int SummationOfTheFirstTwo(int firstNumber, int secondNumber)
    {
        return firstNumber + secondNumber;
    }
    static int SubtractionFromTheFirstTwo(int firstNumber, int secondNumber, int thirdNumber)
    {
        return SummationOfTheFirstTwo(firstNumber, secondNumber) - thirdNumber;
    }
}

/*The Fibonacci sequence is a quite famous sequence of numbers. Each member of the sequence is calculated from the sum of the two previous elements. The first two elements are 1, 1. Therefore the
sequence goes like 1, 1, 2, 3, 5, 8, 13, 21, 34… The following sequence can be generated with an array, but that's easy, so your task is to implement recursively.
So if the function GetFibonacci(n) returns the nth Fibonacci number we can express it using GetFibonacci(n) = GetFibonacci(n-1) + GetFibonacci(n-2).
However, this will never end and in a few seconds, a StackOverflow Exception is thrown. For the recursion to stop, it has to have a “bottom”. The bottom of the recursion is GetFibonacci(2) should
return 1 and GetFibonacci(1) should return 1.
· On the only line in the input, the user should enter the wanted Fibonacci number.
· The output should be the nth Fibonacci number counting from 1.*/
using System;

namespace _03._Recursive_Fibonacci;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        int result = Fibonacci(number);
        Console.WriteLine(result);
    }

    static int Fibonacci(int number)
    {
        if (number == 2 || number == 1)
        {
            return 1;
        }
        else
        {
            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }
    }
}

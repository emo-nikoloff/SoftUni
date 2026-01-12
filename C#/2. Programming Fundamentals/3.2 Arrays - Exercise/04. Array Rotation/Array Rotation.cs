/*Create a program that receives an array and several rotations that you have to perform. The rotations are done by moving the first element of the array from the front to the back. Print the
resulting array.*/
using System;
using System.Linq;

namespace _04._Array_Rotation;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rotations = int.Parse(Console.ReadLine());

        for (int i = 1; i <= rotations; i++)
        {
            int firstNumber = numbers[0];
            for (int j = 0; j < numbers.Length - 1; j++)
            {
                numbers[j] = numbers[j + 1];
            }
            numbers[numbers.Length - 1] = firstNumber;
        }
        Console.Write(string.Join(" ", numbers));
    }
}

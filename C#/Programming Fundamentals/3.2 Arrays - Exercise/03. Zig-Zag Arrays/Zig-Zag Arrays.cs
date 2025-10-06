/*Create a program that creates 2 arrays. You will be given an integer n. On the next n lines, you will get 2 integers. Form 2 new arrays in a zig-zag pattern as shown below.*/
using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());

        int[] firstArray = new int[magicNumber];
        int[] secondArray = new int[magicNumber];

        for (int i = 0; i < magicNumber; i++)
        {
            int[] twoNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (i % 2 == 0)
            {
                firstArray[i] = twoNumbers[0];
                secondArray[i] = twoNumbers[1];
            }
            else if (i % 2 != 0)
            {
                firstArray[i] = twoNumbers[1];
                secondArray[i] = twoNumbers[0];
            }
        }
        Console.WriteLine(string.Join(" ", firstArray));
        Console.WriteLine(string.Join(" ", secondArray));
    }
}

/*Read an array from the console and sum only its even values.
*Hints
First, we need to read the array.
We will need a variable for the sum.
Iterate through all elements in the array with for loop.
Check if the number at the current index is even.
Print the total sum.*/
using System;
using System.Linq;

namespace _05._Sum_Even_Numbers;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                sum += numbers[i];
            }
        }
        Console.WriteLine(sum);
    }
}

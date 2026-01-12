/*Create a program that prints out all common elements in two arrays. You have to compare the elements of the second array to the elements of the first.*/
using System;

namespace _02._Common_Elements;

class Program
{
    static void Main(string[] args)
    {
        string[] firstArray = Console.ReadLine().Split();
        string[] secondArray = Console.ReadLine().Split();

        for (int j = 0; j < secondArray.Length; j++)
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (secondArray[j] == firstArray[i])
                {
                    Console.Write($"{secondArray[j]} ");
                    break;
                }
            }
        }
    }
}

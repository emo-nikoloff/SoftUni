/*Write a program that, depending on the first line of the input, reads an int, a double or a string.
· If the data type is int, multiply the number by 2.
· If the data type is real, multiply the number by 1.5 and format it to the second decimal point.
· If the data type is a string, surround the input with '$'.
Print the result on the console.
*Hint
Try to solve the problem using only one method with different overloads.*/
using System;

namespace _01._Data_Types;

class Program
{
    static void Main(string[] args)
    {
        string type = Console.ReadLine();

        switch (type)
        {
            case "int":
                int intNumber = int.Parse(Console.ReadLine());
                int intResult = Type(intNumber);
                Console.WriteLine(intResult);
                break;
            case "real":
                double realNumber = double.Parse(Console.ReadLine());
                double realResult = Type(realNumber);
                Console.WriteLine($"{realResult:f2}");
                break;
            case "string":
                string word = Console.ReadLine();
                string stringResult = Type(word);
                Console.WriteLine(stringResult);
                break;
        }
    }

    static int Type(int number)
    {
        return number * 2;
    }

    static double Type(double number)
    {
        return number * 1.5;
    }

    static string Type(string word)
    {
        return $"${word}$";
    }
}

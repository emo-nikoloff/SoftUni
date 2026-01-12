/*Modify the program from the previous problem, so it will print "Failed!", if the grade is lower than 3.00.
The input comes as a single double number.
The output is either "Passed!" if the grade is more than 2.99, otherwise you should print "Failed!"*/
using System;

namespace _03._Passed_or_Failed;

class Program
{
    static void Main(string[] args)
    {
        double grade = double.Parse(Console.ReadLine());
        if (grade > 2.99)
        {
            Console.WriteLine("Passed!");
        }
        else
        {
            Console.WriteLine("Failed!");
        }
    }
}
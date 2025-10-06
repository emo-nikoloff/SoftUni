/*A theatre sails tickets at discount and a program is needed to calculate the price of a single ticket. If the given age does not fit one of the categories, you should
print "Error!".
The prices of the tickets are as follows:
Day / Age
        0 <= age <= 18  18 < age <= 64  64 < age <= 122
Weekday     12$             18$             12$
Weekend     15$             20$             15$
Holiday     5$              12$             10$
The input comes in two lines. On the first line you will receive the type of day. On the second – the age of the person.
Print the price of the ticket according to the table or "Error!", if the age is not in the table.
· The age will be in the interval [-1000…1000].
· The type of day will always be valid.*/
using System;

namespace _07._Theatre_Promotion;

class Program
{
    static void Main(string[] args)
    {
        string day = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        switch (day)
        {
            case "Weekday":
                if (age >= 0 && age <= 18)
                {
                    Console.WriteLine("12$");
                }
                else if (age > 18 && age <= 64)
                {
                    Console.WriteLine("18$");
                }
                else if (age > 64 && age <= 122)
                {
                    Console.WriteLine("12$");
                }
                else
                {
                    Console.WriteLine("Error!");
                }

                break;
            case "Weekend":
                if (age >= 0 && age <= 18)
                {
                    Console.WriteLine("15$");
                }
                else if (age > 18 && age <= 64)
                {
                    Console.WriteLine("20$");
                }
                else if (age > 64 && age <= 122)
                {
                    Console.WriteLine("15$");
                }
                else
                {
                    Console.WriteLine("Error!");
                }

                break;
            case "Holiday":
                if (age >= 0 && age <= 18)
                {
                    Console.WriteLine("5$");
                }
                else if (age > 18 && age <= 64)
                {
                    Console.WriteLine("12$");
                }
                else if (age > 64 && age <= 122)
                {
                    Console.WriteLine("10$");
                }
                else
                {
                    Console.WriteLine("Error!");
                }

                break;
            default:
                Console.WriteLine("Error!");
                break;
        }
    }
}
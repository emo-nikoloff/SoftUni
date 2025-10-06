/*Enter a number in range 1-7 and print out the word representing it or "Invalid day!". Use an array of strings.*/
using System;

namespace _01._Day_of_Week;

class Program
{
    static void Main(string[] args)
    {
        int day = int.Parse(Console.ReadLine());

        string[] daysOfWeek =
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };

        if (day >= 1 && day <= 7)
        {
            Console.WriteLine(daysOfWeek[day - 1]);
        }
        else
        {
            Console.WriteLine("Invalid day!");
        }
    }
}

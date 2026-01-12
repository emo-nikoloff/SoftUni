/*Create a program to enter an integer number of centuries and convert it to years, days, hours and minute.
*Hints
· Use appropriate data types to fit the result after each data conversion.
· Assume that a year has 365.2422 days on average (the Tropical year).*/
using System;

namespace _04._Centuries_to_Minutes;

class Program
{
    static void Main(string[] args)
    {
        int centuries = int.Parse(Console.ReadLine());

        int years = centuries * 100;
        double days = years * 365.2422;
        decimal hours = (int)days * 24;
        decimal minutes = hours * 60;

        Console.WriteLine($"{centuries} centuries = {years} years = {(int)days} days = {hours} hours = {minutes} minutes");
    }
}

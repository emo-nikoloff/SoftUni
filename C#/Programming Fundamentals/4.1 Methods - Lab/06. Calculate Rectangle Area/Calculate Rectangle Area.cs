/*Create a method that calculates and returns the area of a rectangle.
*Hints
1. Read the input
2. Create a method, but this time instead of typing "static void" before its name, type "static double" as this will make it return a value of type double
3. Invoke the method in the main and save the return value in a new variable*/
using System;

namespace _06._Calculate_Rectangle_Area;

class Program
{
    static void Main(string[] args)
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        double area = RectangleArea(width, height);
        Console.WriteLine(area);
    }

    static double RectangleArea(double width, double height)
    {
        return width * height;
    }
}

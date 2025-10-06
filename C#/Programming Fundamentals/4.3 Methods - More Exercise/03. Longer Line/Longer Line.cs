/*You are given the coordinates of four points in the 2D plane. The first and the second pair of points form two different lines. Print the longer line in the format "(X1, Y1)(X2, Y2)" starting with
the point that is closer to the center of the coordinate system (0, 0). (You can reuse the method that you wrote for the previous problem.) If the lines are of equal length, print only the first one.*/
using System;

namespace _03._Longer_Line;

class Program
{
    static void Main(string[] args)
    {
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());

        double x3 = double.Parse(Console.ReadLine());
        double y3 = double.Parse(Console.ReadLine());
        double x4 = double.Parse(Console.ReadLine());
        double y4 = double.Parse(Console.ReadLine());

        double firstLength = PairLength(x1, y1, x2, y2);
        double secondLength = PairLength(x3, y3, x4, y4);

        if (firstLength >= secondLength)
        {
            PrintClosestPointToTheCenter(x1, y1, x2, y2);
        }
        else
        {
            PrintClosestPointToTheCenter(x3, y3, x4, y4);
        }
    }

    static double PairLength(double x1, double y1, double x2, double y2)
    {
        double length = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        return length;
    }

    static double DistanceToCenter(double x, double y)
    {
        return Math.Sqrt(Math.Pow(0 - x, 2) + Math.Pow(0 - y, 2));
    }

    static void PrintClosestPointToTheCenter(double x1, double y1, double x2, double y2)
    {
        double firstPairDistance = DistanceToCenter(x1, y1);
        double secondPairDistance = DistanceToCenter(x2, y2);

        if (firstPairDistance <= secondPairDistance)
        {
            Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
        }
        else
        {
            Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
        }
    }
}

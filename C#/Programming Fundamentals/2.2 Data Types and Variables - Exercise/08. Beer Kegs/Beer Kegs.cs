/*Create a program, which calculates the volume of n beer kegs. You will receive in total 3 * n lines. Every three lines will hold information for a single keg. First up is the model of the keg,
after that is the radius of the keg, and lastly is the height of the keg.
Calculate the volume using the following formula: π * r^2 * h.
In the end, print the model of the biggest keg.
You will receive 3 * n lines. Each group of lines will be on a new line:
· First – model – string
· Second –radius – floating-point number
· Third – height – integer number
Print the model of the biggest keg.*/
using System;

namespace _08._Beer_Kegs;

class Program
{
    static void Main(string[] args)
    {
        int kegs = int.Parse(Console.ReadLine());

        double biggestKegVolume = double.MinValue;
        string biggestKegModel = string.Empty;
        for (int keg = 1; keg <= kegs; keg++)
        {
            string model = Console.ReadLine();
            double radius = double.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            double volume = Math.PI * Math.Pow(radius, 2) * height;
            if (volume > biggestKegVolume)
            {
                biggestKegVolume = volume;
                biggestKegModel = model;
            }
        }
        Console.WriteLine(biggestKegModel);
    }
}

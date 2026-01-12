/*You have a water tank with a capacity of 255 liters. On the next n lines, you will receive liters of water, which you have to pour into your tank. If the capacity is not enough, print "Insufficient
capacity!" and continue reading the next line. On the last line, print the liters in the tank.
The input will be on two lines:
· On the first line, you will receive n – the number of lines, which will follow.
· On the next n lines, you will receive quantities of water, which you have to pour into the tank.
Every time you do not have enough capacity in the tank to pour the given liters, print:
Insufficient capacity!
On the last line, print only the liters in the tank.*/
using System;

namespace _07._Water_Overflow;

class Program
{
    static void Main(string[] args)
    {
        int timesPouring = int.Parse(Console.ReadLine());

        int totalLitres = 0;
        for (int i = 1; i <= timesPouring; i++)
        {
            int litres = int.Parse(Console.ReadLine());
            if (totalLitres + litres > 255)
            {
                Console.WriteLine("Insufficient capacity!");
                continue;
            }
            totalLitres += litres;
        }
        Console.WriteLine($"{totalLitres}");
    }
}

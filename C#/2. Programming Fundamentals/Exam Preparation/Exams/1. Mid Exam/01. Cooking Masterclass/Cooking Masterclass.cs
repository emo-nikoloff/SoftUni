/**/
using System;

namespace _01._Cooking_Masterclass;

class Program
{
    static void Main(string[] args)
    {
        double budget = double.Parse(Console.ReadLine());
        int students = int.Parse(Console.ReadLine());
        double pricePacketFlour = double.Parse(Console.ReadLine());
        double priceSingleEgg = double.Parse(Console.ReadLine());
        double priceSingleApron = double.Parse(Console.ReadLine());


        double packetsFlour = pricePacketFlour * (students - students / 5);
        double eggs = priceSingleEgg * students * 10;
        double aprons = priceSingleApron * (students + Math.Ceiling(students * 0.2));
        double totalPrice = packetsFlour + eggs + aprons;

        if (totalPrice <= budget)
        {
            Console.WriteLine($"Items purchased for {totalPrice:f2}$.");
        }
        else
        {
            Console.WriteLine($"{totalPrice - budget:f2}$ more needed.");
        }
    }
}

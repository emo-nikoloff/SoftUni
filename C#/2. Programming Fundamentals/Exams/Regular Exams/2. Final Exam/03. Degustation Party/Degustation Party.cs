using System;
using System.Collections.Generic;

namespace _03._Degustation_Party;

class Program
{
    static void Main(string[] args)
    {
        string input;
        Dictionary<string, List<string>> guestsMeals = new();
        int dislikedMeals = 0;

        while ((input = Console.ReadLine()) != "Stop")
        {
            string[] inputParts = input.Split("-");

            string guestName = inputParts[1];
            string guestMeal = inputParts[2];

            switch (inputParts[0])
            {
                case "Like":
                    if (!guestsMeals.ContainsKey(guestName))
                    {
                        guestsMeals.Add(guestName, new());
                    }

                    if (!guestsMeals[guestName].Contains(guestMeal))
                    {
                        guestsMeals[guestName].Add(guestMeal);
                    }
                    break;
                case "Dislike":
                    if (!guestsMeals.ContainsKey(guestName))
                    {
                        Console.WriteLine($"{guestName} is not at the party.");
                    }
                    else if (!guestsMeals[guestName].Contains(guestMeal))
                    {
                        Console.WriteLine($"{guestName} doesn't have the {guestMeal} in his/her collection.");
                    }
                    else
                    {
                        guestsMeals[guestName].Remove(guestMeal);
                        dislikedMeals++;

                        Console.WriteLine($"{guestName} doesn't like the {guestMeal}.");
                    }
                    break;
            }
        }

        foreach ((string guest, List<string> meals) in guestsMeals)
        {
            Console.WriteLine($"{guest}: {string.Join((", "), meals)}");
        }
        Console.WriteLine($"Unliked meals: {dislikedMeals}");
    }
}

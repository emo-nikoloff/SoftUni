/*Heroes III is the best game ever. Everyone loves it and everyone plays it all the time. Stamat is no exclusion to this rule. His favorite units in the game are all types of dragons – black, red,
gold, azure, etc. He likes them so much that he gives them names and keeps logs of their stats: damage, health and armor. The process of aggregating all the data is quite tedious, so he would like to
have a program doing it. Since he is no programmer, it's your task to help him.
You need to categorize dragons by their type. For each dragon, identified by name, keep information about his stats. Type is preserved as in the order of input, but dragons are sorted alphabetically
by name. For each type you should also print the average damage, health and armor of the dragons. For each dragon print his stats.
There may be missing stats in the input, though. If a stat is missing, you should assign its default values. Default values are as follows: health 250, damage 45 and armor 10. Missing stat will be
marked by null.
The input is in the following format "{type} {name} {damage} {health} {armor}". Any of the integers may be assigned null value. See the examples below for better understanding of your task.
If the same dragon is added a second time, the new stats should overwrite the previous ones. Two dragons are considered equal if they match by both name and type.
· On the first line, you are given number N -> the number of dragons to follow.
· On the next N lines, you are given input in the above-described format. There will be a single space separating each element.
· Print the aggregated data on the console.
· For each type print average stats of its dragons in format "{Type}::({damage}/{health}/{armor})".
· Damage, health and armor should be rounded to two digits after the decimal separator.
· For each dragon, print its stats in format "-{Name} -> damage: {damage}, health: {health}, armor: {armor}".*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Dragon_Army;

class Program
{
    static void Main(string[] args)
    {
        int numberDragons = int.Parse(Console.ReadLine());
        Dictionary<string, Dictionary<string, List<int>>> dragonsStats = new();


        for (int i = 1; i <= numberDragons; i++)
        {
            string[] dragonInfo = Console.ReadLine().Split();

            string dragonType = dragonInfo[0];
            string dragonName = dragonInfo[1];
            int dragonDamage = GetStatOrDefault(dragonInfo[2], 45);
            int dragonHealth = GetStatOrDefault(dragonInfo[3], 250);
            int dragonArmor = GetStatOrDefault(dragonInfo[4], 10);

            if (!dragonsStats.ContainsKey(dragonType))
            {
                dragonsStats.Add(dragonType, new());
            }

            if (!dragonsStats[dragonType].ContainsKey(dragonName))
            {
                dragonsStats[dragonType].Add(dragonName, new() { dragonDamage, dragonHealth, dragonArmor });
            }
            else
            {
                dragonsStats[dragonType][dragonName] = new() { dragonDamage, dragonHealth, dragonArmor };
            }
        }

        foreach ((string type, Dictionary<string, List<int>> dragonStats) in dragonsStats)
        {
            double averageDamage = dragonStats.Values.Average(dmg => dmg[0]);
            double averageHealth = dragonStats.Values.Average(hp => hp[1]);
            double averageArmor = dragonStats.Values.Average(a => a[2]);

            Console.WriteLine($"{type}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

            foreach ((string name, List<int> stats) in dragonStats.OrderBy(name => name.Key))
            {
                int damage = stats[0];
                int health = stats[1];
                int armor = stats[2];

                Console.WriteLine($"-{name} -> damage: {damage}, health: {health}, armor: {armor}");
            }
        }
    }

    static int GetStatOrDefault(string input, int defaultValue)
    {
        return input == "null" ? defaultValue : int.Parse(input);
    }
}

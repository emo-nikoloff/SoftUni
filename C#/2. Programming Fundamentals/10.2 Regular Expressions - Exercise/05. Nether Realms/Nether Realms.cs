/*A mighty battle is coming. In the stormy nether realms, demons are fighting against each other for supremacy in a duel from which only one will survive.
Your job, however, is not so exciting. You are assigned to sign in all the participants in the nether realm's mighty battle's demon book, which of course is sorted alphabetically.
A demon's name contains his health and his damage.
The sum of the asci codes of all characters (excluding numbers (0-9), arithmetic symbols ('+', '-', '*', '/') and delimiter dot ('.')) gives a demon's total health.
The sum of all numbers in his name forms his base damage. Note that you should consider the plus '+' and minus '-' signs (e.g. +10 is 10 and -10 is -10). However, there are some symbols ('*' and '/')
that can further alter the base damage by multiplying or dividing it by 2 (e.g. in the name "m15*\/c - 5.0", the base damage is 15 + (-5.0) = 10 and then you need to multiply it by 2 (e.g. 10 * 2 = 20)
and then divide it by 2 (e.g. 20 / 2 = 10)).
So, multiplication and division are applied only after all numbers are included in the calculation and in the order they appear in the name.
You will get all demons on a single line, separated by commas and zero or more blank spaces. Sort them in alphabetical order and print their names along with their health and damage.
The input will be read from the console. The input consists of a single line containing all demon names separated by commas and zero or more spaces in the format:
"{demon name}, {demon name}, … {demon name}"
Print all demons sorted by their name in ascending order, each on a separate line in the format:
· "{demon name} - {health points} health, {damage points} damage"*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms;

class Program
{
    static void Main(string[] args)
    {
        string[] demons = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string healthPattern = @"[^0-9+\-*/\.]";
        string damagePattern = @"[+\-]?\d+\.\d+|[+\-]?\d+";

        List<Demon> demonsList = new();

        foreach (string demon in demons)
        {
            MatchCollection letterMatches = Regex.Matches(demon, healthPattern);
            MatchCollection digitMatches = Regex.Matches(demon, damagePattern);

            int health = letterMatches.Cast<Match>().Sum(letter => letter.Value[0]);
            double damage = digitMatches.Cast<Match>().Sum(digit => double.Parse(digit.Value));

            foreach (char symbol in demon)
            {
                if (symbol == '*')
                {
                    damage *= 2;
                }
                else if (symbol == '/')
                {
                    damage /= 2;
                }
            }

            Demon newDemon = new(demon, health, damage);

            demonsList.Add(newDemon);
        }

        List<Demon> filteredDemonsList = demonsList.OrderBy(d => d.Name).ToList();
        filteredDemonsList.ForEach(d => Console.WriteLine($"{d.Name} - {d.Health} health, {d.Damage:f2} damage"));
    }
}

class Demon
{
    public Demon(string name, int health, double damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    public string Name { get; set; }
    public int Health { get; set; }
    public double Damage { get; set; }
}

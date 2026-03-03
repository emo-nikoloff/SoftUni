using Raiding.Models;
using Raiding.Models.Interfaces;

namespace Raiding;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IHero> heroes = new();

        int heroesNumber = int.Parse(Console.ReadLine());

        while (heroes.Count < heroesNumber)
        {
            string heroName = Console.ReadLine();
            string heroType = Console.ReadLine();

            IHero hero = null;

            switch (heroType)
            {
                case "Druid":
                    hero = new Druid(heroName);
                    break;
                case "Paladin":
                    hero = new Paladin(heroName);
                    break;
                case "Rogue":
                    hero = new Rogue(heroName);
                    break;
                case "Warrior":
                    hero = new Warrior(heroName);
                    break;
                default:
                    Console.WriteLine("Invalid hero!");
                    break;
            }

            if (hero is not null)
            {
                heroes.Add(hero);
            }
        }

        int bossPower = int.Parse(Console.ReadLine());

        foreach (IHero hero in heroes)
        {
            Console.WriteLine(hero.CastAbility());
        }

        if (heroes.Sum(h => h.Power) >= bossPower)
        {
            Console.WriteLine("Victory!");
        }
        else
        {
            Console.WriteLine("Defeat...");
        }
    }
}

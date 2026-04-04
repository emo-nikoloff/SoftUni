using System.Text;
using LegendsOfValor_TheGuildTrials.Core.Contracts;
using LegendsOfValor_TheGuildTrials.Models;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;

namespace LegendsOfValor_TheGuildTrials.Core;

public class Controller : IController
{
    private HeroRepository heroes;
    private GuildRepository guilds;

    public Controller()
    {
        heroes = new();
        guilds = new();
    }

    public string AddHero(string heroTypeName, string heroName, string runeMark)
    {
        string[] validTypes = { "Warrior", "Sorcerer", "Spellblade" };
        if (!validTypes.Contains(heroTypeName))
        {
            return string.Format(OutputMessages.InvalidHeroType, heroTypeName);
        }
        else if (heroes.GetAll().Any(h => h.RuneMark == runeMark))
        {
            return string.Format(OutputMessages.HeroAlreadyExists, runeMark);
        }

        string fullName = $"LegendsOfValor_TheGuildTrials.Models.Heroes.{heroTypeName}";
        Type heroType = Type.GetType(fullName);
        Hero hero = Activator.CreateInstance(heroType, heroName, runeMark) as Hero;

        heroes.AddModel(hero);

        return string.Format(OutputMessages.HeroAdded, heroTypeName, heroName, runeMark);
    }

    public string CreateGuild(string guildName)
    {
        if (guilds.GetAll().Any(g => g.Name == guildName))
        {
            return string.Format(OutputMessages.GuildAlreadyExists, guildName);
        }

        Type guildType = Type.GetType("Guild");
        Guild guild = Activator.CreateInstance(guildType, guildName) as Guild;

        guilds.AddModel(guild);

        return string.Format(OutputMessages.GuildCreated, guildName);
    }

    public string RecruitHero(string runeMark, string guildName)
    {
        if (!heroes.GetAll().Any(h => h.RuneMark == runeMark))
        {
            return OutputMessages.HeroNotFound;
        }
        else if (!guilds.GetAll().Any(g => g.Name == guildName))
        {
            return string.Format(OutputMessages.GuildNotFound, guildName);
        }

        Hero hero = heroes.GetAll().FirstOrDefault(h => h.RuneMark == runeMark);
        Guild guild = guilds.GetAll().FirstOrDefault(g => g.Name == guildName);

        if (hero.GuildName == guildName)
        {
            return string.Format(OutputMessages.HeroAlreadyInGuild, hero.Name);
        }
        else if (guild.IsFallen == true)
        {
            return string.Format(OutputMessages.GuildIsFallen, guild.Name);
        }
        else if (guild.Wealth < 500)
        {
            return string.Format(OutputMessages.GuildCannotAffordRecruitment, guild.Wealth);
        }
        else if (!hero.AllowedGuilds.Any(guild => guild == guildName))
        {
            return string.Format(OutputMessages.HeroTypeNotCompatible, hero.Name, guild.Name);
        }

        hero.JoinGuild(guild);
        guild.RecruitHero(hero);

        return string.Format(OutputMessages.HeroRecruited, hero.Name, guild.Name);
    }

    public string StartWar(string attackerGuildName, string defenderGuildName)
    {
        if (!guilds.GetAll().Any(g => g.Name == attackerGuildName) || !guilds.GetAll().Any(g => g.Name == defenderGuildName))
        {
            return string.Format(OutputMessages.OneOfTheGuildsDoesNotExist);
        }

        Guild attacker = guilds.GetAll().First(g => g.Name == attackerGuildName);
        Guild defender = guilds.GetAll().First(g => g.Name == defenderGuildName);

        if (attacker.IsFallen == true || defender.IsFallen == true)
        {
            return string.Format(OutputMessages.OneOfTheGuildsIsFallen);
        }

        int attackerStrength = 0;
        foreach (string heroRuneMark in attacker.Legion)
        {
            Hero hero = heroes.GetAll().First(h => h.RuneMark == heroRuneMark);

            attackerStrength += hero.Power;
            attackerStrength += hero.Mana;
            attackerStrength += hero.Stamina;
        }

        int defenderStrength = 0;
        foreach (string heroRuneMark in defender.Legion)
        {
            Hero hero = heroes.GetAll().First(h => h.RuneMark == heroRuneMark);

            defenderStrength += hero.Power;
            defenderStrength += hero.Mana;
            defenderStrength += hero.Stamina;
        }

        if (attackerStrength > defenderStrength)
        {
            int goldWon = defender.Wealth;
            attacker.WinWar(goldWon);
            defender.LoseWar();
            return string.Format(OutputMessages.WarWon, attackerGuildName, defenderGuildName, goldWon);
        }
        else
        {
            int goldWon = attacker.Wealth;
            defender.WinWar(goldWon);
            attacker.LoseWar();
            return string.Format(OutputMessages.WarLost, defenderGuildName, goldWon, attackerGuildName);
        }
    }

    public string TrainingDay(string guildName)
    {
        if (!guilds.GetAll().Any(g => g.Name == guildName))
        {
            return string.Format(OutputMessages.GuildNotFound, guildName);
        }

        Guild guild = guilds.GetAll().FirstOrDefault(g => g.Name == guildName);

        if (guild.IsFallen == true)
        {
            return string.Format(OutputMessages.GuildTrainingDayIsFallen, guildName);
        }

        int totalTrainingCost = 200 * guild.Legion.Count;

        if (guild.Wealth < totalTrainingCost)
        {
            return string.Format(OutputMessages.TrainingDayFailed, guildName);
        }

        List<IHero> heroesToTrain = guild.Legion.Select(rune => (IHero)heroes.GetModel(rune)).ToList();

        guild.TrainLegion(heroesToTrain);

        return string.Format(OutputMessages.TrainingDayStarted, guildName, heroesToTrain.Count, totalTrainingCost);
    }

    public string ValorState()
    {
        StringBuilder report = new();

        foreach (Guild guild in guilds.GetAll().OrderByDescending(g => g.Wealth))
        {
            report.AppendLine($"{guild.Name} (Wealth: {guild.Wealth})");

            foreach (Hero hero in heroes.GetAll().Where(h => h.GuildName == guild.Name).OrderBy(h => h.Name))
            {
                report.AppendLine(hero.ToString());
                report.AppendLine($"--{hero.Essence()}");
            }
        }

        return report.ToString().Trim();
    }
}

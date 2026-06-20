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
        string[] validHeroTypes = { "Warrior", "Sorcerer", "Spellblade" };

        if (!validHeroTypes.Contains(heroTypeName))
        {
            return string.Format(OutputMessages.InvalidHeroType, heroTypeName);
        }
        else if (heroes.GetModel(runeMark) != null)
        {
            return string.Format(OutputMessages.HeroAlreadyExists, runeMark);
        }

        string fullName = $"LegendsOfValor_TheGuildTrials.Models.Heroes.{heroTypeName}";
        Type heroType = Type.GetType(fullName);
        IHero hero = Activator.CreateInstance(heroType, heroName, runeMark) as IHero;

        heroes.AddModel(hero);

        return string.Format(OutputMessages.HeroAdded, heroTypeName, heroName, runeMark);
    }

    public string CreateGuild(string guildName)
    {
        if (guilds.GetModel(guildName) != null)
        {
            return string.Format(OutputMessages.GuildAlreadyExists, guildName);
        }

        Type guildType = typeof(Guild);
        IGuild guild = Activator.CreateInstance(guildType, guildName) as IGuild;

        guilds.AddModel(guild);

        return string.Format(OutputMessages.GuildCreated, guildName);
    }

    public string RecruitHero(string runeMark, string guildName)
    {
        if (heroes.GetModel(runeMark) == null)
        {
            return string.Format(OutputMessages.HeroNotFound, runeMark);
        }
        else if (guilds.GetModel(guildName) == null)
        {
            return string.Format(OutputMessages.GuildNotFound, guildName);
        }

        IHero hero = heroes.GetModel(runeMark);
        IGuild guild = guilds.GetModel(guildName);

        Dictionary<string, List<string>> heroesAllowedGuilds = new()
        {
            { "Warrior", new()
                {
                    "WarriorGuild", "ShadowGuild"
                }
            },
            { "Sorcerer", new()
                {
                    "SorcererGuild", "ShadowGuild"
                }
            },
            { "Spellblade", new()
                {
                    "WarriorGuild", "SorcererGuild"
                }
            }
        };

        if (hero.GuildName != null)
        {
            return string.Format(OutputMessages.HeroAlreadyInGuild, hero.Name);
        }
        else if (guild.IsFallen == true)
        {
            return string.Format(OutputMessages.GuildIsFallen, guild.Name);
        }
        else if (guild.Wealth < 500)
        {
            return string.Format(OutputMessages.GuildCannotAffordRecruitment, guild.Name);
        }
        else if (!heroesAllowedGuilds[hero.GetType().Name].Any(g => g == guild.Name))
        {
            return string.Format(OutputMessages.HeroTypeNotCompatible, hero.GetType().Name, guild.Name);
        }

        hero.JoinGuild(guild);
        guild.RecruitHero(hero);

        return string.Format(OutputMessages.HeroRecruited, hero.Name, guild.Name);
    }

    public string StartWar(string attackerGuildName, string defenderGuildName)
    {
        if (guilds.GetModel(attackerGuildName) == null || guilds.GetModel(defenderGuildName) == null)
        {
            return string.Format(OutputMessages.OneOfTheGuildsDoesNotExist);
        }

        IGuild attacker = guilds.GetModel(attackerGuildName);
        IGuild defender = guilds.GetModel(defenderGuildName);

        if (attacker.IsFallen == true || defender.IsFallen == true)
        {
            return string.Format(OutputMessages.OneOfTheGuildsIsFallen);
        }

        int attackerStrength = 0;
        foreach (string runeMark in attacker.Legion)
        {
            IHero hero = heroes.GetModel(runeMark);

            attackerStrength += hero.Power;
            attackerStrength += hero.Mana;
            attackerStrength += hero.Stamina;
        }

        int defenderStrength = 0;
        foreach (string runeMark in defender.Legion)
        {
            IHero hero = heroes.GetModel(runeMark);

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
        if (guilds.GetModel(guildName) == null)
        {
            return string.Format(OutputMessages.GuildNotFound, guildName);
        }

        IGuild guild = guilds.GetModel(guildName);

        if (guild.IsFallen == true)
        {
            return string.Format(OutputMessages.GuildTrainingDayIsFallen, guildName);
        }

        int totalTrainingCost = 200 * guild.Legion.Count;

        if (guild.Wealth < totalTrainingCost)
        {
            return string.Format(OutputMessages.TrainingDayFailed, guildName);
        }

        List<IHero> heroesToTrain = guild.Legion.Select(rune => heroes.GetModel(rune)).ToList();

        guild.TrainLegion(heroesToTrain);

        return string.Format(OutputMessages.TrainingDayStarted, guildName, heroesToTrain.Count, totalTrainingCost);
    }

    public string ValorState()
    {
        StringBuilder report = new();

        report.AppendLine("Valor State:");

        foreach (IGuild guild in guilds.GetAll().OrderByDescending(g => g.Wealth))
        {
            report.AppendLine($"{guild.Name} (Wealth: {guild.Wealth})");

            foreach (IHero hero in heroes.GetAll().Where(h => h.GuildName == guild.Name).OrderBy(h => h.Name))
            {
                report.AppendLine($"-{hero.ToString()}");
                report.AppendLine($"--{hero.Essence()}");
            }
        }

        return report.ToString().TrimEnd();
    }
}

using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;

namespace LegendsOfValor_TheGuildTrials.Models;

public abstract class Hero : IHero
{
    private string name;
    private string runeMark;
    private string guildName;
    private int power;
    private int mana;
    private int stamina;

    protected Hero(string name, string runeMark, int power, int mana, int stamina)
    {
        Name = name;
        RuneMark = runeMark;
        Power = power;
        Mana = mana;
        Stamina = stamina;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ErrorMessages.InvalidHeroName);
            }
            name = value;
        }
    }

    public string RuneMark
    {
        get => runeMark;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ErrorMessages.InvalidHeroRuneMark);
            }
            runeMark = value;
        }
    }

    public string GuildName
    {
        get => guildName;
        private set => guildName = value;

    }

    public int Power
    {
        get => power;
        protected set => power = value;
    }

    public int Mana
    {
        get => mana;
        protected set => mana = value;
    }

    public int Stamina
    {
        get => stamina;
        protected set => stamina = value;
    }

    public string Essence() => $"Essence Revealed - Power [{Power}] Mana [{Mana}] Stamina [{Stamina}]";
    public void JoinGuild(IGuild guild) => GuildName = guild.Name;
    public abstract void Train();

    public override string ToString() => $"Hero: [{Name}] of the Guild '{GuildName}' - RuneMark: {RuneMark}";
}

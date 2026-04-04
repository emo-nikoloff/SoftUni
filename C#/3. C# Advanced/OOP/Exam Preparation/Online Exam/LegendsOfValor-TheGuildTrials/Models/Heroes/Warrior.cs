namespace LegendsOfValor_TheGuildTrials.Models.Heroes;

public class Warrior : Hero
{
    public Warrior(string name, string runeMark) : base(name, runeMark, 60, 0, 100)
    {
        AllowedGuilds.Add("WarriorGuild");
        AllowedGuilds.Add("ShadowGuild");
    }

    public override void Train()
    {
        Power += 30;
        Stamina += 10;
    }
}

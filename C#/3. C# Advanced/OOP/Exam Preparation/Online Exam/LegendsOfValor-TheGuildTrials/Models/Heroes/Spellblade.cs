namespace LegendsOfValor_TheGuildTrials.Models.Heroes;

public class Spellblade : Hero
{
    public Spellblade(string name, string runeMark) : base(name, runeMark, 50, 60, 60)
    {
    }

    public override void Train()
    {
        Power += 15;
        Mana += 10;
        Stamina += 10;
    }
}

namespace LegendsOfValor_TheGuildTrials.Models.Heroes;

public class Sorcerer : Hero
{
    public Sorcerer(string name, string runeMark) : base(name, runeMark, 40, 120, 0)
    {
    }

    public override void Train()
    {
        Power += 20;
        Mana += 25;
    }
}

namespace Raiding.Models;

public class Warrior : BaseHero
{
    private const int DefaultPower = 100;

    public Warrior(string name) : base(name, DefaultPower)
    {
    }

    public override string CastAbility() => $"{GetType().Name} - {Name} hit for {Power} damage";
}

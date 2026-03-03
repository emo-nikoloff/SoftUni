using Raiding.Models.Interfaces;

namespace Raiding.Models;

public abstract class BaseHero : IHero
{
    protected BaseHero(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public string Name { get; }
    public int Power { get; protected set; }

    public abstract string CastAbility();
}

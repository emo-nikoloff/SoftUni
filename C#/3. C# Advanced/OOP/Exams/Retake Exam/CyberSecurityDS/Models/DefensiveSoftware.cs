using CyberSecurityDS.Models.Contracts;
using static CyberSecurityDS.Utilities.Messages.ExceptionMessages;

namespace CyberSecurityDS.Models;

public abstract class DefensiveSoftware : IDefensiveSoftware
{
    private string name = null!;

    private int effectiveness;

    private List<string> assignedAttacks;

    protected DefensiveSoftware(string name, int effectiveness)
    {
        Name = name;
        Effectiveness = effectiveness;
        assignedAttacks = new();
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(SoftwareNameRequired);
            }
            name = value;
        }
    }

    public int Effectiveness
    {
        get => effectiveness;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(EffectivenessNegative);
            }

            if (value == 0)
            {
                effectiveness = 1;
            }
            else if (value > 10)
            {
                effectiveness = 10;
            }
            else
            {
                effectiveness = value;
            }
        }
    }
    public IReadOnlyCollection<string> AssignedAttacks => assignedAttacks;

    public void AssignAttack(string attackName) => assignedAttacks.Add(attackName);

    public override string ToString()
    {
        string attacks = assignedAttacks.Count > 0 ? string.Join(", ", assignedAttacks) : "[None]";

        return $"Defensive Software: {Name}, Effectiveness: {Effectiveness}, Assigned Attacks: {attacks}";
    }
}

using System.Text;
using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IMission> missions) : base(id, firstName, lastName, salary, corps)
    {
        Missions = missions;
    }

    public IReadOnlyCollection<IMission> Missions { get; }

    public override string ToString()
    {
        StringBuilder result = new();

        result.AppendLine(base.ToString());
        result.AppendLine("Missions:");

        foreach (IMission mission in Missions)
        {
            result.AppendLine($"  {mission}");
        }

        return result.ToString().TrimEnd();
    }
}

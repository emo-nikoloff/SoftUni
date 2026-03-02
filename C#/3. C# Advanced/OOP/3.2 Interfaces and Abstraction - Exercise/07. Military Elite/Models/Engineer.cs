using System.Text;
using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IRepair> repairs) : base(id, firstName, lastName, salary, corps)
    {
        Repairs = repairs;
    }

    public IReadOnlyCollection<IRepair> Repairs { get; }

    public override string ToString()
    {
        StringBuilder result = new();

        result.AppendLine(base.ToString());
        result.AppendLine("Repairs:");

        foreach (IRepair repair in Repairs)
        {
            result.AppendLine($"  {repair}");
        }

        return result.ToString().TrimEnd();
    }
}

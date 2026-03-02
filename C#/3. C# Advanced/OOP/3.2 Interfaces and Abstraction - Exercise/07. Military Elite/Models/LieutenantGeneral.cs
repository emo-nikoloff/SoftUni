using System.Text;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models;

public class LieutenantGeneral : RegularSoldier, ILieutenantGeneral
{
    public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, IReadOnlyCollection<IPrivate> privates) : base(id, firstName, lastName, salary)
    {
        Privates = privates;
    }

    public IReadOnlyCollection<IPrivate> Privates { get; }

    public override string ToString()
    {
        StringBuilder result = new();

        result.AppendLine(base.ToString());
        result.AppendLine("Privates:");

        foreach (IPrivate @private in Privates)
        {
            result.AppendLine($"  {@private}");
        }

        return result.ToString().TrimEnd();
    }
}

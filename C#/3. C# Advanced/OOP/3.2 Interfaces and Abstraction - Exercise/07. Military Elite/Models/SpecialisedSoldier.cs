using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models;

public abstract class SpecialisedSoldier : RegularSoldier, ISpecialisedSoldier
{
    protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary)
    {
        Corps = corps;
    }

    public Corps Corps { get; }

    public override string ToString() => $"{base.ToString()}{Environment.NewLine}Corps: {Corps}";
}

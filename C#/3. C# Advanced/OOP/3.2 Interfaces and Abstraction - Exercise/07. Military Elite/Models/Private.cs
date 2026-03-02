using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models;

public class Private : RegularSoldier, IPrivate
{
    public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
    {
    }
}

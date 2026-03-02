namespace MilitaryElite.Models;

public abstract class RegularSoldier : Soldier
{
    protected RegularSoldier(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public decimal Salary { get; }

    public override string ToString() => $"{base.ToString()} Salary: {Salary:f2}";
}

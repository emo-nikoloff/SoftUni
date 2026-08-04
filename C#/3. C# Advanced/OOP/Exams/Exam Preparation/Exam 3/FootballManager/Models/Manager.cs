using FootballManager.Models.Contracts;
using static FootballManager.Utilities.Messages.ExceptionMessages;

namespace FootballManager.Models;

public abstract class Manager : IManager
{
    private string name = null!;

    private double ranking;

    protected Manager(string name, double ranking)
    {
        Name = name;
        Ranking = ranking;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ManagerNameNull);
            }
            name = value;
        }
    }

    public double Ranking
    {
        get => ranking;
        protected set => ranking = value;
    }

    public abstract void RankingUpdate(double updateValue);

    public override string ToString() => $"{Name} - {GetType().Name} (Ranking: {Ranking:F2})";
}

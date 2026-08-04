using FootballManager.Models.Contracts;
using static FootballManager.Utilities.Messages.ExceptionMessages;

namespace FootballManager.Models;

public class Team : ITeam
{
    private string name = null!;

    private int championshipPoints;

    private IManager? teamManager;

    public Team(string name)
    {
        Name = name;
        championshipPoints = 0;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(TeamNameNull);
            }
            name = value;
        }
    }

    public int ChampionshipPoints
    {
        get => championshipPoints;
        private set => championshipPoints = value;
    }

    public IManager TeamManager
    {
        get => teamManager!;
        private set => teamManager = value;
    }

    public int PresentCondition
    {
        get
        {
            if (TeamManager == null)
            {
                return 0;
            }

            if (ChampionshipPoints == 0)
            {
                return (int)Math.Round(TeamManager.Ranking);
            }

            return (int)Math.Round(ChampionshipPoints * TeamManager.Ranking);
        }
    }

    public void GainPoints(int points) => ChampionshipPoints += points;

    public void ResetPoints() => ChampionshipPoints = 0;

    public void SignWith(IManager manager) => TeamManager = manager;

    public override string ToString() => $"Team: {Name} Points: {ChampionshipPoints}";
}

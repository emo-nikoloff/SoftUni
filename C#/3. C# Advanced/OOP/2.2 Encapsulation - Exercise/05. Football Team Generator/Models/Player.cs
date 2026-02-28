namespace FootballTeamGenerator.Models;

public class Player
{
    private const int MinStat = 0;
    private const int MaxStat = 100;

    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }
    public int Endurance
    {
        get => endurance;
        private set => endurance = ValidateStat(value, nameof(Endurance));
    }
    public int Sprint
    {
        get => sprint;
        private set => sprint = ValidateStat(value, nameof(Sprint));
    }
    public int Dribble
    {
        get => dribble;
        private set => dribble = ValidateStat(value, nameof(Dribble));
    }
    public int Passing
    {
        get => passing;
        private set => passing = ValidateStat(value, nameof(Passing));
    }
    public int Shooting
    {
        get => shooting;
        private set => shooting = ValidateStat(value, nameof(Shooting));
    }
    public double SkillLevel => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;

    private int ValidateStat(int value, string stat)
    {
        if (value < MinStat || value > MaxStat)
        {
            throw new ArgumentException($"{stat} should be between 0 and 100.");
        }
        return value;
    }
}

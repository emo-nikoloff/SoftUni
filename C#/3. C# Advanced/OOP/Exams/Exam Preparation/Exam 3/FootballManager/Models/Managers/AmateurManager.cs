namespace FootballManager.Models.Managers;

public class AmateurManager : Manager
{
    private const double InitialRanking = 15.0;

    public AmateurManager(string name)
        : base(name, InitialRanking)
    {
    }

    public override void RankingUpdate(double updateValue) => Ranking += updateValue * 0.75;
}

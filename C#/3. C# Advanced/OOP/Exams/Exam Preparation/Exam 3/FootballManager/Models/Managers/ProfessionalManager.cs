namespace FootballManager.Models.Managers;

public class ProfessionalManager : Manager
{
    private const double InitialRanking = 60.0;

    public ProfessionalManager(string name)
        : base(name, InitialRanking)
    {
    }

    public override void RankingUpdate(double updateValue) => Ranking += updateValue * 1.5;
}

using System.Text;

using FootballManager.Core.Contracts;
using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Models.Managers;
using FootballManager.Repositories;
using FootballManager.Repositories.Contracts;
using static FootballManager.Utilities.Messages.OutputMessages;

namespace FootballManager.Core;

public class Controller : IController
{
    private IRepository<ITeam> championship;

    public Controller()
    {
        championship = new TeamRepository();
    }

    public string JoinChampionship(string teamName)
    {
        if (championship.Models.Count == championship.Capacity)
        {
            return ChampionshipFull;
        }

        if (championship.Exists(teamName))
        {
            return string.Format(TeamWithSameNameExisting, teamName);
        }

        ITeam team = new Team(teamName);
        championship.Add(team);

        return string.Format(TeamSuccessfullyJoined, teamName);
    }

    public string SignManager(string teamName, string managerTypeName, string managerName)
    {
        if (!championship.Exists(teamName))
        {
            return string.Format(TeamDoesNotTakePart, teamName);
        }

        if (managerTypeName is not (nameof(AmateurManager) or nameof(SeniorManager) or nameof(ProfessionalManager)))
        {
            return string.Format(ManagerTypeNotPresented, managerTypeName);
        }

        ITeam team = championship.Get(teamName);
        if (team.TeamManager != null)
        {
            return string.Format(TeamSignedWithAnotherManager, team.Name, team.TeamManager.Name);
        }

        IEnumerable<ITeam> teamsWithManager = championship.Models.Where(t => t.TeamManager != null);
        if (teamsWithManager.Any(t => t.TeamManager.Name == managerName))
        {
            return string.Format(ManagerAssignedToAnotherTeam, managerName);
        }

        IManager manager = managerTypeName switch
        {
            nameof(AmateurManager) => new AmateurManager(managerName),
            nameof(SeniorManager) => new SeniorManager(managerName),
            nameof(ProfessionalManager) => new ProfessionalManager(managerName),
            _ => null!
        };

        team.SignWith(manager);

        return string.Format(TeamSuccessfullySignedWithManager, manager.Name, team.Name);
    }

    public string MatchBetween(string teamOneName, string teamTwoName)
    {
        const int winPoints = 3;
        const int workingManagerRankingPoints = 5;
        const int drawPoints = 1;

        if (!championship.Exists(teamOneName)
            || !championship.Exists(teamTwoName))
        {
            return OneOfTheTeamDoesNotExist;
        }

        ITeam teamOne = championship.Get(teamOneName);
        ITeam teamTwo = championship.Get(teamTwoName);

        ITeam winningTeam, losingTeam;
        if (teamOne.PresentCondition > teamTwo.PresentCondition)
        {
            winningTeam = teamOne;
            losingTeam = teamTwo;
        }
        else if (teamOne.PresentCondition < teamTwo.PresentCondition)
        {
            winningTeam = teamTwo;
            losingTeam = teamOne;
        }
        else
        {
            teamOne.GainPoints(drawPoints);
            teamTwo.GainPoints(drawPoints);

            return string.Format(MatchIsDraw, teamOne.Name, teamTwo.Name);
        }

        winningTeam.GainPoints(winPoints);

        if (winningTeam.TeamManager != null)
        {
            winningTeam.TeamManager.RankingUpdate(workingManagerRankingPoints);
        }

        if (losingTeam.TeamManager != null)
        {
            losingTeam.TeamManager.RankingUpdate(-workingManagerRankingPoints);
        }

        return string.Format(TeamWinsMatch, winningTeam.Name, losingTeam.Name);
    }

    public string PromoteTeam(string droppingTeamName, string promotingTeamName, string managerTypeName, string managerName)
    {
        if (!championship.Exists(droppingTeamName))
        {
            return string.Format(DroppingTeamDoesNotExist, droppingTeamName);
        }

        if (championship.Exists(promotingTeamName))
        {
            return string.Format(TeamWithSameNameExisting, promotingTeamName);
        }

        ITeam promotingTeam = new Team(promotingTeamName);

        IEnumerable<ITeam> teamsWithManager = championship.Models.Where(t => t.TeamManager != null);
        if ((!teamsWithManager.Any(t => t.TeamManager.Name == managerName))
            && (managerTypeName is nameof(AmateurManager) or nameof(SeniorManager) or nameof(ProfessionalManager)))
        {
            IManager manager = managerTypeName switch
            {
                nameof(AmateurManager) => new AmateurManager(managerName),
                nameof(SeniorManager) => new SeniorManager(managerName),
                nameof(ProfessionalManager) => new ProfessionalManager(managerName),
                _ => null!
            };

            promotingTeam.SignWith(manager);
        }

        championship.Models.ToList().ForEach(t => t.ResetPoints());
        championship.Remove(droppingTeamName);
        championship.Add(promotingTeam);

        return string.Format(TeamHasBeenPromoted, promotingTeam.Name);
    }

    public string ChampionshipRankings()
    {
        StringBuilder result = new();

        IEnumerable<ITeam> orderedTeams = championship.Models
            .OrderByDescending(t => t.ChampionshipPoints)
            .ThenByDescending(t => t.PresentCondition);

        int counter = 1;

        result.AppendLine("***Ranking Table***");
        foreach (ITeam team in orderedTeams)
        {
            result.AppendLine($"{counter++}. {team.ToString()}/{team.TeamManager.ToString()}");
        }

        return result.ToString().TrimEnd();
    }
}

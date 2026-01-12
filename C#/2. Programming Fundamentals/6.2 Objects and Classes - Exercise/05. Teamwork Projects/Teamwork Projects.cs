/*It's time for the teamwork projects and you are responsible for gathering the teams. First, you will receive an integer – the count of the teams you will have to register. You will be given a user
and a team, separated with "-". The user is the creator of the team. For every newly created team you should print a message:
"Team {teamName} has been created by {user}!".
Next, you will receive а user with a team, separated with "->", which means that the user wants to join that team. Upon receiving the command: "end of assignment", you should print every team, ordered
by the count of its members (descending) and then by name (ascending). For each team, you have to print its members sorted by name (ascending). However, there are several rules:
· If а user tries to create a team more than once, a message should be displayed:
- "Team {teamName} was already created!"
· A creator of a team cannot create another team – the following message should be thrown:
- "{user} cannot create another team!"
· If а user tries to join a non-existent team, a message should be displayed:
- "Team {teamName} does not exist!"
· A member of a team cannot join another team – the following message should be thrown:
- "Member {user} cannot join team {team Name}!"
· In the end, teams with zero members (with only a creator) should disband and you have to print them ordered by name in ascending order.
· Every valid team should be printed ordered by name (ascending) in the following format:
"{teamName} 
- {creator} 
-- {member}…"*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects;

class Program
{
    static void Main(string[] args)
    {
        int teamsCount = int.Parse(Console.ReadLine());
        List<Team> teams = new();

        for (int i = 1; i <= teamsCount; i++)
        {
            string[] teamInfo = Console.ReadLine().Split("-");
            string teamCreator = teamInfo[0];
            string teamName = teamInfo[1];

            Team existingTeam = teams.Find(t => t.Name == teamName);
            if (existingTeam != null)
            {
                Console.WriteLine($"Team {teamName} was already created!");
                continue;
            }

            Team existingCreator = teams.Find(t => t.Creator == teamCreator);
            if (existingCreator != null)
            {
                Console.WriteLine($"{teamCreator} cannot create another team!");
                continue;
            }

            Team team = new(teamName, teamCreator);

            teams.Add(team);

            Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
        }

        string action;
        while ((action = Console.ReadLine()) != "end of assignment")
        {
            string[] userAction = action.Split("->");
            string user = userAction[0];
            string teamName = userAction[1];

            if (!teams.Any(t => t.Name == teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist!");
                continue;
            }

            if (teams.Any(t => t.Creator == user) ||
                teams.Any(t => t.Members.Contains(user)))
            {
                Console.WriteLine($"Member {user} cannot join team {teamName}!");
                continue;
            }

            Team foundTeam = teams.Find(t => t.Name == teamName);
            foundTeam.Members.Add(user);
        }

        List<Team> validTeams = teams.Where(t => t.Members.Count > 0).ToList();
        List<Team> disbandTeams = teams.Where(t => t.Members.Count == 0).ToList();

        List<Team> sortedTeams = validTeams.OrderByDescending(t => t.Members.Count).ThenBy(t => t.Name).ToList();

        sortedTeams.ForEach(t => Console.WriteLine(t));

        Console.WriteLine("Teams to disband:");
        sortedTeams = disbandTeams.OrderBy(t => t.Name).ToList();
        sortedTeams.ForEach(t => Console.WriteLine(t.Name));
    }
}

class Team
{
    public Team(string name, string creator)
    {
        Name = name;
        Creator = creator;
        Members = new();
    }

    public string Name { get; set; }
    public string Creator { get; set; }
    public List<string> Members { get; set; }
    public override string ToString()
    {
        string result = $"{Name}\n";
        result += $"- {Creator}\n";
        Members = Members.OrderBy(member => member).ToList();

        int i = 0;
        for (; i < Members.Count - 1; i++)
        {
            result += $"-- {Members[i]}\n";
        }
        result += $"-- {Members[i]}";

        return result;
    }
}

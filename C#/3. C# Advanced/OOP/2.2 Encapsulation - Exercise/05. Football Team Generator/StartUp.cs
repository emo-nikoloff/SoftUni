using FootballTeamGenerator.Models;

namespace FootballTeamGenerator;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Team> teams = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputInfo = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
            string command = inputInfo[0];

            try
            {
                switch (command)
                {
                    case "Team":
                        {
                            string teamName = inputInfo[1];

                            Team team = new Team(teamName);
                            teams.Add(teamName, team);
                            break;
                        }
                    case "Add":
                        {
                            string teamName = inputInfo[1];

                            if (!teams.ContainsKey(teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            string playerName = inputInfo[2];
                            int endurance = int.Parse(inputInfo[3]);
                            int sprint = int.Parse(inputInfo[4]);
                            int dribble = int.Parse(inputInfo[5]);
                            int passing = int.Parse(inputInfo[6]);
                            int shooting = int.Parse(inputInfo[7]);

                            Player player = new(playerName, endurance, sprint, dribble, passing, shooting);

                            teams[teamName].AddPlayer(player);
                            break;
                        }
                    case "Remove":
                        {
                            string teamName = inputInfo[1];

                            if (!teams.ContainsKey(teamName))
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                                continue;
                            }

                            string playerName = inputInfo[2];

                            teams[teamName].RemovePlayer(playerName);
                            break;
                        }
                    case "Rating":
                        {
                            string teamName = inputInfo[1];

                            if (!teams.ContainsKey(teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                            }
                            break;
                        }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

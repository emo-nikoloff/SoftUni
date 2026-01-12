/*Peter is a pro-MOBA player, he is struggling to become а master of the Challenger tier. So he watches carefully the statistics in the tier.
You will receive several input lines in one of the following formats:
"{player} -> {position} -> {skill}"
"{player} vs {player}"
The player and position are strings, the given skill will be an integer number. You need to keep track of every player.
When you receive a player and their position and skill, add them to the player pool, if they aren't present, else add their position and skill or update their skill, only if the current position skill
is lower than the new value.
If you receive "{player} vs {player}" and both players exist in the tier, they duel with the following rules:
Compare their positions, if they have at least one in common, the player with better total skill points wins and the other is demoted from the tier -> remove him/her. If they have the same total skill
points, the duel is a tie and they both continue in the season.
If they don't have positions in common, the duel isn't happening and both continue in the Season.
You should end your program when you receive the command "Season end". At that point, you should print the players, ordered by total skill in descending order, then ordered by player name in ascending
order. Foreach player print their position and skill, ordered descending by skill, then ordered by position name in ascending order.
· The input comes in the form of commands in one of the formats specified above.
· Player and position will always be one-word string, containing no whitespaces.
· Skill will be an integer in the range [0…1000].
· There will be no invalid input lines.
· The programm ends when you receive the command "Season end".
· The output format for each player is:
"{player}: {totalSkill} skill"
"- {position} <::> {skill}"*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger;

class Program
{
    static void Main(string[] args)
    {
        string input;
        Dictionary<string, Dictionary<string, int>> players = new();

        while ((input = Console.ReadLine()) != "Season end")
        {
            if (input.Contains(" -> "))
            {
                string[] inputArgs = input.Split(" -> ");

                string player = inputArgs[0];
                string position = inputArgs[1];
                int skillPoints = int.Parse(inputArgs[2]);

                if (!players.ContainsKey(player))
                {
                    players.Add(player, new());
                }

                if (!players[player].ContainsKey(position))
                {
                    players[player].Add(position, skillPoints);
                }
                else if (players[player][position] < skillPoints)
                {
                    players[player][position] = skillPoints;
                }
            }
            else if (input.Contains(" vs "))
            {
                string[] inputArgs = input.Split(" vs ");

                string firstPlayer = inputArgs[0];
                string secondPlayer = inputArgs[1];

                if (players.ContainsKey(firstPlayer) && players.ContainsKey(secondPlayer))
                {
                    Dictionary<string, int>.KeyCollection firstPlayerPositions = players[firstPlayer].Keys;
                    Dictionary<string, int>.KeyCollection secondPlayerPositions = players[secondPlayer].Keys;

                    bool commonPosition = firstPlayerPositions.Intersect(secondPlayerPositions).Any();

                    if (commonPosition)
                    {
                        int firstPlayerTotalPoints = players[firstPlayer].Values.Sum();
                        int secondPlayerTotalPoints = players[secondPlayer].Values.Sum();

                        if (firstPlayerTotalPoints > secondPlayerTotalPoints)
                        {
                            players.Remove(secondPlayer);
                        }
                        else if (secondPlayerTotalPoints > firstPlayerTotalPoints)
                        {
                            players.Remove(firstPlayer);
                        }
                    }
                }
            }
        }

        foreach ((string player, Dictionary<string, int> playersPositions) in players
            .OrderByDescending(totalPoints => totalPoints.Value.Values.Sum())
            .ThenBy(playerName => playerName.Key))
        {
            Console.WriteLine($"{player}: {playersPositions.Values.Sum()} skill");

            foreach ((string position, int points) in playersPositions.OrderByDescending(points => points.Value).ThenBy(position => position.Key))
            {
                Console.WriteLine($"- {position} <::> {points}");
            }
        }
    }
}

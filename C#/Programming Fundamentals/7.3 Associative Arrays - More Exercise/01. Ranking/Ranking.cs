/*Here comes the final and the most interesting part – the Final ranking of the candidate-interns. The final ranking is determined by the points of the interview tasks and from the exams in SoftUni.
Here is your final task. You will receive some lines of input in the format "{contest}:{password for contest}", until you receive "end of contests". Save that data, because you will need it later.
After that, you will receive another type of input in the format "{contest}=>{password}=>{username}=>{points}" until you receive "end of submissions". Here is what you need to do:
· Check if the contest is valid (if you received it in the first type of input).
· Check if the password is correct for the given contest.
· Save the user with the contest they take part in (a user can take part in many contests) and the points the user has in the given contest. If you receive the same contest and the same user, update
the points, only if the new ones are more than the older ones.
In the end, you have to print the info for the user with the most points in the format "Best candidate is {user} with total {total points} points.". After that print all students ordered by their
names. For each user print each contest with the points in descending order. See the examples.
· Strings in format "{contest}:{password for contest}" until the "end of contests" command. There will be no case with two equal contests.
· Strings in format "{contest}=>{password}=>{username}=>{points}", until the "end of submissions" command.
· There will be no case with 2 or more users with the same total points!
· On the first line, print the best user in format "Best candidate is {user} with total {total points} points.".
· Then print all students, ordered as mentioned above, in format:
"{user1 name}"
"# {contest1} -> {points}"
"# {contest2} -> {points}"*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking;

class Program
{
    static void Main(string[] args)
    {
        string input;
        Dictionary<string, string> contests = new();

        while ((input = Console.ReadLine()) != "end of contests")
        {
            string[] inputArgs = input.Split(":");

            string contestName = inputArgs[0];
            string contestPassword = inputArgs[1];

            contests.Add(contestName, contestPassword);
        }

        SortedDictionary<string, Dictionary<string, int>> users = new();

        while ((input = Console.ReadLine()) != "end of submissions")
        {
            string[] inputArgs = input.Split("=>");

            string contestName = inputArgs[0];
            string contestPassword = inputArgs[1];
            string username = inputArgs[2];
            int points = int.Parse(inputArgs[3]);

            if (!contests.ContainsKey(contestName) || (contests.ContainsKey(contestName) && !contests.ContainsValue(contestPassword)))
            {
                continue;
            }

            if (!users.ContainsKey(username))
            {
                users.Add(username, new());
            }

            if (!users[username].ContainsKey(contestName))
            {
                users[username].Add(contestName, points);
            }
            else if (users[username][contestName] < points)
            {
                users[username][contestName] = points;
            }
        }

        string bestCandidate = string.Empty;
        int bestCandidateTotalPoints = 0;

        foreach ((string user, Dictionary<string, int> contestsPoints) in users)
        {
            int totalPoints = contestsPoints.Values.Sum();

            if (totalPoints > bestCandidateTotalPoints)
            {
                bestCandidateTotalPoints = totalPoints;
                bestCandidate = user;
            }
        }

        Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidateTotalPoints} points.");
        Console.WriteLine("Ranking: ");

        foreach ((string user, Dictionary<string, int> contestsPoints) in users)
        {
            Console.WriteLine($"{user}");

            foreach ((string contest, int points) in contestsPoints.OrderByDescending(p => p.Value))
            {
                Console.WriteLine($"#  {contest} -> {points}");
            }
        }
    }
}

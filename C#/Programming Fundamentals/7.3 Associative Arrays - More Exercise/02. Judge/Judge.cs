/*You know the judge system, right? Your job is to create a program similar to the Judge system.
You will receive several input lines in one of the following formats:
"{username} -> {contest} -> {points}"
The constestName and username are strings, the given points will be an integer number. You need to keep track of every contest and individual statistics of every user. You should check if such a
contest already exists and if not, add it, otherwise, check if the current user is participating in the contest. If they are participating, take the higher score, otherwise, just add it.
Also, you need to keep individual statistics for each user - the total points of all contests.
You should end your program when you receive the command "no more time". At that point, you should print each contest in order of input, for each contest print the participants ordered by points in
descending order, then ordered by name in ascending order. After that, you should print individual statistics for every participant, ordered by total points in descending order, and then by
alphabetical order.
· The input comes in the form of commands in one of the formats specified above.
· Username and contest name always will be one word.
· Points will be an integer in the range [0…1000].
· There will be no invalid input lines.
· If all sorting criteria fail, the order should be by order of input.
· The input ends when you receive the command "no more time".
· The output format for the contests is:
"{constestName}: {participants.Count} participants"
"{position}. {username} <::> {points}"
· After you print all contests, print the individual statistics for every participant.
· The output format is:
"Individual standings:"
"{position}. {username} -> {totalPoints}"*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge;

class Program
{
    static void Main(string[] args)
    {
        string input;
        Dictionary<string, Dictionary<string, int>> contests = new();
        Dictionary<string, int> individualStats = new();

        while ((input = Console.ReadLine()) != "no more time")
        {
            string[] inputArgs = input.Split(" -> ");

            string username = inputArgs[0];
            string contest = inputArgs[1];
            int points = int.Parse(inputArgs[2]);

            if (!contests.ContainsKey(contest))
            {
                contests.Add(contest, new());
            }

            if (!contests[contest].ContainsKey(username))
            {
                contests[contest].Add(username, points);

                if (!individualStats.ContainsKey(username))
                {
                    individualStats.Add(username, points);
                    continue;
                }
                individualStats[username] += points;
            }
            else if (contests[contest][username] < points)
            {
                int difference = points - contests[contest][username];
                contests[contest][username] = points;
                individualStats[username] += difference;
            }
        }

        foreach ((string contest, Dictionary<string, int> participants) in contests)
        {
            Console.WriteLine($"{contest}: {participants.Count} participants");

            int position = 1;
            foreach ((string name, int points) in participants.OrderByDescending(p => p.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{position}. {name} <::> {points}");
                position++;
            }
        }

        Console.WriteLine("Individual standings:");

        int place = 1;
        foreach ((string name, int points) in individualStats.OrderByDescending(p => p.Value).ThenBy(n => n.Key))
        {
            Console.WriteLine($"{place}. {name} -> {points}");
            place++;
        }
    }
}

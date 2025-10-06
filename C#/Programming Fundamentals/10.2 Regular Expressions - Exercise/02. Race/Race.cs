/*Write a program that processes information about a race. On the first line, you will be given a list of participants separated by ", ". On the next few lines, until you receive a line "end of race",
you will be given some info which will be some alphanumeric characters. In between them, you could have some extra characters which you should ignore. For example: "G!32e%o7r#32g$235@!2e".
The letters are the name of the person and the sum of the digits is the distance he ran. So here we have George who ran 29 km. Store the information about the person
only if the list of racers contains the name of the person. If you receive the same person more than once, just add the distance to his old distance. At the end print the top 3 racers in the format:
"1st place: {first racer}
2nd place: {second racer}
3rd place: {third racer}"*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race;

class Program
{
    static void Main(string[] args)
    {
        string[] participantsNames = Console.ReadLine().Split(", ");
        Dictionary<string, Participant> participants = new();

        foreach (string participant in participantsNames)
        {
            participants.Add(participant, new(participant));
        }

        string input;

        string lettersPattern = @"[A-Za-z]";
        string digitsPattern = @"\d";

        while ((input = Console.ReadLine()) != "end of race")
        {
            StringBuilder name = new();

            foreach (Match match in Regex.Matches(input, lettersPattern))
            {
                name.Append(match.Value);
            }

            int distance = 0;

            if (participants.ContainsKey(name.ToString()))
            {
                foreach (Match match in Regex.Matches(input, digitsPattern))
                {
                    distance += int.Parse(match.Value);
                }

                participants[name.ToString()].Distance += distance;
            }
        }

        List<KeyValuePair<string, Participant>> orderedParticipants = participants.OrderByDescending(p => p.Value.Distance).Take(3).ToList();

        Console.WriteLine($"1st place: {orderedParticipants[0].Value.Name}");
        Console.WriteLine($"2nd place: {orderedParticipants[1].Value.Name}");
        Console.WriteLine($"3rd place: {orderedParticipants[2].Value.Name}");
    }
}

class Participant
{
    public Participant(string name)
    {
        Name = name;
        Distance = 0;
    }

    public string Name { get; set; }
    public int Distance { get; set; }
}

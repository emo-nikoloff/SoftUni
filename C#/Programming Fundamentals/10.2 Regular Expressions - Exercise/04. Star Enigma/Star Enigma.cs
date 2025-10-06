/*The war is at its peak, but you, young Padawan, can turn the tides with your programming skills. You are tasked to create a program to decrypt the messages of The Order and prevent the death of
hundreds of lives.
You will receive several messages, which are encrypted, using the legendary star enigma. You should decrypt the messages, following these rules:
To properly decrypt a message, you should count all the letters [s, t, a, r] – case insensitive and remove the count from the current ASCII value of each symbol of the encrypted message.
After decryption:
· Each message should have a planet name, population, attack type ('A' as an attack or 'D' as destruction), and soldier count.
· The planet name starts after '@' and contains only letters from the Latin alphabet.
· The planet population starts after ':' and is an Integer.
· The attack type may be "A"(attack) or "D"(destruction) and must be surrounded by "!" (exclamation mark).
· The soldier count starts after "->" and should be an Integer.
The order in the message should be: planet name -> planet population -> attack type -> soldier count. Each part can be separated from the others by any character except '@', '-', '!', ':' and '>'.
· The first line holds n – the number of messages– integer in the range [1…100].
· On the next n lines, you will be receiving encrypted messages.
After decrypting all messages, you should print the decrypted information in the following format:
First print the attacked planets, then the destroyed planets. "Attacked planets: {attackedPlanetsCount}" "-> {planetName}" "Destroyed planets: {destroyedPlanetsCount}" "-> {planetName}"
The planets should be ordered by name alphabetically.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma;

class Program
{
    static void Main(string[] args)
    {
        string starPattern = @"[STARstar]";
        int messagesNumber = int.Parse(Console.ReadLine());
        List<Message> messages = new();

        for (int i = 1; i <= messagesNumber; i++)
        {
            string encryptMessage = Console.ReadLine();

            int decryptionKey = Regex.Matches(encryptMessage, starPattern).Count;

            StringBuilder encryptedMessage = new();

            for (int j = 0; j < encryptMessage.Length; j++)
            {
                int encrypted = encryptMessage[j] - decryptionKey;
                char encryptedLetter = (char)encrypted;

                encryptedMessage.Append(encryptedLetter);
            }

            string pattern = @"@(?<planet>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<action>[AD])![^@\-!:>]*->(?<soldier>\d+)[^@\-!:>\n]*";

            Match match = Regex.Match(encryptedMessage.ToString(), pattern);

            if (match.Success)
            {
                string planetName = match.Groups["planet"].Value;
                int population = int.Parse(match.Groups["population"].Value);
                char action = char.Parse(match.Groups["action"].Value);
                int soldiers = int.Parse(match.Groups["soldier"].Value);

                Message message = new(planetName, population, action, soldiers);

                messages.Add(message);
            }
        }

        List<Message> filteredMessagesByAction = messages.Where(msg => msg.Action == 'A').OrderBy(msg => msg.PlanetName).ToList();

        Console.WriteLine($"Attacked planets: {filteredMessagesByAction.Count}");
        filteredMessagesByAction.ForEach(msg => Console.WriteLine($"-> {msg.PlanetName}"));

        filteredMessagesByAction = messages.Where(msg => msg.Action == 'D').OrderBy(msg => msg.PlanetName).ToList();

        Console.WriteLine($"Destroyed planets: {filteredMessagesByAction.Count}");
        filteredMessagesByAction.ForEach(msg => Console.WriteLine($"-> {msg.PlanetName}"));
    }
}

class Message
{
    public Message(string planetName, int population, char action, int soldiers)
    {
        PlanetName = planetName;
        Population = population;
        Action = action;
        Soldiers = soldiers;
    }

    public string PlanetName { get; set; }
    public int Population { get; set; }
    public char Action { get; set; }
    public int Soldiers { get; set; }
}

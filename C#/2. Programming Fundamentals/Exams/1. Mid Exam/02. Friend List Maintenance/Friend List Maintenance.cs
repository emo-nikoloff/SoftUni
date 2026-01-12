/**/
using System;

namespace _02._Friend_List_Maintenance;

class Program
{
    static void Main(string[] args)
    {
        string[] friends = Console.ReadLine().Split(", ");
        string command;

        int blacklistCounter = 0, lostCounter = 0;

        while ((command = Console.ReadLine()) != "Report")
        {
            string[] commandParts = command.Split();

            switch (commandParts[0])
            {
                case "Blacklist":
                    string name = commandParts[1];

                    int tempBlacklistCounter = blacklistCounter;

                    for (int i = 0; i < friends.Length; i++)
                    {
                        if (friends[i] == name)
                        {
                            Console.WriteLine($"{name} was blacklisted.");
                            friends[i] = "Blacklisted";
                            blacklistCounter++;
                            break;
                        }
                    }
                    if (blacklistCounter == tempBlacklistCounter)
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                    break;
                case "Error":
                    int errorIndex = int.Parse(commandParts[1]);

                    if (errorIndex >= 0 && errorIndex < friends.Length && friends[errorIndex] != "Blacklisted" && friends[errorIndex] != "Lost")
                    {
                        Console.WriteLine($"{friends[errorIndex]} was lost due to an error.");
                        friends[errorIndex] = "Lost";
                        lostCounter++;
                    }
                    break;
                case "Change":
                    int changeIndex = int.Parse(commandParts[1]);
                    string changeName = commandParts[2];

                    if (changeIndex >= 0 && changeIndex < friends.Length)
                    {
                        string currentName = friends[changeIndex];
                        friends[changeIndex] = changeName;

                        Console.WriteLine($"{currentName} changed his username to {changeName}.");
                    }

                    break;
            }
        }

        Console.WriteLine($"Blacklisted names: {blacklistCounter}");
        Console.WriteLine($"Lost names: {lostCounter}");
        Console.WriteLine(string.Join(" ", friends));
    }
}

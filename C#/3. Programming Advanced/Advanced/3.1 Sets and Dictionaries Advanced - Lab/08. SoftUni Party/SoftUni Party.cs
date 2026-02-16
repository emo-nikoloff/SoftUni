/*There is a party in SoftUni. Many guests are invited and there are two types of them: VIP and Regular. When a guest comes, check if he/she exists in any of the two reservation lists. All
reservation numbers will be with the length of 8 chars. All VIP numbers start with a digit. First, you will be receiving the reservation numbers of the guests.
You can also receive 2 possiblecommands:
· "PARTY" – After this command, you will begin receiving the reservation numbers of the people, who came to the party.
· "END" – The party is over and you have to stop the program and print the appropriate output.
In the end, print the count of the guests who didn't come to the party, and afterward, print their reservation numbers. the VIP guests must be first.*/
namespace _08._SoftUni_Party;

class Program
{
    static void Main(string[] args)
    {
        HashSet<string> reservations = new();
        HashSet<string> VIPs = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "PARTY")
        {
            if (char.IsDigit(input[0]))
            {
                VIPs.Add(input);
            }
            else
            {
                reservations.Add(input);
            }
        }

        while ((input = Console.ReadLine()) != "END")
        {
            if (char.IsDigit(input[0]))
            {
                VIPs.Remove(input);
            }
            else
            {
                reservations.Remove(input);
            }
        }

        Console.WriteLine(reservations.Count + VIPs.Count);
        foreach (string VIP in VIPs)
        {
            Console.WriteLine(VIP);
        }
        foreach (string guest in reservations)
        {
            Console.WriteLine(guest);
        }
    }
}

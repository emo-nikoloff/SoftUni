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

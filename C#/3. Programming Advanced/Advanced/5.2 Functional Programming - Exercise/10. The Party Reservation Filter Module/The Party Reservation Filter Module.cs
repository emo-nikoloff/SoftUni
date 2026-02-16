/*You need to implement a filtering module to a party reservation software. First, the Party Reservation Filter Module (PRFM for short) has been passed a list with invitations. Next, the PRFM
receives a sequence of commands that specify whether you need to add or remove a given filter.
Each PRFM command is in the given format:
"{command;filter type;filter parameter}"
You can receive the following PRFM commands:
· "Add filter"
· "Remove filter"
· "Print"
The possible PRFM filter types are:
· "Starts with"
· "Ends with"
· "Length"
· "Contains"
All PRFM filter parameters will be a string (or an integer only for the "Length" filter). Each command will be valid e.g. you won't be asked to remove a non-existent filter. The input will end
with a "Print" command, after which you should print all the party-goers that are left after the filtration.*/
namespace _10._The_Party_Reservation_Filter_Module;

class Program
{
    static void Main(string[] args)
    {
        List<string> guests = Console.ReadLine().Split().ToList();

        string input = string.Empty;
        List<string> filters = new();
        while ((input = Console.ReadLine()) != "Print")
        {
            string[] info = input.Split(';');
            string command = info[0];
            string criteria = info[1];
            string value = info[2];
            switch (command)
            {
                case "Add filter":
                    filters.Add($"{criteria}-{value}");
                    break;
                case "Remove filter":
                    filters.Remove($"{criteria}-{value}");
                    break;
            }
        }

        foreach (string filter in filters)
        {
            string[] currentFilter = filter.Split("-");
            guests = guests.FindAll(GetPredicate(currentFilter[0], currentFilter[1]));
        }

        Console.WriteLine(string.Join(" ", guests));
    }
    static Predicate<string> GetPredicate(string criteria, string value)
    {
        switch (criteria)
        {
            case "Starts with":
                return n => !n.StartsWith(value);
            case "Ends with":
                return n => !n.EndsWith(value);
            case "Length":
                return n => !(n.Length == int.Parse(value));
            case "Contains":
                return n => !n.Contains(value);
            default:
                return null;
        }
    }
}

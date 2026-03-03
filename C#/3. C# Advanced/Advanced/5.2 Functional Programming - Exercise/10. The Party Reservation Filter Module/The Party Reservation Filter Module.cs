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

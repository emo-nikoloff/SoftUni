/*Ivan's parents are on a vacation for the holidays and he is planning an epic party at home. Unfortunately, his organizational skills are next to non-existent, so you are given the task to help
him with the reservations. On the first line, you receive a list of all the people that are coming. On the next lines, until you get the "Party!" command, you may be asked to double or remove all
the people that apply to the given criteria. There are three different criteria:
· Everyone that has a name starting with a given string
· Everyone that has a name ending with a given string
· Everyone that has a name with a given length
Finally, print all the guests who are going to the party separated by ", " and then add the ending "are going to the party!". If no guests are going to the party print "Nobody is going to the
party!".*/
namespace _09._Predicate_Party_;

class Program
{
    static void Main(string[] args)
    {
        List<string> guests = Console.ReadLine().Split().ToList();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Party!")
        {
            string[] info = input.Split();
            string command = info[0];
            string criteria = info[1];
            string value = info[2];
            switch (command)
            {
                case "Double":
                    List<string> peopleToDouble = guests.FindAll(GetPredicate(criteria, value));
                    foreach (string person in peopleToDouble)
                    {
                        int index = guests.IndexOf(person);
                        guests.Insert(index, person);
                    }
                    break;
                case "Remove":
                    guests.RemoveAll(GetPredicate(criteria, value));
                    break;
            }
        }

        if (guests.Count == 0)
        {
            Console.WriteLine("Nobody is going to the party!");
        }
        else
        {
            Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
        }
    }

    static Predicate<string> GetPredicate(string criteria, string value)
    {
        switch (criteria)
        {
            case "StartsWith":
                return n => n.StartsWith(value);
            case "EndsWith":
                return n => n.EndsWith(value);
            case "Length":
                return n => n.Length == int.Parse(value);
            default:
                return null;
        }
    }
}

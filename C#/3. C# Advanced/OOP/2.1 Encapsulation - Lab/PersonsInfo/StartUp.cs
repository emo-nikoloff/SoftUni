namespace PersonsInfo;

public class StartUp
{
    static void Main(string[] args)
    {
        int peopleCount = int.Parse(Console.ReadLine());

        List<Person> people = new();

        for (int i = 1; i <= peopleCount; i++)
        {
            string[] personInfo = Console.ReadLine().Split();

            string firstName = personInfo[0];
            string lastName = personInfo[1];
            int age = int.Parse(personInfo[2]);
            decimal salary = decimal.Parse(personInfo[3]);

            Person person = new(firstName, lastName, age, salary);

            people.Add(person);
        }

        decimal percentage = decimal.Parse(Console.ReadLine());

        people.ForEach(p => p.IncreaseSalary(percentage));
        people.ForEach(Console.WriteLine);

        Team team = new Team("SoftUni");

        foreach (Person person in people)
        {
            team.AddPlayer(person);
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
    }
}

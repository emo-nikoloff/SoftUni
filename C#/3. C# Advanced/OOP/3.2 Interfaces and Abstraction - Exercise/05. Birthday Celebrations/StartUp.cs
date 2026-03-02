using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IIdentifiable> society = new();
        List<IBirthable> creatures = new();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (inputInfo[0])
            {
                case "Citizen":
                    string citizenName = inputInfo[1];
                    int citizenAge = int.Parse(inputInfo[2]);
                    string citizenId = inputInfo[3];
                    string citizenBirthdate = inputInfo[4];

                    Citizen citizen = new(citizenName, citizenAge, citizenId, citizenBirthdate);

                    society.Add(citizen);
                    creatures.Add(citizen);
                    break;
                case "Pet":
                    string petName = inputInfo[1];
                    string petBirthdate = inputInfo[2];

                    Pet pet = new(petName, petBirthdate);

                    creatures.Add(pet);
                    break;
                case "Robot":
                    string robotModel = inputInfo[1];
                    string robotId = inputInfo[2];

                    Robot robot = new(robotModel, robotId);
                    society.Add(robot);
                    break;
            }
        }
        string birthYear = Console.ReadLine();

        foreach (IBirthable birthable in creatures)
        {
            if (birthable.Birthdate.EndsWith(birthYear))
            {
                Console.WriteLine(birthable.Birthdate);
            }
        }
    }
}

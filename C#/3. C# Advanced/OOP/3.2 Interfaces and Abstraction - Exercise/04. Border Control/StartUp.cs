using BorderControl.Interfaces;
using BorderControl.Models;

namespace BorderControl;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IIdentifiable> society = new();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IIdentifiable identifiable;

            if (inputInfo.Length == 3)
            {
                string name = inputInfo[0];
                int age = int.Parse(inputInfo[1]);
                string id = inputInfo[2];

                identifiable = new Citizen(name, age, id);
                society.Add(identifiable);
            }
            else if (inputInfo.Length == 2)
            {
                string model = inputInfo[0];
                string id = inputInfo[1];

                identifiable = new Robot(model, id);
                society.Add(identifiable);
            }
        }
        string invalidSuffix = Console.ReadLine();

        foreach (IIdentifiable identifiable in society)
        {
            if (identifiable.Id.EndsWith(invalidSuffix))
            {
                Console.WriteLine(identifiable.Id);
            }
        }
    }
}

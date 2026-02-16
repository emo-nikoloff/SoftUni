/*Define two classes Car and Engine.
Start by defining a class Car that holds information about:
· Model: a string property
· Engine: a property holding the engine object
· Weight: an int property, it is optional
· Color: a string property, it is optional
Next, the Engine class has the following properties:
· Model: a string property
· Power: an int property
· Displacement: an int property, it is optional
· Efficiency: a string property, it is optional
1. On the first line, you will read a number N, which will specify how many lines of engines you will receive.
· On each of the next N lines, you will receive information about an Engine in the following format: "{model} {power} {displacement} {efficiency}"
· Keep in mind that "displacement" and "efficiency" are optional, they could be missing from the command.
2. Next, you will receive a number M, which will specify how many lines of car you will receive.
· On each of the next M lines, you will receive information about a Car in the following format: "{model} {engine} {weight} {color}".
· Keep in mind that "weight" and "color" are optional, they could be missing from the command.
· The "engine" will always be the model of an existing Engine.
· When creating the object for a Car, you should keep a reference to the real engine in it, instead of just the engine's model.
Note: The optional properties might be missing from the formats.
Your task is to print all the cars in the order they were received and their information in the format defined below. If any of the optional fields are missing, print "n/a" in its place:
"{CarModel}:
  {EngineModel}:
    Power: {EnginePower}
    Displacement: {EngineDisplacement}
    Efficiency: {EngineEfficiency}
  Weight: {CarWeight}
  Color: {CarColor}"
Bonus: Override the classes' "ToString()" methods to have a reusable way of displaying the objects.*/
namespace _08._Car_Salesman;

public class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        List<Engine> engines = new();
        for (int i = 1; i <= count; i++)
        {
            string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = info[0];
            int power = int.Parse(info[1]);
            int? displacement = null;
            string efficiency = null;

            if (info.Length == 3)
            {
                if (int.TryParse(info[2], out int value))
                {
                    displacement = value;
                }
                else
                {
                    efficiency = info[2];
                }
            }
            else if (info.Length == 4)
            {
                displacement = int.Parse(info[2]);
                efficiency = info[3];
            }

            Engine engine = new(model, power, displacement, efficiency);
            engines.Add(engine);
        }

        count = int.Parse(Console.ReadLine());

        List<Car> cars = new();
        for (int i = 1; i <= count; i++)
        {
            string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = info[0];
            string engineModel = info[1];
            int? weight = null;
            string color = null;

            if (info.Length == 3)
            {
                if (int.TryParse(info[2], out int value))
                {
                    weight = value;
                }
                else
                {
                    color = info[2];
                }
            }
            else if (info.Length == 4)
            {
                weight = int.Parse(info[2]);
                color = info[3];
            }

            Engine engine = engines.Single(e => e.Model == engineModel);
            Car car = new(model, engine, weight, color);
            cars.Add(car);
        }

        cars.ForEach(Console.WriteLine);
    }
}

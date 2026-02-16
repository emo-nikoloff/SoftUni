/*Create a program that tracks cars and their cargo.
Start by defining a class Car that holds information about:
· Model: a string property
· Engine: a class with two properties – speed and power,
· Cargo: a class with two properties – type and weight
· Tires: a collection of exactly 4 tires. Each tire should have two properties: age and pressure.
Create a constructor that receives all of the information about the Car and creates and initializes the model and its inner components (engine, cargo and tires).
On the first line of input, you will receive a number N representing the number of cars you have.
1. On the next N lines, you will receive information about each car in the format:
"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
· The speed, power, weight and tire age are integers.
· The tire pressure is a floating point number.
2. Next, you will receive a single line with one of the following commands: "fragile" or "flammable".
As an output, if the command is:
· "fragile" - print all cars, whose cargo is "fragile" and have a pressure of a single tire < 1.
· "flammable" - print all cars, whose cargo is "flammable" and have engine power > 250.
The cars should be printed in order of appearing in the input.*/
namespace _07._Raw_Data;

public class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        List<Car> cars = new();

        for (int i = 1; i <= count; i++)
        {
            string[] input = Console.ReadLine().Split();

            string model = input[0];

            int engineSpeed = int.Parse(input[1]);
            int enginePower = int.Parse(input[2]);
            Engine engine = new(engineSpeed, enginePower);

            int cargoWeight = int.Parse(input[3]);
            string cargoType = input[4];
            Cargo cargo = new(cargoType, cargoWeight);

            double firstTirePressure = double.Parse(input[5]);
            int firstTireAge = int.Parse(input[6]);
            Tire firstTire = new(firstTireAge, firstTirePressure);

            double secondTirePressure = double.Parse(input[7]);
            int secondTireAge = int.Parse(input[8]);
            Tire secondTire = new(secondTireAge, secondTirePressure);

            double thirdTirePressure = double.Parse(input[9]);
            int thirdTireAge = int.Parse(input[10]);
            Tire thirdTire = new(thirdTireAge, thirdTirePressure);

            double fourthTirePressure = double.Parse(input[11]);
            int fourthTireAge = int.Parse(input[12]);
            Tire fourthTire = new(fourthTireAge, fourthTirePressure);

            Tire[] tires = { firstTire, secondTire, thirdTire, fourthTire };

            Car car = new(model, engine, cargo, tires);
            cars.Add(car);
        }

        string condition = Console.ReadLine();

        switch (condition)
        {
            case "fragile":
                cars.Where(c => c.Cargo.Type == condition && c.Tires.Any(t => t.Pressure < 1)).ToList().ForEach(c => Console.WriteLine($"{c.Model}"));
                break;
            case "flammable":
                cars.Where(c => c.Cargo.Type == condition && c.Engine.Power > 250).ToList().ForEach(c => Console.WriteLine($"{c.Model}"));
                break;
        }
    }
}

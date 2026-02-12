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

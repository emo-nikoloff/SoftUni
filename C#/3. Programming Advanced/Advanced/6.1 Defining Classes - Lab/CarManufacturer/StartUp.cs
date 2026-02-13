namespace CarManufacturer;

public class StartUp
{
    static void Main(string[] args)
    {
        Dictionary<int, Tire[]> tires = new();

        string input = string.Empty;
        int index = 0;
        while ((input = Console.ReadLine()) != "No more tires")
        {
            string[] info = input.Split();
            tires.Add(index, new Tire[4]);
            tires[index][0] = new Tire(int.Parse(info[0]), double.Parse(info[1]));
            tires[index][1] = new Tire(int.Parse(info[2]), double.Parse(info[3]));
            tires[index][2] = new Tire(int.Parse(info[4]), double.Parse(info[5]));
            tires[index][3] = new Tire(int.Parse(info[6]), double.Parse(info[7]));
            index++;
        }

        Dictionary<int, Engine> engines = new();
        index = 0;
        while ((input = Console.ReadLine()) != "Engines done")
        {
            string[] info = input.Split();
            engines.Add(index, new Engine(int.Parse(info[0]), double.Parse(info[1])));
            index++;
        }

        List<Car> cars = new();
        while ((input = Console.ReadLine()) != "Show special")
        {
            string[] info = input.Split();
            string make = info[0];
            string model = info[1];
            int year = int.Parse(info[2]);
            double fuelQuantity = double.Parse(info[3]);
            double fuelConsumption = double.Parse(info[4]);
            int engineIndex = int.Parse(info[5]);
            int tireIndex = int.Parse(info[6]);

            Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tireIndex]);
            cars.Add(car);
        }

        foreach (Car car in cars.Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330))
        {
            double pressureSum = 0;
            for (int i = 0; i < car.Tires.Length; i++)
            {
                pressureSum += car.Tires[i].Pressure;
            }
            if (pressureSum >= 9 && pressureSum <= 10)
            {
                car.Drive(20.0);
                Console.WriteLine(car);
            }
        }
    }
}

namespace _06._Speed_Racing;

public class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        List<Car> cars = new();

        for (int i = 1; i <= count; i++)
        {
            string[] info = Console.ReadLine().Split();
            string model = info[0];
            double fuelAmount = double.Parse(info[1]);
            double fuelConsumptionPerKm = double.Parse(info[2]);

            Car car = new(model, fuelAmount, fuelConsumptionPerKm);
            if (!cars.Contains(car))
            {
                cars.Add(car);
            }
        }

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] info = input.Split().Skip(1).ToArray();
            string model = info[0];
            double travelDistance = double.Parse(info[1]);

            Car car = cars.Single(c => c.Model == model);
            car.Drive(travelDistance);
        }
        cars.ForEach(Console.WriteLine);
    }
}

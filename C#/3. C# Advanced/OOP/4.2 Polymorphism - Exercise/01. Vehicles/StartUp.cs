using Vehicles.Models;

namespace Vehicles;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Vehicle> vehicles = new();

        string[] vehicleInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Vehicle vehicle = new Car(double.Parse(vehicleInfo[1]), double.Parse(vehicleInfo[2]));
        vehicles.Add(vehicle);

        vehicleInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        vehicle = new Truck(double.Parse(vehicleInfo[1]), double.Parse(vehicleInfo[2]));
        vehicles.Add(vehicle);

        int commandsNumber = int.Parse(Console.ReadLine());

        for (int i = 1; i <= commandsNumber; i++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = input[0];
            string vehicleType = input[1];

            switch (command)
            {
                case "Drive":
                    double distance = double.Parse(input[2]);
                    vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);
                    Console.WriteLine(vehicle.Drive(distance));
                    break;
                case "Refuel":
                    double litres = double.Parse(input[2]);
                    vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);
                    vehicle.Refuel(litres);
                    break;
            }
        }
        vehicles.ForEach(Console.WriteLine);
    }
}

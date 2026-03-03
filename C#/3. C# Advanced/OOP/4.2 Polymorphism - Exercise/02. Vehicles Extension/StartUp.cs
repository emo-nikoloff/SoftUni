using VehiclesExtension.Models;

namespace VehiclesExtension;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Vehicle> vehicles = new();

        string[] vehicleInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Vehicle vehicle = new Car(double.Parse(vehicleInfo[1]), double.Parse(vehicleInfo[2]), double.Parse(vehicleInfo[3]));
        vehicles.Add(vehicle);

        vehicleInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        vehicle = new Truck(double.Parse(vehicleInfo[1]), double.Parse(vehicleInfo[2]), double.Parse(vehicleInfo[3]));
        vehicles.Add(vehicle);

        vehicleInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        vehicle = new Bus(double.Parse(vehicleInfo[1]), double.Parse(vehicleInfo[2]), double.Parse(vehicleInfo[3]));
        vehicles.Add(vehicle);

        int commandsNumber = int.Parse(Console.ReadLine());

        for (int i = 1; i <= commandsNumber; i++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = input[0];
            string vehicleType = input[1];

            try
            {
                switch (command)
                {
                    case "Drive":
                    case "DriveEmpty":
                        double distance = double.Parse(input[2]);
                        vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

                        bool ecoMode = command == "DriveEmpty";

                        Console.WriteLine(vehicle.Drive(distance, ecoMode));
                        break;
                    case "Refuel":
                        double litres = double.Parse(input[2]);
                        vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);
                        vehicle.Refuel(litres);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        vehicles.ForEach(Console.WriteLine);
    }
}

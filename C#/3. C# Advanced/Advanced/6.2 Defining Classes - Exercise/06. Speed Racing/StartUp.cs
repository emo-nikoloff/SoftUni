/*Create a program that keeps track of cars and their fuel and supports methods for moving the cars. Define a class Car. Each Car has the following properties:
· string Model
· double FuelAmount
· double FuelConsumptionPerKilometer
· double Travelled distance
A car's model is unique - there will never be 2 cars with the same model. On the first line of the input, you will receive a number N – the number of cars you need to track. On each of the next
N lines, you will receive information about a car in the following format:
"{model} {fuelAmount} {fuelConsumptionFor1km}"
All cars start at 0 kilometers traveled. After the N lines, until the command "End" is received, you will receive commands in the following format:
"Drive {carModel} {amountOfKm}"
Implement a method in the Car class to calculate whether or not a car can move that distance. If it can, the car's fuel amount should be reduced by the amount of used fuel and its traveled
distance should be increased by the number of the traveled kilometers. Otherwise, the car should not move (its fuel amount and the traveled distance should stay the same) and you should print on
the console:
"Insufficient fuel for the drive"
After the "End" command is received, print each car and its current fuel amount and the traveled distance in the format:
"{model} {fuelAmount} {distanceTraveled}"
Print the fuel amount formatted two digits after the decimal separator.*/
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

/*Until you receive the "End" command, you will be receiving lines of input in the following format:
"{typeOfVehicle} {model} {color} {horsepower}"
When you receive the "End" command, you will start receiving information about some vehicles.
For every vehicle, print out the information about it in the following format:
"Type: {typeOfVehicle} Model: {modelOfVehicle} Color: {colorOfVehicle} Horsepower: {horsepowerOfVehicle}"
When you receive the "Close the Catalogue" command, print out the average horsepower of the cars and the average horsepower of the trucks in the format:
"{typeOfVehicles} have average horsepower of: {averageHorsepower}."
The average horsepower is calculated by dividing the sum of the horsepower of all vehicles of the given type by the total count of all vehicles from that type. Format the answer to the second digit
after the decimal point.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue;

class Program
{
    static void Main(string[] args)
    {
        string input;
        List<Vehicle> vehicles = new();

        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split();
            string vehicleType = inputArgs[0];
            string vehicleModel = inputArgs[1];
            string vehicleColor = inputArgs[2];
            int vehicleHorsePower = int.Parse(inputArgs[3]);

            Vehicle vehicle = new(vehicleType, vehicleModel, vehicleColor, vehicleHorsePower);
            vehicles.Add(vehicle);
        }

        while ((input = Console.ReadLine()) != "Close the Catalogue")
        {
            Vehicle vehicle = vehicles.FirstOrDefault(v => v.Model == input);
            if (vehicle != null)
            {
                Console.WriteLine(vehicle);
            }
        }

        double averageCarsHorsepower = vehicles.Where(v => v.Type == "car").Select(v => v.Horsepower).DefaultIfEmpty().Average();
        double averageTrucksHorsepower = vehicles.Where(v => v.Type == "truck").Select(v => v.Horsepower).DefaultIfEmpty().Average();

        Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsepower:F2}.");
        Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsepower:F2}.");
    }
}

class Vehicle
{
    public Vehicle(string type, string model, string color, int horsepower)
    {
        Type = type;
        Model = model;
        Color = color;
        Horsepower = horsepower;
    }

    public string Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int Horsepower { get; set; }
    public override string ToString()
    {
        return $"Type: {char.ToUpper(Type[0]) + Type.Substring(1)}\nModel: {Model}\nColor: {Color}\nHorsepower: {Horsepower}";
    }
}
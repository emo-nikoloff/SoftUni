/*Your task is to create a Vehicle catalog, which contains only Trucks and Cars.
Define a class Truck with the following properties: Brand, Model, and Weight.
Define a class Car with the following properties: Brand, Model, and Horse Power.
Define a class Catalog with the following properties: Collections of Trucks and Cars.
You must read the input, until you receive the "end" command. It will be in following format: "{type}/{brand}/{model}/{horse power / weight}"
In the end, you have to print all of the vehicles ordered alphabetical by brand, in the following format:
"Cars:
{Brand}: {Model} - {Horse Power}hp
Trucks:
{Brand}: {Model} - {Weight}kg"*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue;

class Program
{
    static void Main(string[] args)
    {
        string data;
        Catalog vehicles = new();

        while ((data = Console.ReadLine()) != "end")
        {
            string[] dataParts = data.Split("/");

            string vehicleType = dataParts[0];
            string vehicleBrand = dataParts[1];
            string vehicleModel = dataParts[2];
            if (vehicleType == "Truck")
            {
                int vehicleWeight = int.Parse(dataParts[3]);

                Truck truck = new();
                truck.Brand = vehicleBrand;
                truck.Model = vehicleModel;
                truck.Weight = vehicleWeight;

                vehicles.Trucks.Add(truck);
            }
            else if (vehicleType == "Car")
            {
                int vehicleHorsePower = int.Parse(dataParts[3]);

                Car car = new();
                car.Brand = vehicleBrand;
                car.Model = vehicleModel;
                car.HorsePower = vehicleHorsePower;

                vehicles.Cars.Add(car);
            }
        }

        if (vehicles.Cars.Count > 0)
        {
            Console.WriteLine("Cars:");
            foreach (Car car in vehicles.Cars.OrderBy(car => car.Brand))
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }
        }
        if (vehicles.Trucks.Count > 0)
        {
            Console.WriteLine("Trucks:");
            foreach (Truck truck in vehicles.Trucks.OrderBy(truck => truck.Brand))
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
}

class Truck
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Weight { get; set; }
}

class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int HorsePower { get; set; }
}

class Catalog
{
    public Catalog()
    {
        Trucks = new();
        Cars = new();
    }

    public List<Truck> Trucks { get; set; }
    public List<Car> Cars { get; set; }
}

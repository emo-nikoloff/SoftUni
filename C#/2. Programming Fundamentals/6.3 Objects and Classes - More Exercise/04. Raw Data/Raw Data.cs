/*You are the owner of a courier company and you want to make a system for tracking your cars and their cargo. Define a class Car that holds a piece of information about the model, engine and cargo.
The Engine and Cargo should be separate classes. Create a constructor that receives all of the information about the Car and creates and initializes its inner components (engine and cargo).
On the first line, of input you will receive a number N – the number of cars you have. On each of the next N lines, you will receive the following information about a car:
"<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType>", where the speed, power and weight are all integers.
After the N lines, you will receive a single line with one of 2 commands: "fragile" or "flamable". If the command is "fragile", print all cars, whose Cargo Type is
"fragile" with cargo with weight < 1000. If the command is "flamable", print all of the cars whose Cargo Type is "flamable" and have Engine Power > 250.
The cars should be printed in order of appearing in the input.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Raw_Data;

class Program
{
    static void Main(string[] args)
    {
        int carsNumber = int.Parse(Console.ReadLine());
        List<Car> cars = new();

        for (int i = 1; i <= carsNumber; i++)
        {
            string[] input = Console.ReadLine().Split();
            string model = input[0];
            int engineSpeed = int.Parse(input[1]);
            int enginePower = int.Parse(input[2]);
            int cargoWeight = int.Parse(input[3]);
            string cargoType = input[4];

            Car car = new(model, engineSpeed, enginePower, cargoWeight, cargoType);
            cars.Add(car);
        }

        string command = Console.ReadLine();

        if (command == "fragile")
        {
            cars.Where(cargo => cargo.Cargo.Type == "fragile" && cargo.Cargo.Weight < 1000).ToList().ForEach(c => Console.WriteLine(c));
        }
        else if (command == "flamable")
        {
            cars.Where(engine => engine.Cargo.Type == "flamable" && engine.Engine.Power > 250).ToList().ForEach(c => Console.WriteLine(c));
        }
    }
}

class Car
{
    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType)
    {
        Model = model;
        Engine = new()
        {
            Speed = engineSpeed,
            Power = enginePower
        };
        Cargo = new()
        {
            Weight = cargoWeight,
            Type = cargoType
        };
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }

    public override string ToString()
    {
        return Model;
    }
}

class Engine
{
    public int Speed { get; set; }
    public int Power { get; set; }
}

class Cargo
{
    public int Weight { get; set; }
    public string Type { get; set; }
}

using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Models;

public abstract class Vehicle : IVehicle
{
    private double fuel;
    private double fuelConsumption;
    private double tankCapacity;

    protected Vehicle(double fuel, double fuelConsumption, double tankCapacity)
    {
        TankCapacity = tankCapacity;
        Fuel = fuel;
        FuelConsumption = fuelConsumption;
    }

    public double Fuel
    {
        get => fuel;
        private set
        {
            if (value > TankCapacity)
            {
                fuel = 0;
            }
            else
            {
                fuel = value;
            }
        }
    }
    public double FuelConsumption
    {
        get => fuelConsumption;
        private set => fuelConsumption = value;
    }
    public double TankCapacity
    {
        get => tankCapacity;
        private set => tankCapacity = value;
    }
    protected abstract double AirConditionerFuelConsumption { get; }

    public string Drive(double distance, bool ecoMode)
    {
        if (distance < 0)
        {
            throw new ArgumentException("Distance must not be negative");
        }

        double fuelConsumption = FuelConsumption;
        if (!ecoMode)
        {
            fuelConsumption += AirConditionerFuelConsumption;
        }

        double requiredFuel = distance * fuelConsumption;
        if (Fuel < requiredFuel)
        {
            throw new ArgumentException($"{GetType().Name} needs refueling");
        }

        Fuel -= requiredFuel;
        return $"{GetType().Name} travelled {distance} km";
    }
    public virtual void Refuel(double litres)
    {
        if (litres <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (Fuel + litres > TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {litres} fuel in the tank");
        }
        Fuel += litres;
    }

    public override string ToString() => $"{GetType().Name}: {Fuel:f2}";
}

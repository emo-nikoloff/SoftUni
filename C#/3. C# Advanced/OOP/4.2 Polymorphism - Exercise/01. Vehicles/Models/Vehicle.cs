using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IVehicle
{
    protected Vehicle(double fuel, double fuelConsumption)
    {
        Fuel = fuel;
        FuelConsumption = fuelConsumption;
    }

    public double Fuel { get; private set; }
    public virtual double FuelConsumption { get; }

    public string Drive(double distance)
    {
        double requiredFuel = distance * FuelConsumption;

        if (Fuel < requiredFuel)
        {
            return $"{GetType().Name} needs refueling";
        }

        Fuel -= FuelConsumption * distance;
        return $"{GetType().Name} travelled {distance} km";
    }
    public virtual void Refuel(double litres)
    {
        Fuel += litres;
    }

    public override string ToString() => $"{GetType().Name}: {Fuel:f2}";
}

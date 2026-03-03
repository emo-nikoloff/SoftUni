namespace Vehicles.Models;

public class Truck : Vehicle
{
    private const double DefaultConsumptionIncrease = 1.6;

    public Truck(double fuel, double fuelConsumption) : base(fuel, fuelConsumption)
    {
    }

    public override double FuelConsumption => base.FuelConsumption + DefaultConsumptionIncrease;

    public override void Refuel(double litres) => base.Refuel(litres * 0.95);
}

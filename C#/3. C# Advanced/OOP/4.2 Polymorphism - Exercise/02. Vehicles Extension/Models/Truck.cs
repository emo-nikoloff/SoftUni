namespace VehiclesExtension.Models;

public class Truck : Vehicle
{
    private const double DefaultConsumptionIncrease = 1.6;

    public Truck(double fuel, double fuelConsumption, double tankCapacity) : base(fuel, fuelConsumption, tankCapacity)
    {
    }

    protected override double AirConditionerFuelConsumption => DefaultConsumptionIncrease;

    public override void Refuel(double litres) => base.Refuel(Fuel + litres > TankCapacity ? litres : litres * 0.95);
}

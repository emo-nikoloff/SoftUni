namespace VehiclesExtension.Models;

public class Bus : Vehicle
{
    private const double DefaultConsumptionIncrease = 1.4;

    public Bus(double fuel, double fuelConsumption, double tankCapacity) : base(fuel, fuelConsumption, tankCapacity)
    {
    }

    protected override double AirConditionerFuelConsumption => DefaultConsumptionIncrease;
}

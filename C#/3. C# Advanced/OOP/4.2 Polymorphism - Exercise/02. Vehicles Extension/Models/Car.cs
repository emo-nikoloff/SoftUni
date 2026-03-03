namespace VehiclesExtension.Models;

public class Car : Vehicle
{
    private const double DefaultConsumptionIncrease = 0.9;

    public Car(double fuel, double fuelConsumption, double tankCapacity) : base(fuel, fuelConsumption, tankCapacity)
    {
    }

    protected override double AirConditionerFuelConsumption => DefaultConsumptionIncrease;
}

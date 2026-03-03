namespace Vehicles.Models;

public class Car : Vehicle
{
    private const double DefaultConsumptionIncrease = 0.9;

    public Car(double fuel, double fuelConsumption) : base(fuel, fuelConsumption)
    {
    }

    public override double FuelConsumption => base.FuelConsumption + DefaultConsumptionIncrease;
}

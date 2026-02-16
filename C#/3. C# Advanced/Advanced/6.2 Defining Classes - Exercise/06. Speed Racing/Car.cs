namespace _06._Speed_Racing;

public class Car
{
    public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        TravelledDistance = 0;
    }

    public string Model { get; }
    public double FuelAmount { get; private set; }
    public double FuelConsumptionPerKilometer { get; }
    public double TravelledDistance { get; private set; }

    public void Drive(double travelDistance)
    {
        double fuelNeeded = FuelConsumptionPerKilometer * travelDistance;
        if (fuelNeeded <= FuelAmount)
        {
            FuelAmount -= fuelNeeded;
            TravelledDistance += travelDistance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{Model} {FuelAmount:f2} {TravelledDistance}";
    }
}

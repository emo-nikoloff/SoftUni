namespace Vehicles.Models.Interfaces;

public interface IVehicle
{
    double Fuel { get; }
    double FuelConsumption { get; }

    string Drive(double distance);
    void Refuel(double litres);
}

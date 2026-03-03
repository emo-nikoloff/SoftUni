namespace VehiclesExtension.Models.Interfaces;

public interface IVehicle
{
    double Fuel { get; }
    double FuelConsumption { get; }
    double TankCapacity { get; }

    string Drive(double distance, bool ecoMode);
    void Refuel(double litres);
}

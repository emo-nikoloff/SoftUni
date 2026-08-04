using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories;

public class VehicleRepository : IRepository<IVehicle>
{
    private List<IVehicle> models;

    public VehicleRepository()
    {
        models = new();
    }

    public IReadOnlyCollection<IVehicle> Models => models;

    public void Add(IVehicle vehicle) => models.Add(vehicle);

    public bool Remove(string model)
    {
        IVehicle? vehicle = models.FirstOrDefault(v => v.Model == model)!;
        return models.Remove(vehicle);
    }

    public bool Exists(string model) => models.Any(v => v.Model == model);

    public IVehicle Get(string model) => models.FirstOrDefault(v => v.Model == model)!;
}

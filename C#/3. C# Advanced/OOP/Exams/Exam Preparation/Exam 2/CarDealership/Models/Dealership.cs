using CarDealership.Models.Contracts;
using CarDealership.Repositories;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Models;

public class Dealership : IDealership
{
    private VehicleRepository vehicles;

    private CustomerRepository customers;

    public Dealership()
    {
        vehicles = new();
        customers = new();
    }

    public IRepository<IVehicle> Vehicles => vehicles;

    public IRepository<ICustomer> Customers => customers;
}

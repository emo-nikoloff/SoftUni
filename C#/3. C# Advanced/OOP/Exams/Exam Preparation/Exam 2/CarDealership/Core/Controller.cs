using System.Text;

using CarDealership.Core.Contracts;
using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Models.Customers;
using CarDealership.Models.Vehicles;
using static CarDealership.Utilities.Messages.OutputMessages;

namespace CarDealership.Core;

public class Controller : IController
{
    private IDealership dealership;

    public Controller()
    {
        dealership = new Dealership();
    }

    public string AddCustomer(string customerTypeName, string customerName)
    {
        if (customerTypeName is not (nameof(IndividualClient) or nameof(LegalEntityCustomer)))
        {
            return string.Format(InvalidType, customerTypeName);
        }

        if (dealership.Customers.Exists(customerName))
        {
            return string.Format(CustomerAlreadyAdded, customerName);
        }

        ICustomer customer = customerTypeName switch
        {
            nameof(IndividualClient) => new IndividualClient(customerName),
            nameof(LegalEntityCustomer) => new LegalEntityCustomer(customerName),
            _ => null!
        };

        dealership.Customers.Add(customer);

        return string.Format(CustomerAddedSuccessfully, customerName);
    }

    public string AddVehicle(string vehicleTypeName, string model, double price)
    {
        if (vehicleTypeName is not (nameof(SaloonCar) or nameof(SUV) or nameof(Truck)))
        {
            return string.Format(InvalidType, vehicleTypeName);
        }

        if (dealership.Vehicles.Exists(model))
        {
            return string.Format(VehicleAlreadyAdded, model);
        }

        IVehicle vehicle = vehicleTypeName switch
        {
            nameof(SaloonCar) => new SaloonCar(model, price),
            nameof(SUV) => new SUV(model, price),
            nameof(Truck) => new Truck(model, price),
            _ => null!
        };

        dealership.Vehicles.Add(vehicle);

        return string.Format(VehicleAddedSuccessfully, vehicleTypeName, model, $"{vehicle.Price:F2}");
    }

    public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
    {
        if (!dealership.Customers.Exists(customerName))
        {
            return string.Format(CustomerNotFound, customerName);
        }

        if (!dealership.Vehicles.Models.Any(v => v.GetType().Name == vehicleTypeName))
        {
            return string.Format(VehicleTypeNotFound, vehicleTypeName);
        }

        ICustomer customer = dealership.Customers.Get(customerName);

        string customerTypeName = customer.GetType().Name;
        if ((customerTypeName == nameof(IndividualClient) && vehicleTypeName == nameof(Truck))
            || (customerTypeName == nameof(LegalEntityCustomer) && vehicleTypeName == nameof(SaloonCar)))
        {
            return string.Format(CustomerNotEligibleToPurchaseVehicle, customerName, vehicleTypeName);
        }

        IEnumerable<IVehicle> vehiclesOfType = dealership.Vehicles.Models
            .Where(v => v.GetType().Name == vehicleTypeName && budget >= v.Price)
            .OrderByDescending(v => v.Price);
        if (!vehiclesOfType.Any())
        {
            return string.Format(BudgetIsNotEnough, customerName, vehicleTypeName);
        }

        IVehicle vehicle = vehiclesOfType.First();

        customer.BuyVehicle(vehicle.Model);
        vehicle.SellVehicle(customer.Name);

        return string.Format(VehiclePurchasedSuccessfully, customer.Name, vehicle.Model);
    }

    public string CustomerReport()
    {
        StringBuilder result = new();

        IEnumerable<ICustomer> customers = dealership.Customers.Models
            .OrderBy(c => c.Name);

        result.AppendLine("Customer Report:");
        foreach (ICustomer customer in customers)
        {
            result.AppendLine(customer.ToString());

            IEnumerable<string> vehiclesModels = customer.Purchases
                .OrderBy(model => model);

            result.AppendLine("-Models:");
            if (!vehiclesModels.Any())
            {
                result.AppendLine("--none");
                continue;
            }

            foreach (string model in vehiclesModels)
            {

                result.AppendLine($"--{model}");
            }
        }

        return result.ToString().TrimEnd();
    }

    public string SalesReport(string vehicleTypeName)
    {
        StringBuilder result = new();

        IEnumerable<IVehicle> vehiclesOfType = dealership.Vehicles.Models
            .Where(v => v.GetType().Name == vehicleTypeName)
            .OrderBy(v => v.Model);

        result.AppendLine($"{vehicleTypeName} Sales Report:");
        foreach (IVehicle vehicle in vehiclesOfType)
        {
            result.AppendLine($"--{vehicle.ToString()}");
        }
        result.AppendLine($"-Total Purchases: {vehiclesOfType.Sum(v => v.SalesCount)}");

        return result.ToString().TrimEnd();
    }
}

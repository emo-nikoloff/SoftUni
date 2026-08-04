using CarDealership.Models.Contracts;
using static CarDealership.Utilities.Messages.ExceptionMessages;

namespace CarDealership.Models;

public abstract class Customer : ICustomer
{
    private string name = null!;

    private List<string> purchases;

    protected Customer(string name)
    {
        Name = name;
        purchases = new();
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(NameIsRequired);
            }
            name = value;
        }
    }

    public IReadOnlyCollection<string> Purchases => purchases;

    public void BuyVehicle(string vehicleModel) => purchases.Add(vehicleModel);

    public override string ToString() => $"{Name} - Purchases: {Purchases.Count}";
}

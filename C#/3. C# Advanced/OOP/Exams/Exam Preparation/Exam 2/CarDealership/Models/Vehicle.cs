using CarDealership.Models.Contracts;
using static CarDealership.Utilities.Messages.ExceptionMessages;

namespace CarDealership.Models;

public abstract class Vehicle : IVehicle
{
    private string model = null!;

    private double price;

    private List<string> buyers;

    protected Vehicle(string model, double price)
    {
        Model = model;
        Price = price;
        buyers = new();
    }

    public string Model
    {
        get => model;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ModelIsRequired);
            }
            model = value;
        }
    }

    public double Price
    {
        get => price;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(PriceMustBePositive);
            }
            price = value;
        }
    }

    public IReadOnlyCollection<string> Buyers => buyers;

    public int SalesCount => Buyers.Count;

    public void SellVehicle(string buyerName) => buyers.Add(buyerName);

    public override string ToString() => $"{Model} - Price: {Price:F2}, Total Model Sales: {SalesCount}";
}

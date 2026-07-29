using BlackFriday.Models.Contracts;
using static BlackFriday.Utilities.Messages.ExceptionMessages;

namespace BlackFriday.Models;

public abstract class Product : IProduct
{
    private string productName = null!;

    private double basePrice;

    private bool isSold;

    protected Product(string productName, double basePrice)
    {
        ProductName = productName;
        BasePrice = basePrice;
        IsSold = false;
    }

    public string ProductName
    {
        get => productName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ProductNameRequired);
            }
            productName = value;
        }
    }

    public double BasePrice
    {
        get => basePrice;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(ProductPriceConstraints);
            }
            basePrice = value;
        }
    }

    public abstract double BlackFridayPrice { get; }

    public bool IsSold
    {
        get => isSold;
        private set => isSold = value;
    }

    public void ToggleStatus() => IsSold = !IsSold;

    public void UpdatePrice(double newPriceValue) => BasePrice = newPriceValue;

    public override string ToString() => $"Product: {ProductName}, Price: {BasePrice:f2}, You Save: {(BasePrice - BlackFridayPrice):f2}";
}

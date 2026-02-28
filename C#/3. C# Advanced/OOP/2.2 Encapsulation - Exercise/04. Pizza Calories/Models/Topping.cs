namespace PizzaCalories.Models;

public class Topping
{
    private const double BaseCaloriesPerGram = 2.0;
    private readonly Dictionary<string, double> toppingTypeCalories = new(StringComparer.OrdinalIgnoreCase) { { "meat", 1.2 }, { "veggies", 0.8 }, { "cheese", 1.1 }, { "sauce", 0.9 } };

    private string type;
    private double weight;

    public Topping(string type, double weight)
    {
        Type = type;
        Weight = weight;
    }

    public string Type
    {
        get
        {
            return type;
        }
        private set
        {
            if (!toppingTypeCalories.ContainsKey(value))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }
    public double Weight
    {
        get
        {
            return weight;
        }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }
    public double Calories
    {
        get
        {
            return BaseCaloriesPerGram * Weight * toppingTypeCalories[Type];
        }
    }
}

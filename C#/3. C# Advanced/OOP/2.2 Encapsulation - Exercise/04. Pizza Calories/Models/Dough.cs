namespace PizzaCalories.Models;

public class Dough
{
    private const double BaseCaloriesPerGram = 2.0;
    private readonly Dictionary<string, double> flourTypeCalories = new(StringComparer.OrdinalIgnoreCase) { { "white", 1.5 }, { "wholegrain", 1.0 } };
    private readonly Dictionary<string, double> bakingTechniqueCalories = new(StringComparer.OrdinalIgnoreCase) { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };

    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public string FlourType
    {
        get
        {
            return flourType;
        }
        private set
        {
            if (!flourTypeCalories.ContainsKey(value))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }
    public string BakingTechnique
    {
        get
        {
            return bakingTechnique;
        }
        private set
        {
            if (!bakingTechniqueCalories.ContainsKey(value))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value;
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
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }
    public double Calories
    {
        get
        {
            double flourTypeModifier = flourTypeCalories[FlourType];
            double bakingTechniqueModifier = bakingTechniqueCalories[BakingTechnique];

            return BaseCaloriesPerGram * Weight * flourTypeModifier * bakingTechniqueModifier;
        }
    }
}

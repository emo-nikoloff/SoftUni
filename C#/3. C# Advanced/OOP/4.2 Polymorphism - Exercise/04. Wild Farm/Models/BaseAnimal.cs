using WildFarm.Models.Interfaces;

namespace WildFarm.Models;

public abstract class BaseAnimal : IAnimal
{
    protected BaseAnimal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public string Name { get; }
    public double Weight { get; private set; }
    public int FoodEaten { get; private set; }

    protected abstract double GrowthCoefficient { get; }

    public virtual void Eat(IFood food)
    {
        Weight += food.Quantity * GrowthCoefficient;
        FoodEaten += food.Quantity;
    }

    public abstract string AskForFood();
}

using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals.Birds;

public class Owl : BaseBird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    protected override double GrowthCoefficient => 0.25;

    public override void Eat(IFood food)
    {
        if (food is Meat)
        {
            base.Eat(food);
        }
        else
        {
            throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }

    public override string AskForFood() => "Hoot Hoot";
}

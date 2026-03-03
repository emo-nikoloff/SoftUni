using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals.Mammals;

public class Mouse : BaseMammal
{
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    protected override double GrowthCoefficient => 0.1;

    public override void Eat(IFood food)
    {
        if (food is Vegetable or Fruit)
        {
            base.Eat(food);
        }
        else
        {
            throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }

    public override string AskForFood() => "Squeak";
}

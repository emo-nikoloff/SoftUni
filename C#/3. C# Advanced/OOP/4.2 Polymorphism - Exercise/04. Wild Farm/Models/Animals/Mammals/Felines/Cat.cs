using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals.Mammals.Felines;

public class Cat : BaseFeline
{
    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    protected override double GrowthCoefficient => 0.3;

    public override void Eat(IFood food)
    {
        if (food is Vegetable or Meat)
        {
            base.Eat(food);
        }
        else
        {
            throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }

    public override string AskForFood() => "Meow";
}

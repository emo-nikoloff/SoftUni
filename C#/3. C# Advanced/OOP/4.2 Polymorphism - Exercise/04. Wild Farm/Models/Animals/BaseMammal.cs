namespace WildFarm.Models.Animals;

public abstract class BaseMammal : BaseAnimal
{
    public BaseMammal(string name, double weight, string livingRegion) : base(name, weight)
    {
        LivingRegion = livingRegion;
    }

    public string LivingRegion { get; }

    public override string ToString() => $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
}

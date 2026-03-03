namespace WildFarm.Models.Animals.Mammals;

public abstract class BaseFeline : BaseMammal
{
    public BaseFeline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
    {
        Breed = breed;
    }

    public string Breed { get; }

    public override string ToString() => $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
}

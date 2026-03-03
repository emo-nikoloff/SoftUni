namespace WildFarm.Models.Animals;

public abstract class BaseBird : BaseAnimal
{
    protected BaseBird(string name, double weight, double wingSize) : base(name, weight)
    {
        WingSize = wingSize;
    }

    public double WingSize { get; }

    public override string ToString() => $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
}

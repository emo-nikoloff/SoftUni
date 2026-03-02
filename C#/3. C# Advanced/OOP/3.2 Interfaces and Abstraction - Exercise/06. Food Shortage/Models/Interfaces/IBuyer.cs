namespace FoodShortage.Models.Interfaces;

public interface IBuyer : IIdentifiable
{
    int Food { get; }
    void BuyFood();
}

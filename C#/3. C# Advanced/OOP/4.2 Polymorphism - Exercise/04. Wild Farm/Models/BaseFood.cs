using WildFarm.Models.Interfaces;

namespace WildFarm.Models;

public abstract class BaseFood : IFood
{
    protected BaseFood(int quantity)
    {
        Quantity = quantity;
    }

    public int Quantity { get; }
}

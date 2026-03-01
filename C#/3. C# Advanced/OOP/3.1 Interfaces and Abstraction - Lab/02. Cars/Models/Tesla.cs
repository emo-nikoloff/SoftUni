using Cars.Models.Interfaces;

namespace Cars.Models;

public class Tesla : Car, IElectricCar
{
    public Tesla(string model, string color, int batteries)
        : base(model, color)
    {
        Batteries = batteries;
    }

    public int Batteries { get; private set; }

    public override string ToString()
    {
        return $"{base.ToString()} with {Batteries} Batteries";
    }
}

namespace Cars;

public abstract class Car : ICar
{
    public Car(string model, string color)
    {
        Model = model;
        Color = color;
    }

    public string Model { get; protected set; }

    public string Color { get; protected set; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        return $"{Color} {GetType().Name} {Model}";
    }
}

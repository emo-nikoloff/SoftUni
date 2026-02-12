using System.Text;

namespace _08._Car_Salesman;

public class Car
{
    public Car(string model, Engine engine, int? weight, string color)
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Color = color;
    }

    public string Model { get; }
    public Engine Engine { get; }
    public int? Weight { get; }
    public string Color { get; }

    public override string ToString()
    {
        StringBuilder result = new();

        result.AppendLine($"{Model}:");
        result.AppendLine($"{Engine}");
        result.AppendLine($"  Weight: {Weight?.ToString() ?? "n/a"}");
        result.Append($"  Color: {Color ?? "n/a"}");

        return result.ToString();
    }
}

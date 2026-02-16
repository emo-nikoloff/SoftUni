using System.Text;

namespace _08._Car_Salesman;

public class Engine
{
    public Engine(string model, int power, int? displacement, string efficiency)
    {
        Model = model;
        Power = power;
        Displacement = displacement;
        Efficiency = efficiency;
    }

    public string Model { get; }
    public int Power { get; }
    public int? Displacement { get; }
    public string Efficiency { get; }

    public override string ToString()
    {
        StringBuilder result = new();

        result.AppendLine($"  {Model}:");
        result.AppendLine($"    Power: {Power}");
        result.AppendLine($"    Displacement: {Displacement?.ToString() ?? "n/a"}");
        result.Append($"    Efficiency: {Efficiency ?? "n/a"}");

        return result.ToString();
    }
}

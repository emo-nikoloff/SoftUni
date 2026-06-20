using CarApp.Contracts;

namespace CarApp.Engines;

public class Engine : IEngine
{
    public Engine(
        ICylinderPart cylinders,
        ISparkingPlugs sparkingPlugs)
    {
        Type = "ICE";
        Cylinders = cylinders;
        SparkingPlugs = sparkingPlugs;
    }

    public string Type { get; set; }
    public ICylinderPart Cylinders { get; private set; }
    public ISparkingPlugs SparkingPlugs { get; private set; }
}

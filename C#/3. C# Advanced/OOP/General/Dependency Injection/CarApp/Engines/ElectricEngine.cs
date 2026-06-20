using CarApp.Contracts;

namespace CarApp.Engines;

public class ElectricEngine : IEngine
{
    public string Type { get; private set; }
}

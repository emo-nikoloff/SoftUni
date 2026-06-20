using CarApp.Contracts;
using EasyInjector;

namespace CarApp.Models;

public class Car
{
    [Inject]
    private IEngine engine;

    public Car(
        ISuspension suspension,
        ITyres tyres)
    {
        Suspension = suspension;
        Tyres = tyres;
    }

    public IEngine Engine
    {
        get => engine;
    }
    public ISuspension Suspension { get; private set; }
    public ITyres Tyres { get; private set; }
}

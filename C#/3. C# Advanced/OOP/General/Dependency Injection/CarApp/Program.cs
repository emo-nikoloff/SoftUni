/*
using CarApp.Contracts;
using CarApp.Engines;
using CarApp.Models;
using CarApp.Parts;
using Microsoft.Extensions.DependencyInjection;
*/
using CarApp.Contracts;
using CarApp.Engines;
using CarApp.Models;
using CarApp.Parts;
using EasyInjector;

namespace CarApp;

class Program
{
    static void Main(string[] args)
    {
        /*
        ServiceCollection sportsCarServiceCollection = new(); // service <-> dependency - взаимно заменяеми 

        sportsCarServiceCollection.AddTransient<IEngine, Engine>();
        sportsCarServiceCollection.AddTransient<ISuspension, SportSuspension>();
        sportsCarServiceCollection.AddTransient<ICylinderPart, EightCylinders>();
        sportsCarServiceCollection.AddTransient<ITyres, SportTyres>();
        sportsCarServiceCollection.AddTransient<ISparkingPlugs, PremiumSparkingPlugs>();

        ServiceProvider sportsCarServiceProvider = sportsCarServiceCollection.BuildServiceProvider();

        Car car = ActivatorUtilities.CreateInstance<Car>(sportsCarServiceProvider);
        */

        SportSuspension sportSuspension = new();

        DependencyProvider injector = Injector
            .Register<IEngine, Engine>(inj =>
                {
                    Engine engine = inj.Create<Engine>();

                    engine.Type = "V8";

                    return engine;
                }) // мапни IEngine към Engine, но го инстанцирай по този специфичен начин
            .Register<ITyres, SportTyres>()
            .Register<ISuspension>(sportSuspension)
            .Register<ICylinderPart, EightCylinders>()
            .Register<ISparkingPlugs, PremiumSparkingPlugs>();

        Car car = injector.Create<Car>();
        IEngine engine = injector.Create<IEngine>();
    }
}

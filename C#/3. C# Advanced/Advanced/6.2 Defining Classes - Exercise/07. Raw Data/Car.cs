namespace _07._Raw_Data;

public class Car
{
    public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
        Tires = tires;
    }

    public string Model { get; }
    public Engine Engine { get; }
    public Cargo Cargo { get; }
    public Tire[] Tires { get; }
}

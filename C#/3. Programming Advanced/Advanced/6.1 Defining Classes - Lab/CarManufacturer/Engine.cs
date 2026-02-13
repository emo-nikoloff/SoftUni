using System;

namespace CarManufacturer;

public class Engine
{
    private int horsePower;
    private double cubicCapacity;

    public int HorsePower
    {
        get { return horsePower; }
        set { horsePower = value; }
    }
    private double CubicCapacity
    {
        get { return cubicCapacity; }
        set { cubicCapacity = value; }
    }

    public Engine(int horsePower, double cubicCapacity)
    {
        HorsePower = horsePower;
        CubicCapacity = cubicCapacity;
    }
}

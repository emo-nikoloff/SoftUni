using System;
using System.Text;

namespace _10._SoftUni_Parking;

public class Car
{
    public Car(string make, string model, int horsePower, string registrationNumber)
    {
        Make = make;
        Model = model;
        HorsePower = horsePower;
        RegistrationNumber = registrationNumber;
    }

    public string Make { get; }
    public string Model { get; }
    public int HorsePower { get; }
    public string RegistrationNumber { get; }

    public override string ToString()
    {
        StringBuilder result = new();

        result.AppendLine($"Make: {Make}");
        result.AppendLine($"Model: {Model}");
        result.AppendLine($"HorsePower: {HorsePower}");
        result.Append($"RegistrationNumber: {RegistrationNumber}");

        return result.ToString();
    }
}

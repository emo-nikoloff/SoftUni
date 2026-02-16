using System;

namespace _10._SoftUni_Parking;

public class Parking
{
    private List<Car> cars;
    private int capacity;

    public Parking(int capacity)
    {
        cars = new();
        this.capacity = capacity;
    }

    public int Count { get => cars.Count; }

    public string AddCar(Car car)
    {
        if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
        {
            return "Car with that registration number, already exists!";
        }
        if (cars.Count == capacity)
        {
            return "Parking is full!";
        }

        cars.Add(car);
        return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
    }

    public string RemoveCar(string registrationNumber)
    {
        if (!cars.Any(c => c.RegistrationNumber == registrationNumber))
        {
            return "Car with that registration number, doesn't exist!";
        }

        cars.Remove(cars.Single(c => c.RegistrationNumber == registrationNumber));
        return $"Successfully removed {registrationNumber}";
    }

    public Car GetCar(string registrationNumber)
    {
        return cars.Single(c => c.RegistrationNumber == registrationNumber);
    }

    public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
    {
        cars.RemoveAll(c => registrationNumbers.Contains(c.RegistrationNumber));
    }
}

/*Your task is to create a repository, which stores cars by creating the classes described below.
First, write a C# class Car with the following properties:
· Make: string
· Model: string
· HorsePower: int
· RegistrationNumber: string
The class' constructor should receive make, model, horsePower and registrationNumber and override the ToString() method in the following format:
"Make: {make}"
"Model: {model}"
"HorsePower: {horse power}"
"RegistrationNumber: {registration number}"
Create a C# class Parking that has Cars (a collection that stores the entity Car). All entities inside the class have the same properties.
The class' constructor should initialize the Cars with a new instance of the collection and accept capacity as a parameter.
Implement the following fields:
· Field cars – a collection that holds added cars.
· Field capacity – accessed only by the base class (responsible for the parking capacity).
Implement the following methods:
AddCar(Car Car)
The method first checks if there is already a car with the provided car registration number and if there is, the method returns the following message:
"Car with that registration number, already exists!"
Next check if the count of the cars in the parking is more than the capacity and if it returns the following message:
"Parking is full!"
Finally, if nothing from the previous conditions is true, it just adds the current car to the cars in the parking and returns the message:
"Successfully added new car {Make} {RegistrationNumber}"
RemoveCar(string RegistrationNumber)
Removes a car with the given registration number. If the provided registration number does not exist returns the message:
"Car with that registration number, doesn't exist!"
Otherwise, removes the car and returns the message:
"Successfully removed {registrationNumber}"
GetCar(string RegistrationNumber)
Returns the Car with the provided registration number.
RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
A void method, which removes all cars that have the provided registration numbers. Each car is removed only if the registration number exists.
And the following property:
· Count - Returns the number of stored cars.*/
namespace _10._SoftUni_Parking;

public class Program
{
    static void Main(string[] args)
    {
        Car firstCar = new Car("Skoda", "Fabia", 65, "CC1856BG");

        Car secondCar = new Car("Audi", "A3", 110, "EB8787MN");

        Console.WriteLine(firstCar);
        Console.WriteLine();

        Parking parking = new Parking(5);

        Console.WriteLine(parking.AddCar(firstCar));
        Console.WriteLine();

        Console.WriteLine(parking.AddCar(firstCar));
        Console.WriteLine();

        Console.WriteLine(parking.AddCar(secondCar));
        Console.WriteLine();

        Console.WriteLine(parking.GetCar("EB8787MN"));
        Console.WriteLine();

        Console.WriteLine(parking.RemoveCar("EB8787MN"));
        Console.WriteLine();

        Console.WriteLine(parking.Count);
    }
}

/*SoftUni just got a new parking lot. It's so fancy, it even has online parking validation. Except the online service doesn't work. It can only receive users' data, but it doesn't know what to do
with it. Good thing you're on the dev team and know how to fix it, right?
Write a program, which validates a parking place for an online service. Users can register to park and unregister to leave.
The program receives 2 commands:
· "register {username} {licensePlateNumber}":
    o The system only supports one car per user at the moment, so if a user tries to register another license plate, using the same username, the system should print: "ERROR: already registered with
    plate number {licensePlateNumber}"
    o If the aforementioned checks passes successfully, the plate can be registered, so the system should print: "{username} registered {licensePlateNumber} successfully"
· "unregister {username}":
    o If the user is not present in the database, the system should print: "ERROR: user {username} not found"
    o If the aforementioned check passes successfully, the system should print: "{username} unregistered successfully"
After you execute all of the commands, print all of the currently registered users and their license plates in the format:
· "{username} => {licensePlateNumber}"
· First line: n - number of commands – integer.
· Next n lines: commands in one of the two possible formats:
    o Register: "register {username} {licensePlateNumber}"
    o Unregister: "unregister {username}"
The input will always be valid and you do not need to check it explicitly.*/
using System;
using System.Collections.Generic;

namespace _04._SoftUni_Parking;

class Program
{
    static void Main(string[] args)
    {
        int commandsNumber = int.Parse(Console.ReadLine());
        Dictionary<string, Car> registeredCars = new();

        for (int i = 1; i <= commandsNumber; i++)
        {
            string[] input = Console.ReadLine().Split();

            string action = input[0];
            string user = input[1];

            switch (action)
            {
                case "register":
                    string licensePlateNumber = input[2];
                    Car car = new(user, licensePlateNumber);

                    if (registeredCars.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    else
                    {
                        registeredCars.Add(user, car);
                        Console.WriteLine($"{user} registered {licensePlateNumber} successfully");
                    }
                    break;
                case "unregister":
                    if (registeredCars.ContainsKey(user))
                    {
                        registeredCars.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    break;
            }
        }

        foreach ((string owner, Car car) in registeredCars)
        {
            Console.WriteLine($"{owner} => {car.LicensePlateNumber}");
        }
    }
}

class Car
{
    public Car(string user, string plateNumber)
    {
        Owner = user;
        LicensePlateNumber = plateNumber;
    }

    public string Owner { get; set; }
    public string LicensePlateNumber { get; set; }
}

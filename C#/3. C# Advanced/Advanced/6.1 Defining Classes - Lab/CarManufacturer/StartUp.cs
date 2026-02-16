/*Task 1: Create a public class named Car within the namespace CarManufacturer:
Define in the above class private fields for:
· make: string
· model: string
· year: int
The class should also have public properties for:
· Make: string
· Model: string
· Year: int
Create a public class StartUp class within the same namespace CarManufacturer to hold your program’s entry point.
Task 2: Create a class Car (you can use the class from the previous task). The class should have private fields for:
· make: string
· model: string
· year: int
· fuelQuantity: double
· fuelConsumption: double
The class should also have properties for:
· Make: string
· Model: string
· Year: int
· FuelQuantity: double
· FuelConsumption: double
NOTE: The field fuelConsumption and the property FuelConsumption are representing the consumption of a Car, measured in l/100km
The class should also have methods for:
· Drive(double distance): void
    o This method checks if the car fuel quantity minus the distance multiplied by the car fuel consumption per kilometer, is bigger than zero.
    o Otherwise, write on the console the following message:
"Not enough fuel to perform this trip!".
· WhoAmI(): string – returns the following message:
"Make: {this.Make}
Model: {this.Model}
Year: {this.Year}
Fuel: {this.FuelQuantity:F2}"
Task 3: Using the class from the previous problem create one parameterless constructor with default values:
· Make – VW
· Model – Golf
· Year – 2025
· FuelQuantity – 200
· FuelConsumption – 10
Create a second constructor accepting make, model and year upon initialization and call the base constructor with its default values for fuelQuantity and fuelConsumption.
Create a third constructor accepting make, model, year, fuelQuantity and fuelConsumption upon initialization and reuse the second constructor to set the make, model and year values.
Task 4: Using the Car class, you already created, define another class Engine. The class should have private fields for:
· horsePower: int
· cubicCapacity: double
The class should also have properties for:
· HorsePower: int
· CubicCapacity: double
The class should also have a constructor, which accepts horsepower and cubicCapacity upon initialization. Now create a class Tire. The class should have private fields for:
· year: int
· pressure: double
The class should also have properties for:
· Year: int
· Pressure: double
The class should also have a constructor, which accepts year and pressure upon initialization. Finally, go to the Car class and create private fields and public properties for Engine and Tire[].
Create another constructor, which accepts make, model, year, fuelQuantity, fuelConsumption, Engine and Tire[] upon initialization.
Task 5: This is the final and most interesting problem in this lab. Until you receive the command "No more tires", you will be given tire info in the format:
{year} {pressure}
{year} {pressure}
…
"No more tires"
You have to collect all the tires provided. Next, until you receive the command "Engines done" you will be given engine info and you also have to collect all that info.
{horsePower} {cubicCapacity}
{horsePower} {cubicCapacity}
…
The final step - until you receive "Show special", you will be given information about cars in the format:
{make} {model} {year} {fuelQuantity} {fuelConsumption} {engineIndex} {tiresIndex}
…
Every time you have to create a new Car with the information provided. The car engine is the provided engineIndex and the tires are tiresIndex. Finally, collect all the created cars. When you
receive the command "Show special", drive 20 kilometers all the cars, which were manufactured during 2017 or after, have horsepower above 330 and the sum of their tire pressure is between
9 and 10. Finally, print information about each special car in the following format:
"Make: {specialCar.Make}"
"Model: {specialCar.Model}"
"Year: {specialCar.Year}"
"HorsePowers: {specialCar.Engine.HorsePower}"
"FuelQuantity: {specialCar.FuelQuantity}"*/
namespace CarManufacturer;

public class StartUp
{
    static void Main(string[] args)
    {
        Dictionary<int, Tire[]> tires = new();

        string input = string.Empty;
        int index = 0;
        while ((input = Console.ReadLine()) != "No more tires")
        {
            string[] info = input.Split();
            tires.Add(index, new Tire[4]);
            tires[index][0] = new Tire(int.Parse(info[0]), double.Parse(info[1]));
            tires[index][1] = new Tire(int.Parse(info[2]), double.Parse(info[3]));
            tires[index][2] = new Tire(int.Parse(info[4]), double.Parse(info[5]));
            tires[index][3] = new Tire(int.Parse(info[6]), double.Parse(info[7]));
            index++;
        }

        Dictionary<int, Engine> engines = new();
        index = 0;
        while ((input = Console.ReadLine()) != "Engines done")
        {
            string[] info = input.Split();
            engines.Add(index, new Engine(int.Parse(info[0]), double.Parse(info[1])));
            index++;
        }

        List<Car> cars = new();
        while ((input = Console.ReadLine()) != "Show special")
        {
            string[] info = input.Split();
            string make = info[0];
            string model = info[1];
            int year = int.Parse(info[2]);
            double fuelQuantity = double.Parse(info[3]);
            double fuelConsumption = double.Parse(info[4]);
            int engineIndex = int.Parse(info[5]);
            int tireIndex = int.Parse(info[6]);

            Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tireIndex]);
            cars.Add(car);
        }

        foreach (Car car in cars.Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330))
        {
            double pressureSum = 0;
            for (int i = 0; i < car.Tires.Length; i++)
            {
                pressureSum += car.Tires[i].Pressure;
            }
            if (pressureSum >= 9 && pressureSum <= 10)
            {
                car.Drive(20.0);
                Console.WriteLine(car);
            }
        }
    }
}

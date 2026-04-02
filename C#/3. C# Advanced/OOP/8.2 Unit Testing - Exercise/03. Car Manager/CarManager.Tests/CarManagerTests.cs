namespace CarManager.Tests;

[TestFixture]
public class CarManagerTests
{
    private Car car;

    [SetUp]
    public void SetUp()
    {
        car = new("BMW", "X5", 10, 100);
    }

    [Test]
    public void CarConstructorShouldBeCreatedWithEmptyFuelAmount()
    {
        double expectedFuelAmount = 0;

        Assert.That(expectedFuelAmount, Is.EqualTo(car.FuelAmount));
    }

    [Test]
    public void CarConstructorShouldBeCreatedCorrectly()
    {
        string expectedMake = "BMW";
        string expectedModel = "X5";
        double expectedConsumption = 10;
        double expectedCapacity = 100;

        Assert.That(expectedMake, Is.EqualTo(car.Make));
        Assert.That(expectedModel, Is.EqualTo(car.Model));
        Assert.That(expectedConsumption, Is.EqualTo(car.FuelConsumption));
        Assert.That(expectedCapacity, Is.EqualTo(car.FuelCapacity));
    }

    [TestCase("")]
    [TestCase(null)]
    public void MakeShouldThrowExceptionIfValueIsNullOrEmpty(string make)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Car(make, "X5", 10, 100);
        });
    }

    [TestCase("")]
    [TestCase(null)]
    public void ModelShouldThrowExceptionIfValueIsNullOrEmpty(string model)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Car("BMW", model, 10, 100);
        });
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void FuelConsumptionShouldThrowExceptionIfValueIsNegativeOrZero(double fuelConsumption)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Car("BMW", "X5", fuelConsumption, 100);
        });
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void FuelCapacityShouldThrowExceptionIfValueIsNegativeOrZero(double fuelCapacity)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Car("BMW", "X5", 10, fuelCapacity);
        });
    }

    [Test]
    public void RefuelShouldIncreaseFuelAmount()
    {
        double fuelToRefuel = 50;

        car.Refuel(fuelToRefuel);

        Assert.That(fuelToRefuel, Is.EqualTo(car.FuelAmount));
    }

    [Test]
    public void RefuelShouldNotIncreaseFuelAmountAboveCapacity()
    {
        double expectedFuelAmount = 100;
        double fuelToRefuel = 110;

        car.Refuel(fuelToRefuel);

        Assert.That(expectedFuelAmount, Is.EqualTo(car.FuelAmount));
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void RefuelShouldThrowExceptionIfValueIsNegativeOrZero(double fuelToRefuel)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            car.Refuel(fuelToRefuel);
        });
    }

    [Test]
    public void DriveShouldDecreaseFuelAmount()
    {
        double expectedFuelAmount = 50;

        car.Refuel(100);
        car.Drive(500);

        Assert.That(expectedFuelAmount, Is.EqualTo(car.FuelAmount));
    }

    [Test]
    public void DriveShouldThrowExceptionIfFuelIsNotEnough()
    {
        car.Refuel(100);

        Assert.Throws<InvalidOperationException>(() =>
        {
            car.Drive(2000);
        });
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AutoTrade.Tests;

[TestFixture]
public class DealerShopTests
{
    private DealerShop dealerShop;

    private Vehicle vehicle;

    [SetUp]
    public void Setup()
    {
        dealerShop = new(2);
        vehicle = new("BMW", "530d", 2004);
    }

    [Test]
    public void ConstructorShouldInitializeCorrectly()
    {
        Assert.That(dealerShop.Capacity, Is.EqualTo(2));
        Assert.That(dealerShop.Vehicles, Is.Not.Null);
    }

    [TestCase(-1)]
    [TestCase(0)]
    public void CapacityPropertyShouldThrowArgumentExceptionIfValueIsBelowOne(int capacity)
    {
        Assert.That(() =>
        {
            DealerShop shop = new(capacity);
        }, Throws.ArgumentException);
    }

    [Test]
    public void AddVehicleMethodShouldThrowInvalidOperationExceptionIfInventoryIsFull()
    {
        dealerShop.AddVehicle(vehicle);
        dealerShop.AddVehicle(vehicle);

        Assert.That(() =>
        {
            dealerShop.AddVehicle(vehicle);
        }, Throws.InvalidOperationException);
    }

    [Test]
    public void AddVehicleMethodShouldAddVehicleCorrectly()
    {
        string result = dealerShop.AddVehicle(vehicle);

        Assert.That(dealerShop.Vehicles.Count, Is.EqualTo(1));
        Assert.That(result, Is.EqualTo($"Added {vehicle}"));
    }

    [Test]
    public void SellVehicleMethodShouldReturnTrueIfVehicleExistsAndRemoveVehicleCorrectly()
    {
        dealerShop.AddVehicle(vehicle);

        Assert.That(dealerShop.SellVehicle(vehicle), Is.True);
        Assert.That(dealerShop.Vehicles, Is.Empty);
    }

    [Test]
    public void SellVehicleMethodShouldReturnFalseIfVehicleDoesNotExist()
    {
        Assert.That(dealerShop.SellVehicle(vehicle), Is.False);
    }

    [Test]
    public void InventoryReportMethodShouldReturnAllProductsInDealerShop()
    {
        Vehicle firstVehicle = new("Volkswagen", "Golf 4", 2007);
        Vehicle secondVehicle = new("Mercedes", "GLA", 2020);

        dealerShop.AddVehicle(firstVehicle);
        dealerShop.AddVehicle(secondVehicle);

        StringBuilder expectedResult = new();
        expectedResult.AppendLine("Inventory Report");
        expectedResult.AppendLine("Capacity: 2");
        expectedResult.AppendLine("Vehicles: 2");
        expectedResult.AppendLine(firstVehicle.ToString());
        expectedResult.AppendLine(secondVehicle.ToString());

        string actualResult = dealerShop.InventoryReport();

        Assert.That(expectedResult.ToString().TrimEnd(), Is.EqualTo(actualResult));
    }
}

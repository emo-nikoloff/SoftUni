using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace NetTraderSystem.Tests
{
    public class TradingPlatformTests
    {
        private TradingPlatform tradingPlatform;
        private Product product;

        [SetUp]
        public void Setup()
        {
            tradingPlatform = new(2);
            product = new("Laptop", "Item", 1200.00);
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            Assert.That(tradingPlatform.Products, Is.Not.Null);
        }

        [Test]
        public void AddProductShouldAddProductCorrectly()
        {
            string result = tradingPlatform.AddProduct(product);

            Assert.That(tradingPlatform.Products, Does.Contain(product));
            Assert.That(result, Is.EqualTo($"Product {product.Name} added successfully"));
        }

        [Test]
        public void AddProductShouldReturnFullInventoryIfInventoryIsFull()
        {
            tradingPlatform.AddProduct(product);
            tradingPlatform.AddProduct(product);

            string result = tradingPlatform.AddProduct(product);

            Assert.That(result, Is.EqualTo("Inventory is full"));
        }

        [Test]
        public void RemoveProductShouldRemoveProductCorrectly()
        {
            tradingPlatform.AddProduct(product);

            bool result = tradingPlatform.RemoveProduct(product);

            Assert.That(result, Is.True);
        }

        [Test]
        public void RemoveProductShouldReturnFalseIfProductDoesNotExistInTradingPlatform()
        {
            bool result = tradingPlatform.RemoveProduct(product);

            Assert.That(result, Is.False);
        }

        [Test]
        public void SellProductShouldReturnProductIfProductExistsInTradingPlatform()
        {
            tradingPlatform.AddProduct(product);

            Product result = tradingPlatform.SellProduct(product);

            Assert.That(result.Name, Is.EqualTo("Laptop"));
        }

        [Test]
        public void SellProductShouldReturnNullIfProductDoesNotExistInTradingPlatform()
        {
            Product result = tradingPlatform.SellProduct(product);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void InventoryReportShouldReturnAllProductsInTradingPlatform()
        {
            tradingPlatform.AddProduct(new("Phone", "Item", 900.00));
            tradingPlatform.AddProduct(new("Monitor", "Item", 300.00));

            string result = tradingPlatform.InventoryReport();

            Assert.That(result, Does.Contain("Phone"));
            Assert.That(result, Does.Contain("Monitor"));
        }
    }
}
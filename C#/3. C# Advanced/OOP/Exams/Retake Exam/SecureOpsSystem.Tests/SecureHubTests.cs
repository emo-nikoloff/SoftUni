using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SecureOpsSystem.Tests
{
    [TestFixture]
    public class SecureHubTests
    {
        private SecureHub hub;

        private SecurityTool tool1;

        private SecurityTool tool2;

        [SetUp]
        public void Setup()
        {
            hub = new SecureHub(2);
            tool1 = new SecurityTool("NetScanner", "Network", 8.5);
            tool2 = new SecurityTool("FirewallX", "Defense", 9.0);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void PropertyCapacityShouldThrowArgumentExceptionIfValueIsLessThan1(int capacity)
        {
            Assert.That(() => new SecureHub(capacity), Throws.ArgumentException);
        }

        [Test]
        public void MethodAddToolShouldReturnAlreadyExists()
        {
            hub.AddTool(tool1);

            Assert.That(hub.AddTool(tool1), Is.EqualTo("Security Tool NetScanner already exists in the hub."));
        }

        [Test]
        public void MethodAddToolShouldReturnFullCapacity()
        {
            hub.AddTool(tool1);
            hub.AddTool(tool2);

            Assert.That(hub.AddTool(new SecurityTool("AntiVirus", "Defense", 9.5)),
                Is.EqualTo("Secure Hub is at full capacity."));
        }

        [Test]
        public void MethodAddToolShouldReturnSuccessfullyAdded()
        {
            Assert.That(hub.AddTool(tool1), Is.EqualTo("Security Tool NetScanner added successfully."));
        }

        [Test]
        public void MethodRemoveToolShouldReturnTrueIfToolExists()
        {
            hub.AddTool(tool1);

            Assert.That(hub.RemoveTool(tool1), Is.True);
        }

        [Test]
        public void MethodRemoveToolShouldReturnFalseIfToolDoesNotExist()
        {
            Assert.That(hub.RemoveTool(tool1), Is.False);
        }

        [Test]
        public void MethodDeployToolShouldReturnToolAndRemoveFromCollection()
        {
            hub.AddTool(tool1);

            Assert.That(hub.DeployTool("NetScanner"), Is.Not.Null);
            Assert.That(hub.Tools.Count, Is.EqualTo(0));
        }

        [Test]
        public void MethodDeployToolShouldReturnNullIfToolDoesNotExist()
        {
            Assert.That(hub.DeployTool("NetScanner"), Is.Null);
        }

        [Test]
        public void MethodSystemReportShouldReturnReportCorrectly()
        {
            SecureHub hub = new SecureHub(10);
            SecurityTool tool1 = new SecurityTool("Tool1", "Cat1", 5.0);
            SecurityTool tool2 = new SecurityTool("Tool2", "Cat2", 9.9);
            SecurityTool tool3 = new SecurityTool("Tool3", "Cat3", 7.5);

            hub.AddTool(tool1);
            hub.AddTool(tool2);
            hub.AddTool(tool3);

            string actualReport = hub.SystemReport();

            StringBuilder result = new StringBuilder();
            result.AppendLine("Secure Hub Report:");
            result.AppendLine("Available Tools: 3");
            result.AppendLine(tool2.ToString());
            result.AppendLine(tool3.ToString());
            result.AppendLine(tool1.ToString());
            string expectedReport = result.ToString().TrimEnd();

            Assert.That(actualReport, Is.EqualTo(expectedReport));
        }
    }
}

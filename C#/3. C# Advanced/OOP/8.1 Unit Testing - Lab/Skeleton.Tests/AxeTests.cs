namespace Skeleton.Tests;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeShouldLoseDurabilityAfterEachAttack()
    {
        // Arrange
        Axe axe = new(10, 20);
        Dummy dummy = new(100, 200);

        // Act
        axe.Attack(dummy);

        // Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(19));
    }

    [Test]
    public void BrokenAxeShouldNotAttack()
    {
        // Arrange
        Axe axe = new(10, 0);
        Dummy dummy = new(100, 200);

        // Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            // Act
            axe.Attack(dummy);
        }, "Axe is broken.");
    }
}

namespace Skeleton.Tests;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyShouldLoseHealthAfterAttack()
    {
        // Arrange
        Axe axe = new(10, 20);
        Dummy dummy = new(100, 200);

        // Act
        axe.Attack(dummy);

        // Assert
        Assert.That(dummy.Health, Is.EqualTo(90));
    }

    [Test]
    public void DeadDummyShouldNotBeAttacked()
    {
        // Arrange
        Axe axe = new(10, 20);
        Dummy dummy = new(0, 200);

        // Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            // Act
            axe.Attack(dummy);
        }, "Dummy is dead.");
    }

    [Test]
    public void DeadDummyShouldGiveXP()
    {
        // Arrange
        Dummy dummy = new(0, 200);

        // Act
        int result = dummy.GiveExperience();

        // Assert
        Assert.That(result, Is.EqualTo(200));
    }

    [Test]
    public void AliveDummyShouldNotGiveXP()
    {
        // Arrange
        Dummy dummy = new(100, 200);

        // Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            // Act
            int result = dummy.GiveExperience();
        }, "Target is not dead.");
    }
}

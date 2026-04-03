namespace FightingArena.Tests;

[TestFixture]
public class WarriorTests
{
    private Warrior warrior;

    [SetUp]
    public void SetUp()
    {
        warrior = new("Rojda", 100, 100);
    }

    [Test]
    public void WarriorConstructorShouldBeCreatedCorrectly()
    {
        string expectedName = "Rojda";
        int expectedDamage = 100;
        int expectedHP = 100;

        Assert.That(expectedName, Is.EqualTo(warrior.Name));
        Assert.That(expectedDamage, Is.EqualTo(warrior.Damage));
        Assert.That(expectedHP, Is.EqualTo(warrior.HP));
    }


    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void NameShouldThrowExceptionIfValueIsNullOrWhiteSpace(string name)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Warrior(name, 100, 100);
        });
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void DamageShouldThrowExceptionIfValueIsNegativeOrZero(int damage)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Warrior("Rojda", damage, 100);
        });
    }
}
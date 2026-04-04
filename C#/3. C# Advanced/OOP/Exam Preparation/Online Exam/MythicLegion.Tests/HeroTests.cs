namespace MythicLegion.Tests;

public class HeroTests
{
    private Hero hero;

    [SetUp]
    public void Setup()
    {
        hero = new Hero("Aragorn", "Ranger");
    }

    [Test]
    public void HeroConstructorShouldInitializeCorrectly()
    {
        Assert.That(hero.Name, Is.EqualTo("Aragorn"));
        Assert.That(hero.Type, Is.EqualTo("Ranger"));
        Assert.That(hero.Power, Is.EqualTo(20));
        Assert.That(hero.Health, Is.EqualTo(100));
        Assert.That(hero.IsTrained, Is.False);
    }

    [Test]
    public void HeroToStringShouldReturnCorrectFormat()
    {
        string expected = "Aragorn (Ranger) - Power: 20, Health: 100, Trained: False";
        Assert.That(hero.ToString(), Is.EqualTo(expected));
    }
}
namespace MythicLegion.Tests;

public class LegionTests
{
    private Legion legion;
    private Hero hero;

    [SetUp]
    public void Setup()
    {
        legion = new Legion();
        hero = new Hero("Aragorn", "Ranger");
    }

    [Test]
    public void AddHeroShouldAddHeroToLegionCorrectly()
    {
        legion.AddHero(hero);
        string info = legion.GetLegionInfo();
        Assert.That(info, Does.Contain("Aragorn"));
    }

    [Test]
    public void AddHeroShouldThrowArgumentNullExceptionIfNameIsNull()
    {
        Assert.That(() => legion.AddHero(null), Throws.ArgumentNullException);
    }

    [Test]
    public void AddHeroShouldThrowArgumentExceptionIfHeroAlreadyExists()
    {
        legion.AddHero(hero);
        Hero duplicateHero = new Hero("Aragorn", "Warrior");
        Assert.That(() => legion.AddHero(duplicateHero), Throws.ArgumentException);
    }

    [Test]
    public void RemoveHeroShouldRemoveHeroFromLegionCorrectly()
    {
        legion.AddHero(hero);
        bool result = legion.RemoveHero("Aragorn");
        Assert.That(result, Is.True);
        Assert.That(legion.GetLegionInfo(), Is.EqualTo("No heroes in the legion."));
    }

    [Test]
    public void RemoveHeroShouldReturnFalseIfHeroDoesNotExistInLegion()
    {
        bool result = legion.RemoveHero("NonExistent");
        Assert.That(result, Is.False);
    }

    [Test]
    public void TrainHeroShouldIncreaseStatsAndReturnMessage()
    {
        legion.AddHero(hero);
        string result = legion.TrainHero("Aragorn");

        Assert.That(result, Is.EqualTo("Aragorn has been trained."));
        Assert.That(hero.Power, Is.EqualTo(30));
        Assert.That(hero.Health, Is.EqualTo(101));
        Assert.That(hero.IsTrained, Is.True);
    }

    [Test]
    public void TrainHeroShouldReturnErrorMessageIfHeroDoesNotExistInLegion()
    {
        string result = legion.TrainHero("Unknown");
        Assert.That(result, Is.EqualTo("Hero with name Unknown not found."));
    }

    [Test]
    public void GetLegionInfoShouldReturnDefaultMessageIfLegionIsEmpty()
    {
        Assert.That(legion.GetLegionInfo(), Is.EqualTo("No heroes in the legion."));
    }

    [Test]
    public void GetLegionInfoShouldReturnAllHeroesInLegion()
    {
        legion.AddHero(new Hero("Hero1", "Type1"));
        legion.AddHero(new Hero("Hero2", "Type2"));

        string result = legion.GetLegionInfo();

        Assert.That(result, Does.Contain("Hero1"));
        Assert.That(result, Does.Contain("Hero2"));
    }
}

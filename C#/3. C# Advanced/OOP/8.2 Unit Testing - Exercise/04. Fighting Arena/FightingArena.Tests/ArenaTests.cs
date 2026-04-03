namespace FightingArena.Tests;

[TestFixture]
public class ArenaTests
{
    private Arena arena;

    [SetUp]
    public void SetUp()
    {
        arena = new();
    }

    [Test]
    public void ArenaConstructorShouldWorkCorrectly()
    {
        Assert.That(arena, Is.Not.Null);
        Assert.That(arena.Warriors, Is.Not.Null);
    }

    [Test]
    public void EnrollShouldEnrollWarriorCorrectly()
    {
        Warrior warrior = new("Jimmy", 50, 100);

        int expectedWarriors = 1;

        arena.Enroll(warrior);

        Assert.That(expectedWarriors, Is.EqualTo(arena.Count));
    }

    [Test]
    public void EnrollShouldThrowExceptionIfWarriorAlreadyExists()
    {
        Warrior warrior = new("Jimmy", 50, 100);

        arena.Enroll(warrior);

        Assert.Throws<InvalidOperationException>(() =>
        {
            arena.Enroll(warrior);
        });
    }

    [Test]
    public void FightShouldMakeTheWarriorsFight()
    {
        Warrior attacker = new("Emiliyan", 300, 200);
        Warrior defender = new("Rojda", 100, 100);

        int expectedAttackerHP = 100;
        int expectedDefenderHP = 0;

        arena.Enroll(attacker);
        arena.Enroll(defender);

        arena.Fight(attacker.Name, defender.Name);

        Assert.That(expectedAttackerHP, Is.EqualTo(attacker.HP));
        Assert.That(expectedDefenderHP, Is.EqualTo(defender.HP));
    }

    [Test]
    public void FightShouldThrowExceptionIfAttackerIsMissing()
    {
        Warrior attacker = new("Emiliyan", 300, 200);
        Warrior defender = new("Rojda", 100, 100);

        arena.Enroll(defender);

        Assert.Throws<InvalidOperationException>(() =>
        {
            arena.Fight(attacker.Name, defender.Name);
        });
    }

    [Test]
    public void FightShouldThrowExceptionIfDefenderIsMissing()
    {
        Warrior attacker = new("Emiliyan", 300, 200);
        Warrior defender = new("Rojda", 100, 100);

        arena.Enroll(attacker);

        Assert.Throws<InvalidOperationException>(() =>
        {
            arena.Fight(attacker.Name, defender.Name);
        });
    }
}
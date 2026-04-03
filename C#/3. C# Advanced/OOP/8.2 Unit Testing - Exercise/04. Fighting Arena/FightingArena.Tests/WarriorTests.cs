namespace FightingArena.Tests;

[TestFixture]
public class WarriorTests
{
    private Warrior warrior;

    [SetUp]
    public void SetUp()
    {
        warrior = new("Rojda", 10, 100);
    }

    [Test]
    public void WarriorConstructorShouldWorkCorrectly()
    {
        string expectedName = "Rojda";
        int expectedDamage = 10;
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

    [Test]
    public void HPShouldThrowExceptionIfValueIsNegative()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Warrior("Rojda", 100, -1);
        });
    }

    [Test]
    public void WarriorAttackShouldDecreaseEnemyHP()
    {
        Warrior enemy = new("Emiliyan", 50, 200);

        int expectedWarriorHP = 50;
        int expectedEnemyHP = 190;

        warrior.Attack(enemy);

        Assert.That(expectedWarriorHP, Is.EqualTo(warrior.HP));
        Assert.That(expectedEnemyHP, Is.EqualTo(enemy.HP));
    }

    [Test]
    public void WarriorShouldKillEnemyIfDamageIsTooMuch()
    {
        Warrior strongWarrior = new("Emiliyan", 300, 200);

        int expectedWarriorHP = 0;

        strongWarrior.Attack(warrior);

        Assert.That(expectedWarriorHP, Is.EqualTo(warrior.HP));
    }

    [TestCase(20)]
    [TestCase(30)]
    public void WarriorShouldNotAttackIfHPIsBelowThirty(int hp)
    {
        Warrior enemy = new("Jimmy", 100, hp);

        Assert.Throws<InvalidOperationException>(() =>
        {
            enemy.Attack(warrior);
        });
    }

    [TestCase(20)]
    [TestCase(30)]
    public void WarriorShouldNotAttackEnemyWithHPBelowThirty(int hp)
    {
        Warrior enemy = new("Jimmy", 100, hp);

        Assert.Throws<InvalidOperationException>(() =>
        {
            warrior.Attack(enemy);
        });
    }

    [Test]
    public void WarriorShouldNotAttackStrongerEnemies()
    {
        Warrior enemy = new("Jimmy", 200, 100);

        Assert.Throws<InvalidOperationException>(() =>
        {
            warrior.Attack(enemy);
        });
    }
}
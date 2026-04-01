using ExtendedDatabase;

namespace DatabaseExtended.Tests;

[TestFixture]
public class ExtendedDatabaseTests
{
    private Database database;

    [SetUp]
    public void SetUp()
    {
        // Arrange
        Person[] people =
        {
            new(1, "emo_nikoloff"),
            new(2, "bekir.rojda"),
            new(3, "jimmyhyusein"),
            new(4, "liubomir_nenov"),
            new(5, "tupev5"),
            new(6, "djamekaaa"),
            new(7, "presiyana_a"),
            new(8, "ros_bos__"),
            new(9, "lilava_rusalka"),
            new(10, "konstantin.cruise"),
            new(11, "i.ivanov_924"),
            new(12, "dimitar_todorov.77"),
            new(13, "mitsovaa"),
            new(14, "milenmladenov_mm")
        };

        database = new(people);
    }

    [Test]
    public void DatabaseConstructorShouldBeCreatedCorrectly()
    {
        // Arrange
        Person[] people =
        {
            new(1, "ligleboy"),
            new(2, "xrsto.strumski_"),
            new(3, "viktoriya.krusteva")
        };

        // Act
        database = new(people);

        int peopleLength = people.Length;
        int databaseCount = database.Count;

        // Assert
        Assert.That(peopleLength, Is.EqualTo(databaseCount));
    }

    [Test]
    public void DatabaseConstructorShouldThrowExceptionIfSizeIsBiggerThanSixteen()
    {
        // Arrange
        Person[] people =
        {
            new(1, "emo_nikoloff"),
            new(2, "bekir.rojda"),
            new(3, "jimmyhyusein"),
            new(4, "liubomir_nenov"),
            new(5, "tupev5"),
            new(6, "djamekaaa"),
            new(7, "presiyana_a"),
            new(8, "ros_bos__"),
            new(9, "lilava_rusalka"),
            new(10, "konstantin.cruise"),
            new(11, "i.ivanov_924"),
            new(12, "dimitar_todorov.77"),
            new(13, "mitsovaa"),
            new(14, "milenmladenov_mm"),
            new(15, "simonaa.angelovaa"),
            new(16, "eva.yankova"),
            new(17, "minchoslaveykov")
        };

        // Assert
        Assert.Throws<ArgumentException>(() =>
        {
            // Act
            database = new(people);
        });
    }

    [Test]
    public void AddShouldAddPersonCorrectly()
    {
        // Arrange
        Person person = new(15, "eva.yankova");

        // Act
        int expectedDatabaseCount = database.Count + 1;
        database.Add(person);
        int databaseCount = database.Count;

        // Assert
        Assert.That(expectedDatabaseCount, Is.EqualTo(databaseCount));
    }

    [Test]
    public void AddShouldThrowExceptionIfDatabaseSizeIsFull()
    {
        // Arrange
        Person[] people =
        {
            new(1, "emo_nikoloff"),
            new(2, "bekir.rojda"),
            new(3, "jimmyhyusein"),
            new(4, "liubomir_nenov"),
            new(5, "tupev5"),
            new(6, "djamekaaa"),
            new(7, "presiyana_a"),
            new(8, "ros_bos__"),
            new(9, "lilava_rusalka"),
            new(10, "konstantin.cruise"),
            new(11, "i.ivanov_924"),
            new(12, "dimitar_todorov.77"),
            new(13, "mitsovaa"),
            new(14, "milenmladenov_mm"),
            new(15, "simonaa.angelovaa"),
            new(16, "eva.yankova")
        };

        Database fullDatabase = new(people);

        Person person = new(17, "minchoslaveykov");

        // Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            // Act
            fullDatabase.Add(person);
        });
    }

    [Test]
    public void AddShouldThrowExceptionIfUsernameAlreadyExists()
    {
        // Arrange
        Person person = new(15, "bekir.rojda");

        // Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            // Act
            database.Add(person);
        });
    }

    [Test]
    public void AddShouldThrowExceptionIfIdAlreadyExists()
    {
        // Arrange
        Person person = new(2, "eva.yankova");

        // Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            // Act
            database.Add(person);
        });
    }

    [Test]
    public void RemoveShouldRemovePersonCorrectly()
    {
        // Act
        int expectedDatabaseCount = database.Count - 1;
        database.Remove();
        int databaseCount = database.Count;

        // Assert
        Assert.That(expectedDatabaseCount, Is.EqualTo(databaseCount));
    }

    [Test]
    public void RemoveShouldThrowExceptionIfDatabaseIsEmpty()
    {
        // Arrange
        Database emptyDatabase = new();

        // Assert
        Assert.Throws<InvalidOperationException>(emptyDatabase.Remove); // Act
    }

    [Test]
    public void FindByUsernameShouldFindPersonCorrectly()
    {
        // Act
        string expectedResult = "emo_nikoloff";
        string actualResult = database.FindByUsername("emo_nikoloff").UserName;

        // Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test]
    [TestCase("")]
    [TestCase(null)]
    public void FindByUsernameShouldThrowExceptionIfUsernameIsNullOrEmpty(string username)
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            // Act
            database.FindByUsername(username);
        });
    }

    [Test]
    public void FindByUsernameShouldThrowExceptionIfUserWithUsernameIsNotPresent()
    {
        // Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            // Act
            database.FindByUsername("jamaikata");
        });
    }

    [Test]
    public void FindByUsernameShouldBeCaseSensitive()
    {
        // Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            // Act
            database.FindByUsername("Emo_Nikoloff");
        });
    }

    [Test]
    public void FindByIdShouldFindPersonCorrectly()
    {
        // Act
        string expectedResult = "emo_nikoloff";
        string actualResult = database.FindById(1).UserName;

        // Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test]
    public void FindByIdShouldThrowExceptionIfIdIsNegative()
    {
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            // Act
            database.FindById(long.MinValue);
        });
    }

    [Test]
    public void FindByIdShouldThrowExceptionIfUserWithIdIsNotPresent()
    {
        // Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            // Act
            database.FindById(17);
        });
    }

    [TearDown]
    public void TearDown()
    {
        database = null;
    }
}

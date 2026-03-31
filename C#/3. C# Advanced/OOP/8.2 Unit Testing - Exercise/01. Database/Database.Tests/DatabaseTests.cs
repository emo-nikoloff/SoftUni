namespace Database.Tests;

[TestFixture]
public class DatabaseTests
{
    private const int number = 5;

    // Arrange...
    private Database database;

    [SetUp]
    public void SetUp()
    {
        // ...Arrange
        database = new(1, 2, 3);
    }

    [TestCase(new int[] { 1, 2 })]
    [TestCase(new int[] { 1, 2, 3, 4 })]
    public void CreatingDatabaseConstructorShouldBeCorrect(int[] expectedData) // Arrange
    {
        // Arrange
        database = new(expectedData);

        // Act
        int[] data = database.Fetch();

        // Assert
        Assert.That(data, Is.EqualTo(expectedData));
    }

    [Test]
    public void CountShouldReturnCorrectValue()
    {
        // Arrange
        int expectedCount = 3;

        // Act
        int actualCount = database.Count;

        // Assert
        Assert.That(actualCount, Is.EqualTo(expectedCount));
    }

    [Test]
    public void AddShouldAddValueCorrectly()
    {
        // Act
        database.Add(number);
        int[] data = database.Fetch();
        int expectedNumber = data[data.Length - 1];

        // Assert
        Assert.That(expectedNumber, Is.EqualTo(number));
    }

    [Test]
    public void AddShouldThrowExceptionIfSizeIsSixteen()
    {
        // Arrange
        Database fullDatabase = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

        // Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            // Act
            fullDatabase.Add(number);
        });
    }

    [Test]
    public void RemoveShouldRemoveValueCorrectly()
    {
        // Arrange
        int[] data = database.Fetch();
        int[] expectedData = new int[data.Length - 1];

        // Act
        for (int i = 0; i < expectedData.Length; i++)
        {
            expectedData[i] = data[i];
        }

        database.Remove();

        // Assert
        Assert.That(expectedData, Is.EqualTo(database.Fetch()));
    }

    [Test]
    public void RemoveShouldThrowExceptionIfSizeIsZero()
    {
        // Arrange
        Database emptyDatabase = new();

        // Assert
        Assert.Throws<InvalidOperationException>(emptyDatabase.Remove); // Act
    }

    [TearDown]
    public void TearDown()
    {
        database = null;
    }
}

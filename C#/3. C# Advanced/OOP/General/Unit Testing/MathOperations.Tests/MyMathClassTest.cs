namespace MathOperations.Tests;

public class MyMathClassTest // AAA pattern - Arrange -> Act -> Assert
{
    // Arrange...
    private MyMathClass mathClass;

    [SetUp]
    public void SetUpMathClass()
    {
        // ...Arrange
        mathClass = new();
    }

    [Test]
    public void SumShouldReturnCorrectValue()
    {
        // Act
        int result = mathClass.Sum(2, 3);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void ProductShouldReturnCorrectValue()
    {
        // Act
        int result = mathClass.Product(2, 3);

        // Assert
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void PowShouldReturnCorrectValue()
    {
        // Act
        int result = mathClass.Pow(2, 3);

        // Assert
        Assert.That(result, Is.EqualTo(8));
    }

    [TearDown]
    public void TearDownMathClass()
    {
        mathClass = null;
    }
}

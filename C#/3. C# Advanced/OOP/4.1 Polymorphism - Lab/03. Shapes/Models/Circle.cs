namespace Shapes.Models;

public class Circle : Shape
{
    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius { get; }

    public override double CalculatePerimeter() => 2 * Math.PI * Radius;
    public override double CalculateArea() => Math.PI * Radius * Radius;
}

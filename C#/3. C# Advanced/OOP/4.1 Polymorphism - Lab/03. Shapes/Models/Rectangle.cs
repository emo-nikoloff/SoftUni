namespace Shapes.Models;

public class Rectangle : Shape
{
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Width { get; }
    public double Height { get; }

    public override double CalculatePerimeter() => 2 * (Width + Height);
    public override double CalculateArea() => Width * Height;
}

namespace Shapes;

public class Circle : IDrawable
{
    private int radius;

    public Circle(int radius)
    {
        this.radius = radius;
    }

    public void Draw()
    {
        double radiusIn = radius - 0.4;
        double radiusOut = radius + 0.4;

        for (double y = radius; y >= -radius; --y)
        {
            for (double x = -radius; x < radiusOut; x += 0.5)
            {
                double value = x * x + y * y;

                if (value >= radiusIn * radiusIn && value <= radiusOut * radiusOut)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }
}

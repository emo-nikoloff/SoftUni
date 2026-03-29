namespace MathOperations;

public class MyMathClass
{
    public int Sum(int x, int y)
    {
        return x + y;
    }

    public int Product(int x, int y)
    {
        return x * y;
    }

    public int Pow(int x, int y)
    {
        int result = 1;

        for (int i = 0; i < y; i++)
        {
            result *= x;
        }

        return result;
    }
}

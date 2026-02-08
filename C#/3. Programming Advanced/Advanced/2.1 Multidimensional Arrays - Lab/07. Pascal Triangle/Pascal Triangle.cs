namespace _07._Pascal_Triangle;

class Program
{
    static void Main(string[] args)
    {
        int height = int.Parse(Console.ReadLine());
        long[][] triangle = new long[height][];
        triangle[0] = new long[] { 1 };
        Console.WriteLine(triangle[0][0]);
        for (long row = 1; row < triangle.Length; row++)
        {
            triangle[row] = new long[row + 1];
            for (long i = 0; i < triangle[row].Length; i++)
            {
                if (i - 1 < 0)
                {
                    triangle[row][i] = triangle[row - 1][i];
                }
                else if (i >= triangle[row - 1].Length)
                {
                    triangle[row][i] = triangle[row - 1][i - 1];
                }
                else
                {
                    triangle[row][i] = triangle[row - 1][i] + triangle[row - 1][i - 1];
                }
            }
            Console.WriteLine(string.Join(" ", triangle[row]));
        }
    }
}

namespace _07._Pascal_Triangle;

class Program
{
    static void Main(string[] args)
    {
        int height = int.Parse(Console.ReadLine());
        int[][] triangle = new int[height][];

        int currentWidth = 1;
        for (int row = 0; row < triangle.Length; row++)
        {
            triangle[row] = new int[currentWidth];
            int[] currentRow = triangle[row];
            currentRow[0] = 1;
            currentRow[currentRow.Length - 1] = 1;
            currentWidth++;
        }
    }
}

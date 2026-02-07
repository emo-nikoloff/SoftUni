namespace _01._Diagonal_Difference;

class Program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];

        int primaryDiagonalSum = 0, secondaryDiagonalSum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = numbers[col];
            }
            primaryDiagonalSum += matrix[row, row];
            secondaryDiagonalSum += matrix[row, size - 1 - row];
        }
        Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
    }
}

namespace _03._Maximal_Sum;

class Program
{
    static void Main(string[] args)
    {
        int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int rows = sizes[0], cols = sizes[1];
        int[,] matrix = new int[rows, cols];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = numbers[col];
            }
        }

        int squareSize = 3;
        int bestSum = int.MinValue;
        int bestRow = 0, bestCol = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (row + squareSize <= matrix.GetLength(0) && col + squareSize <= matrix.GetLength(1))
                {
                    int squareSum = 0;
                    for (int r = row; r < row + squareSize; r++)
                    {
                        for (int c = col; c < col + squareSize; c++)
                        {
                            squareSum += matrix[r, c];
                        }
                    }

                    if (squareSum > bestSum)
                    {
                        bestSum = squareSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
        }

        Console.WriteLine($"Sum = {bestSum}");
        for (int row = bestRow; row < bestRow + squareSize; row++)
        {
            for (int col = bestCol; col < bestCol + squareSize; col++)
            {
                Console.Write($"{matrix[row, col]} ");
            }
            Console.WriteLine();
        }
    }
}

namespace _05._Snake_Moves;

class Program
{
    static void Main(string[] args)
    {
        int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        char[,] matrix = new char[sizes[0], sizes[1]];
        string snake = Console.ReadLine();

        int snakeIndex = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++, snakeIndex = (snakeIndex + 1) % snake.Length)
            {
                int currentCol = 0;
                if (row % 2 == 0)
                {
                    currentCol = col;
                }
                else
                {
                    currentCol = matrix.GetLength(1) - (col + 1);
                }

                matrix[row, currentCol] = snake[snakeIndex];
            }
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row, col]}");
            }
            Console.WriteLine();
        }
    }
}

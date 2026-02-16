/*You are walking in the park and you encounter a snake! You are terrified and you start running zig-zag, so the snake starts following you. You have a task to visualize the snake's path in a
square form. A snake is represented by a string. The isle is a rectangular matrix of size N x M. A snake starts going down from the top-left corner and slithers its way down. The first cell is
filled with the first symbol of the snake, the second cell is filled with the second symbol, etc. The snake is as long as it takes to fill the stairs– if you reach the end of the string
representing the snake, start again at the beginning. After you fill the matrix with the snake's path, you should print it.*/
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

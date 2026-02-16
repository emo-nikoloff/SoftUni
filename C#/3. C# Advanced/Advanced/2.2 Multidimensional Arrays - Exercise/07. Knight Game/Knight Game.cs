/*Chess is the oldest game, but it is still popular these days. For this task we will use only one chess piece – the Knight. The knight moves to the nearest square, but not on the same row,
column or diagonal. (This can be thought of as moving two squares horizontally, then one square vertically, or moving one square horizontally, then two squares vertically— i.e. in an "L" pattern.)
The knight game is played on a board with dimensions N x N and a lot of chess knights 0 <= K <= N2. You will receive a board with K for knights and '0' for empty cells. Your task is to remove a
minimum of the knights, so there will be no knights left that can attack another knight.*/
namespace _07._Knight_Game;

class Program
{
    static void Main(string[] args)
    {
        int boardSize = int.Parse(Console.ReadLine());
        char[,] board = new char[boardSize, boardSize];

        for (int row = 0; row < board.GetLength(0); row++)
        {
            string input = Console.ReadLine();
            for (int col = 0; col < board.GetLength(1); col++)
            {
                board[row, col] = input[col];
            }
        }

        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                char position = board[row, col];
                if (position == 'K')
                {
                    if (row == 0)
                    {

                    }
                    else if (row == board.GetLength(0) - 1)
                    {

                    }
                    else
                    {

                    }
                }
            }
        }

        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                Console.Write($"{board[row, col]} ");
            }
            Console.WriteLine();
        }
    }
}

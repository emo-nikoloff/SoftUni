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

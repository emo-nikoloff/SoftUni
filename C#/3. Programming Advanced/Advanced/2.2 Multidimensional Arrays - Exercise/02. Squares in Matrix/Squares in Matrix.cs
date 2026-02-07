namespace _02._Squares_in_Matrix;

class Program
{
    static void Main(string[] args)
    {
        int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = sizes[0], cols = sizes[1];
        char[,] matrix = new char[rows, cols];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] characters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = characters[col];
            }
        }

        int equalCharsCount = 0;
        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {

            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                char firstChar = matrix[row, col];
                char secondChar = matrix[row, col + 1];
                char thirdChar = matrix[row + 1, col];
                char fourthChar = matrix[row + 1, col + 1];

                if (firstChar == secondChar && secondChar == thirdChar && thirdChar == fourthChar)
                {
                    equalCharsCount++;
                }
            }
        }
        Console.WriteLine(equalCharsCount);
    }
}

/*Create a program that reads a matrix from the console. Then find the biggest sum of the 2x2 submatrix and print it to the console. On the first line, you will get matrix sizes in format rows,
columns. On the next rows lines, you will get elements for each column, separated with a comma and a space. Print the biggest top-left square, which you find, and the sum of its elements.*/
namespace _05._Square_With_Maximum_Sum;

class Program
{
    static void Main(string[] args)
    {
        int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        int rows = sizes[0], columns = sizes[1];
        int[,] matrix = new int[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            int[] columnsNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            for (int column = 0; column < columns; column++)
            {
                matrix[row, column] = columnsNumbers[column];
            }
        }

        int bestSum = 0;
        int[,] bestSubmatrix = new int[2, 2];
        for (int row = 0; row < rows - 1; row++)
        {
            for (int column = 0; column < columns - 1; column++)
            {
                int squareSum = matrix[row, column] + matrix[row + 1, column] + matrix[row, column + 1] + matrix[row + 1, column + 1];
                if (bestSum < squareSum)
                {
                    bestSum = squareSum;
                    bestSubmatrix[0, 0] = matrix[row, column];
                    bestSubmatrix[1, 0] = matrix[row + 1, column];
                    bestSubmatrix[0, 1] = matrix[row, column + 1];
                    bestSubmatrix[1, 1] = matrix[row + 1, column + 1];
                }
            }
        }

        for (int row = 0; row < bestSubmatrix.GetLength(0); row++)
        {
            for (int column = 0; column < bestSubmatrix.GetLength(1); column++)
            {
                Console.Write($"{bestSubmatrix[row, column]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine(bestSum);
    }
}

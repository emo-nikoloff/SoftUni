/*Create a program that reads a matrix from the console and prints the sum for each column. On the first line, you will get matrix rows. On the next rows lines, you will get elements for each
column separated with a space.*/
namespace _02._Sum_Matrix_Columns;

class Program
{
    static void Main(string[] args)
    {
        int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        int rows = sizes[0], columns = sizes[1];
        int[,] matrix = new int[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            int[] columnsNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int column = 0; column < columns; column++)
            {
                matrix[row, column] = columnsNumbers[column];
            }
        }

        for (int column = 0; column < columns; column++)
        {
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                sum += matrix[row, column];
            }
            Console.WriteLine(sum);
        }
    }
}

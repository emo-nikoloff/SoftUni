namespace _01._Sum_Matrix_Elements;

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

        int sum = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                sum += matrix[row, column];
            }
        }

        Console.WriteLine(rows);
        Console.WriteLine(columns);
        Console.WriteLine(sum);
    }
}

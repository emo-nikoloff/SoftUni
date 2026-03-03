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

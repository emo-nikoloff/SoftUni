namespace _03._Primary_Diagonal;

class Program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];

        int sum = 0;
        for (int row = 0; row < size; row++)
        {
            int[] columnsNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int column = 0; column < size; column++)
            {
                matrix[row, column] = columnsNumbers[column];
            }
            sum += matrix[row, row];
        }
        Console.WriteLine(sum);
    }
}

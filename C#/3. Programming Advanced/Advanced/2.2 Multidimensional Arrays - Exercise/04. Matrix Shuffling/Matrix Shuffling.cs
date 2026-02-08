namespace _04._Matrix_Shuffling;

class Program
{
    static void Main(string[] args)
    {
        int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = sizes[0], cols = sizes[1];
        string[,] matrix = new string[rows, cols];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] data = Console.ReadLine().Split();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = data[col];
            }
        }

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] info = input.Split();
            string command = info[0];

            if (info.Length == 5 && info[0] == "swap")
            {
                int row1 = int.Parse(info[1]), col1 = int.Parse(info[2]);
                int row2 = int.Parse(info[3]), col2 = int.Parse(info[4]);

                if (row1 >= 0 && row1 < matrix.GetLength(0) && col1 >= 0 && col1 < matrix.GetLength(1)
                && row2 >= 0 && row2 < matrix.GetLength(0) && col2 >= 0 && col2 < matrix.GetLength(1))
                {
                    string tempRow = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = tempRow;

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}

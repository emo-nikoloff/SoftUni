/*Write a program that reads a string matrix from the console and performs certain operations with its elements. User input is provided in a similar way as in the problems above – first, you read
the dimensions and then the data. Your program should then receive commands in the format: "swap row1 col1 row2 col2" where row1, col1, row2, col2 are coordinates in the matrix. For a command to
be valid, it should start with the "swap" keyword along with four valid coordinates (no more, no less). You should swap the values at the given coordinates (cell [row1, col1] with cell
[row2, col2]) and print the matrix at each step (thus you'll be able to check if the operation was performed correctly). If the command is not valid (doesn't contain the keyword "swap", has fewer
or more coordinates entered or the given coordinates do not exist), print "Invalid input!" and move on to the next command. Your program should finish when the string "END" is entered.*/
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

/*Create a program that reads N, a number representing rows and cols of a matrix. On the next N lines, you will receive rows of the matrix. Each row consists of ASCII characters. After that, you
will receive a symbol. Find the first occurrence of that symbol in the matrix and print its position in the format: "({row}, {col})". If there is no such symbol, print an error message "{symbol}
does not occur in the matrix".*/
namespace _04._Symbol_in_Matrix;

class Program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        char[,] matrix = new char[size, size];

        for (int row = 0; row < size; row++)
        {
            char[] columnsCharacters = Console.ReadLine().ToCharArray();
            for (int column = 0; column < size; column++)
            {
                matrix[row, column] = columnsCharacters[column];
            }
        }

        char symbol = char.Parse(Console.ReadLine());

        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                if (matrix[row, column] == symbol)
                {
                    Console.WriteLine($"({row}, {column})");
                    return;
                }
            }
        }
        Console.WriteLine($"{symbol} does not occur in the matrix");
    }
}

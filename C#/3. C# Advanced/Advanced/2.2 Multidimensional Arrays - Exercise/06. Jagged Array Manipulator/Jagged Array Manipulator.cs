/*Create a program that populates, analyzes and manipulates the elements of a matrix with an unequal length of its rows. First, you will receive an integer N equal to the number of rows in your
matrix. On the next N lines, you will receive sequences of integers, separated by a single space. Each sequence is a row in the matrix. After populating the matrix, start analyzing it. If a row
and the one below it have equal length, multiply each element in both of them by 2, otherwise - divide by 2. Then, you will receive commands. There are three possible commands:
· "Add {row} {column} {value}" - add {value} to the element at the given indexes, if they are valid.
· "Subtract {row} {column} {value}" - subtract {value} from the element at the given indexes, if they are valid.
· "End" - print the final state of the matrix (all elements separated by a single space) and stop the program*/
namespace _06._Jagged_Array_Manipulator;

class Program
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        int[][] jagged = new int[rows][];

        for (int row = 0; row < rows; row++)
        {
            jagged[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
        }

        for (int row = 0; row < jagged.Length - 1; row++)
        {
            if (jagged[row].Length == jagged[row + 1].Length)
            {
                jagged[row] = jagged[row].Select(n => n * 2).ToArray();
                jagged[row + 1] = jagged[row + 1].Select(n => n * 2).ToArray();
            }
            else
            {
                jagged[row] = jagged[row].Select(n => n / 2).ToArray();
                jagged[row + 1] = jagged[row + 1].Select(n => n / 2).ToArray();
            }
        }

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] info = input.Split();
            string command = info[0];
            int row = int.Parse(info[1]);
            int col = int.Parse(info[2]);
            int value = int.Parse(info[3]);

            if (row < 0 || row >= jagged.Length ||
                col < 0 || col >= jagged[row].Length)
            {
                continue;
            }

            switch (command)
            {
                case "Add":
                    jagged[row][col] += value;
                    break;
                case "Subtract":
                    jagged[row][col] -= value;
                    break;
            }
        }

        for (int row = 0; row < jagged.Length; row++)
        {
            for (int col = 0; col < jagged[row].Length; col++)
            {
                Console.Write($"{jagged[row][col]} ");
            }
            Console.WriteLine();
        }
    }
}

namespace _02._Rally_Racing;

class Program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        string[,] matrix = new string[size, size];

        string carNumber = Console.ReadLine();

        (int row, int col) firstTunnel = (-1, -1);
        (int row, int col) secondTunnel = (-1, -1);

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = input[col];

                if (matrix[row, col] == "T")
                {
                    if (firstTunnel.row == -1)
                    {
                        firstTunnel = (row, col);
                    }
                    else
                    {
                        secondTunnel = (row, col);
                    }
                }
            }
        }

        string direction = string.Empty;

        int distanceTravelled = 0, carRow = 0, carCol = 0;
        bool finished = false;
        while ((direction = Console.ReadLine()) != "End")
        {
            switch (direction)
            {
                case "up":
                    carRow--;
                    break;
                case "down":
                    carRow++;
                    break;
                case "left":
                    carCol--;
                    break;
                case "right":
                    carCol++;
                    break;
            }

            if (matrix[carRow, carCol] == ".")
            {
                distanceTravelled += 10;
            }
            else if (matrix[carRow, carCol] == "T")
            {
                distanceTravelled += 30;

                if (carRow == firstTunnel.row && carCol == firstTunnel.col)
                {
                    matrix[firstTunnel.row, firstTunnel.col] = ".";
                    matrix[secondTunnel.row, secondTunnel.col] = ".";
                    carRow = secondTunnel.row;
                    carCol = secondTunnel.col;
                }
                else
                {
                    matrix[firstTunnel.row, firstTunnel.col] = ".";
                    matrix[secondTunnel.row, secondTunnel.col] = ".";
                    carRow = firstTunnel.row;
                    carCol = firstTunnel.col;
                }
            }

            else if (matrix[carRow, carCol] == "F")
            {
                distanceTravelled += 10;
                finished = true;
                break;
            }
        }

        if (finished)
        {
            Console.WriteLine($"Racing car {carNumber} finished the stage!");
        }
        else
        {
            Console.WriteLine($"Racing car {carNumber} DNF.");
        }

        Console.WriteLine($"Distance covered {distanceTravelled} km.");

        matrix[carRow, carCol] = "C";

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
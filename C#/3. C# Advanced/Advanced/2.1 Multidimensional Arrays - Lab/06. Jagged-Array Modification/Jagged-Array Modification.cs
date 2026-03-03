namespace _06._Jagged_Array_Modification;

class Program
{
    static void Main(string[] args)
    {
        int rowsCount = int.Parse(Console.ReadLine());
        int[][] jagged = new int[rowsCount][];

        for (int row = 0; row < jagged.Length; row++)
        {
            string[] numbers = Console.ReadLine().Split();
            jagged[row] = new int[numbers.Length];

            for (int column = 0; column < jagged[row].Length; column++)
            {
                jagged[row][column] = int.Parse(numbers[column]);
            }
        }

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputTokens = input.Split();
            string command = inputTokens[0];
            int row = int.Parse(inputTokens[1]);
            int column = int.Parse(inputTokens[2]);
            int number = int.Parse(inputTokens[3]);

            if (row >= 0 && row < jagged.Length
                                    && column >= 0 && column < jagged[row].Length)
            {
                switch (command)
                {
                    case "Add":
                        jagged[row][column] += number;
                        break;
                    case "Subtract":
                        jagged[row][column] -= number;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid coordinates");
            }
        }

        for (int r = 0; r < jagged.Length; r++)
        {
            for (int c = 0; c < jagged[r].Length; c++)
            {
                Console.Write($"{jagged[r][c]} ");
            }
            Console.WriteLine();
        }
    }
}

// Напишете програма, която чете цяло число n, въведено от потребителя, и отпечатва пирамида от числа като в примерите:
int n = int.Parse(Console.ReadLine());

int row = 1;
int col = 1;
for (int i = 1; i <= n; i++)
{
    Console.Write($"{i} ");

    if (col == row)
    {
        col = 1;
        row++;
        Console.WriteLine();
    }
    else
    {
        col++;
    }
}
// Да се напише програма, която чете число n, въведено от потребителя, и печата триъгълник от долари
// Подсказка: завъртете два вложени цикъла: за първия row = 1 … n; за втория col = 1 … row.
int number = int.Parse(Console.ReadLine());

for (int row = 1; row <= number; row++)
{
    for (int cols = 1; cols <= row - 1; cols++)
    {
        Console.Write("$ ");
    }
    Console.WriteLine("$");
}
// Напишете програма, която чете цяло положително число n, въведено от потребителя, и чертае на конзолата квадратна рамка с размер n * n.
// Подсказки:
// •	Отпечатайте горната част: знак “+”, n-2 пъти знак “-”, знак “+”.
// •	Отпечатайте средната част: в цикъл n-2 пъти печатайте знак “|”, n-2 пъти знак “-”, знак “|”.
// •	Отпечатайте долната част: знак “+”, n-2 пъти знак “-”, знак “+”.

int number = int.Parse(Console.ReadLine());

int counter = 0;
for (int i = 1; i <= number; i++)
{
    Console.Write("+ ");
    for (int j = 1; j < number - 1; j++)
    {
        Console.Write("- ");
        counter++;
    }
    Console.WriteLine("+");

    if (counter >= number)
        break;

    for (int k = 1; k < number - 1; k++)
    {
        Console.Write("| ");
        for (int l = 1; l < number - 1; l++)
        {
            Console.Write("- ");
            counter++;
        }
        Console.WriteLine("|");
    }
}
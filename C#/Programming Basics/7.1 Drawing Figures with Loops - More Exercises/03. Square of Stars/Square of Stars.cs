// Напишете програма, която чете число n, въведено от потребителя, и чертае квадрат от n * n звездички.
// Разликата с предходната задача е, че между всеки две звездички има по един интервал.
int number = int.Parse(Console.ReadLine());

for (int i = 1; i <= number; i++)
{
    for (int j = 1; j <= number - 1; j++)
    {
        Console.Write("* ");
    }
    Console.WriteLine("*");
}
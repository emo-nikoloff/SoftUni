// Напишете програма, която чете цяло число n (3 ≤ n ≤ 100), въведено от потребителя, и печата слънчеви очила с размер 5*n x n.
// Подсказки:
// •   Отпечатайте най-горния ред от очилата:
//   o   2*n звездички; n интервала; 2 * n звездички
// •   Отпечатайте средните n-2 реда:
//   o   звездичка; 2 * n - 2 наклонени черти; звездичка; n интервала; звездичка; 2 * n - 2 наклонени черти; звездичка
//   o   когато редът е (n-1) / 2 - 1, печатайте n вертикални черти вместо n интервала
// •   Отпечатайте най-долния ред от очилата:
//   o   2*n звездички; n интервала; 2 * n звездички
int number = int.Parse(Console.ReadLine());

if (number < 3 || number > 100)
    return;

for (int star = 1; star <= 2 * number; star++)
    Console.Write("*");
for (int space = 1; space <= number; space++)
    Console.Write(" ");
for (int star = 1; star <= 2 * number; star++)
    Console.Write("*");

Console.WriteLine();

for (int middlePart = 0; middlePart < number - 2; middlePart++)
{
    Console.Write("*");
    for (int glass = 1; glass <= (2 * number) - 2; glass++)
        Console.Write("/");
    Console.Write("*");

    if (middlePart == ((number - 1) / 2 - 1))
    {
        for (int space = 1; space <= number; space++)
            Console.Write("|");
    }
    else
    {
        for (int space = 1; space <= number; space++)
            Console.Write(" ");
    }

    Console.Write("*");
    for (int glass = 1; glass <= (2 * number) - 2; glass++)
        Console.Write("/");
    Console.Write("*");

    Console.WriteLine();
}

for (int star = 1; star <= 2 * number; star++)
    Console.Write("*");
for (int space = 1; space <= number; space++)
    Console.Write(" ");
for (int star = 1; star <= 2 * number; star++)
    Console.Write("*");
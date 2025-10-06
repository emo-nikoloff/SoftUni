// Напишете програма, която чете число n (2 ≤ n ≤ 100), въведено от потребителя, и печата къщичка с размер n x n.
// Подсказки:
// •   Отпечатайте в цикъл покрива на къщичката:
//   o   Той съдържа (n + 1) / 2 реда.
//   o   На първия си ред съдържа 1 звездичка при нечетно n или 2 звездички при четно n.
//   o   На всеки следващ ред съдържа с 2 звездички повече.
// •   Отпечатайте в цикъл основата на къщичката: n / 2 - 1 реда.
int number = int.Parse(Console.ReadLine());

if (number < 2 || number > 100)
    return;

for (int roof = 0; roof < (number + 1) / 2; roof++)
{
    if (number % 2 == 0)
    {
        for (int start = roof; start < (number / 2) - 1; start++)
            Console.Write("-");
        for (int material = 0; material <= roof; material++)
            Console.Write("**");
        for (int start = roof; start < (number / 2) - 1; start++)
            Console.Write("-");
    }
    else
    {
        for (int start = roof; start < (number - 1) / 2; start++)
            Console.Write("-");
        for (int material = 1; material <= (roof + 1) * 2 - 1; material++)
            Console.Write("*");
        for (int start = roof; start < (number - 1) / 2; start++)
            Console.Write("-");
    }

    Console.WriteLine();
}

for (int foundation = 1; foundation <= number / 2; foundation++)
{
    Console.Write("|");
    for (int furniture = 1; furniture <= number - 2; furniture++)
        Console.Write("*");
    Console.WriteLine("|");
}
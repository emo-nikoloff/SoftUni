// Напишете програма, която чете цяло положително число n, въведено от потребителя, и печата ромбче от звездички с размер n.
// Подсказки:
// •	Разделете ромба на горна и долна част и ги печатайте с два отделни цикъла.
// •	За горната част завъртете цикъл за row от 1 до n:
//    o   Отпечатайте n-row интервала.
//    o	  Отпечатайте “*”.
//    o   Отпечатайте row-1 пъти “ *”.
// •	Долната част отпечатайте аналогично на горната с цикъл от 1 до n-1.
int number = int.Parse(Console.ReadLine());

for (int topRow = 1; topRow <= number; topRow++)
{
    for (int topCol = 1; topCol <= number - topRow; topCol++)
        Console.Write(" ");
    Console.Write("*");

    for (int topTurn = 1; topTurn <= topRow - 1; topTurn++)
        Console.Write(" *");
    Console.WriteLine();
}

for (int bottomRow = 1; bottomRow <= number - 1; bottomRow++)
{
    for (int bottomCol = number - 1; bottomCol >= number - bottomRow; bottomCol--)
        Console.Write(" ");
    Console.Write("*");

    for (int topTurn = number - 1; topTurn > bottomRow; topTurn--)
        Console.Write(" *");
    Console.WriteLine();
}
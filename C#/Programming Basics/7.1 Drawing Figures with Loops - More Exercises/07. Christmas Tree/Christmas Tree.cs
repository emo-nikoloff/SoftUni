// Напишете програма, която чете число n (1 ≤ n ≤ 100), въведено от потребителя, и печата коледна елха с размер n.
// Подсказки: 
// •   В цикъл за i от 0 до n печатайте (за лявата част на елхата):
//   o   n-i интервала; n звездички; вертикална черта.
// •   Аналогично довършете дясната част на елхата.
int number = int.Parse(Console.ReadLine());

for (int i = 0; i <= number; i++)
{
    for (int space = 1; space <= number - i; space++)
        Console.Write(" ");
    for (int star = 1; star <= i; star++)
        Console.Write("*");

    Console.Write(" | ");

    for (int star = 1; star <= i; star++)
        Console.Write("*");
    Console.WriteLine();
}
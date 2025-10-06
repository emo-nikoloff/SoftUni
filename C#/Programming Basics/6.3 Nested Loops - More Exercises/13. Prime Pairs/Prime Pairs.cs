// Напишете програма, която генерира и принтира на конзолата четирицифрени числа,
// в които първата и втората двойка цифри образуват двуцифрени прости числа (пример за такова число 1723).
// Крайната стойност до която трябва да се генерират двойките се определя от други 2 цифри, подадени като вход, които определят с колко крайната стойност е по-голяма от началната.
int firstPair = int.Parse(Console.ReadLine());
int secondPair = int.Parse(Console.ReadLine());
int diffBetweenStartAndEndOfFirstPair = int.Parse(Console.ReadLine());
int diffBetweenStartAndEndOfSecondPair = int.Parse(Console.ReadLine());

for (int i = firstPair; i <= (firstPair + diffBetweenStartAndEndOfFirstPair); i++)
{
    for (int j = secondPair; j <= (secondPair + diffBetweenStartAndEndOfSecondPair); j++)
    {
        if (i % 2 == 0 || j % 2 == 0 || i % 3 == 0 || j % 3 == 0 || i % 5 == 0 || j % 5 == 0 || i % 7 == 0 || j % 7 == 0)
            continue;
        Console.WriteLine($"{i}{j}");
    }
}
// Напишете програма, която чете n на брой цели числа. Принтирайте най-голямото и най-малкото число сред въведените.
int number = int.Parse(Console.ReadLine());
int max = int.MinValue;
int min = int.MaxValue;

for (int i = 0; i < number; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());

    if (currentNumber > max)
        max = currentNumber;
    if (currentNumber < min)
        min = currentNumber;
}
Console.WriteLine($"Max number: {max}");
Console.WriteLine($"Min number: {min}");
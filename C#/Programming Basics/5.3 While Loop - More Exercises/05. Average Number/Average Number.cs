// Напишете програма, която прочита едно число n, след това прочита n на брой цели числа и принтира средно аритметичното на тяхната сума число,
// форматирано до втората цифра след десетични знак.
int number = int.Parse(Console.ReadLine());

double sum = 0;
for (int i = 0; i < number; i++)
{
    int num = int.Parse(Console.ReadLine());
    sum += num;
}
Console.WriteLine($"{sum / number:f2}");
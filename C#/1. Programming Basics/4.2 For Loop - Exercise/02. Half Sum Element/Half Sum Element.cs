// Да се напише програма, която чете n-на брой цели числа, въведени от потребителя, и проверява дали сред тях съществува число, което е равно на сумата на всички останали. 
// •	Ако има такъв елемент печата "Yes" и на нов ред "Sum = "  + неговата стойност
// •	Ако няма такъв елемент печата "No" и на нов ред "Diff = " + разликата между най-големия елемент и сумата на останалите (по абсолютна стойност)
int numbers = int.Parse(Console.ReadLine());

int sum = 0;
int max = int.MinValue;
for (int i = 1; i <= numbers; i++)
{
    int number = int.Parse(Console.ReadLine());

    if (number > max)
    {
        max = number;
    }

    sum += number;
}

int sumWithoutMaxNumber = sum - max;
if (sumWithoutMaxNumber == max)
{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {max}");
}
else
{
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {Math.Abs(max - sumWithoutMaxNumber)}");
}
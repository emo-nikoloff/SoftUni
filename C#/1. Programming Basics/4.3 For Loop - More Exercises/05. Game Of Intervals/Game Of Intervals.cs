// Напишете програма, която да пресмята резултата от игра. Първо получавате число, което показва колко хода ще продължи играта.
// После за всеки ход на играта ще получавате по едно ново число. Според интервала в който попада числото се прибавят точки.
// Ако числото е отрицателно или по-голямо 50, тогава то е невалидно. В началото на играта резултата е 0 и на всеки ход се прибавят точки по следният начин:
// •	От 0 до 9  20 % от числото
// •	От 10 до 19  30 % от числото
// •	От 20 до 29  40 % от числото
// •	От 30 до 39  50 точки
// •	От 40 до 50  100 точки
// •	Невалидно число  резултата се дели на 2
// Освен резултата програмата трябва да изкарва статистика за проценти числа в дадените интервали.
int turns = int.Parse(Console.ReadLine());

double points = 0;
double numbersBetween0And9 = 0;
double numbersBetween10And19 = 0;
double numbersBetween20And29 = 0;
double numbersBetween30And39 = 0;
double numbersBetween40And50 = 0;
double numbersInvalid = 0;
for (int i = 0; i < turns; i++)
{
    int numbers = int.Parse(Console.ReadLine());

    if (numbers >= 0 && numbers <= 9)
    {
        points += numbers * 0.2;
        numbersBetween0And9++;
    }
    else if (numbers >= 10 && numbers <= 19)
    {
        points += numbers * 0.3;
        numbersBetween10And19++;
    }
    else if (numbers >= 20 && numbers <= 29)
    {
        points += numbers * 0.4;
        numbersBetween20And29++;
    }
    else if (numbers >= 30 && numbers <= 39)
    {
        points += 50;
        numbersBetween30And39++;
    }
    else if (numbers >= 40 && numbers <= 50)
    {
        points += 100;
        numbersBetween40And50++;
    }
    else if (numbers > 50 || numbers < 0)
    {
        points /= 2;
        numbersInvalid++;
    }
}

numbersBetween0And9 = numbersBetween0And9 / turns * 100;
numbersBetween10And19 = numbersBetween10And19 / turns * 100;
numbersBetween20And29 = numbersBetween20And29 / turns * 100;
numbersBetween30And39 = numbersBetween30And39 / turns * 100;
numbersBetween40And50 = numbersBetween40And50 / turns * 100;
numbersInvalid = numbersInvalid / turns * 100;
Console.WriteLine($"{points:f2}");
Console.WriteLine($"From 0 to 9: {numbersBetween0And9:f2}%");
Console.WriteLine($"From 10 to 19: {numbersBetween10And19:f2}%");
Console.WriteLine($"From 20 to 29: {numbersBetween20And29:f2}%");
Console.WriteLine($"From 30 to 39: {numbersBetween30And39:f2}%");
Console.WriteLine($"From 40 to 50: {numbersBetween40And50:f2}%");
Console.WriteLine($"Invalid numbers: {numbersInvalid:f2}%");
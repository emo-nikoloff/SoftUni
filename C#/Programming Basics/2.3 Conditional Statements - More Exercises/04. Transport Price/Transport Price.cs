// Студент трябва да пропътува n километра. Той има избор измежду три вида транспорт:
// •	Такси.Начална такса: 0.70 лв.Дневна тарифа: 0.79 лв. / км.Нощна тарифа: 0.90 лв. / км.
// •	Автобус.Дневна / нощна тарифа: 0.09 лв. / км.Може да се използва за разстояния минимум 20 км.
// •	Влак. Дневна / нощна тарифа: 0.06 лв. / км.Може да се използва за разстояния минимум 100 км.
// Напишете програма, която въвежда броя километри n и период от деня (ден или нощ) и изчислява цената на най-евтиния транспорт.
int travelDistance = int.Parse(Console.ReadLine());
string dayNight = Console.ReadLine();

double sum = 0;
if (travelDistance < 20)
{
    if (dayNight == "day")
    {
        sum = 0.7 + travelDistance * 0.79;
    }
    else if (dayNight == "night")
    {
        sum = 0.7 + travelDistance * 0.9;
    }
}
else if (travelDistance < 100)
{
    sum = travelDistance * 0.09;
}
else
{
    sum = travelDistance * 0.06;
}
Console.WriteLine($"{sum:f2}");
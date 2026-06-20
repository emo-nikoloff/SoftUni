// Симона и Светлин ще ходят на почивка в Африка и искат да отидат на сафари. Понеже за делничните дни вече имат планове, решават, че ще отидат събота или неделя.
// Напишете програма, която изчислява колко ще им струва ходенето на сафари и дали бюджетът им ще им стигне да отидат, като имате предвид следното:
// •	Цената на един литър гориво е 2.10 лв.
// •	Цената за екскурзовод е 100лв.
// •	В зависимост от деня има отстъпки от общата цена - за събота 10%, а за неделя 20%
double budget = double.Parse(Console.ReadLine());
double fuel = double.Parse(Console.ReadLine());
string dayOfWeek = Console.ReadLine();

double fuelPrice = 2.1 * fuel;
double sum = 100 + fuelPrice;

switch (dayOfWeek)
{
    case "Saturday":
        sum = sum - (sum * 0.1);
        break;
    case "Sunday":
        sum = sum - (sum * 0.2);
        break;
}

if (budget >= sum)
    Console.WriteLine($"Safari time! Money left: {budget - sum:f2} lv.");
else
    Console.WriteLine($"Not enough money! Money needed: {Math.Abs(budget - sum):f2} lv.");
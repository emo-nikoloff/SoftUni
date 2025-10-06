// Деси трябва да заведе котката си на ветеринар, но паркингът се заплаща. Напишете програма, която пресмята колко общо трябва да се плати за престоя на колата на Деси на паркинга.
// Паркингът е различен от останалите и има разнообразен ценоразпис. За всеки четен ден и нечетен час, паркингът таксува 2.50 лева.
// Във всеки нечетен ден и четен час таксата е 1.25 лева, във всички останали случаи се заплаща 1 лев. Таксуването става на всеки изминал час от деня.
// Всеки един от изходите трябва да бъде закръглен до втория знак след десетичната запетая.
int days = int.Parse(Console.ReadLine());
int hours = int.Parse(Console.ReadLine());

double totalSum = 0, todaySum = 0;
for (int day = 1; day <= days; day++)
{
    double price = 0;
    for (int hour = 1; hour <= hours; hour++)
    {
        price = 1;
        if (day % 2 == 0 && hour % 2 != 0)
            price = 2.5;
        else if (day % 2 != 0 && hour % 2 == 0)
            price = 1.25;
        todaySum += price;
        totalSum += price;
    }
    Console.WriteLine($"Day: {day} - {todaySum:f2} leva");
    todaySum = 0;
}
Console.WriteLine($"Total: {totalSum:f2} leva");
// Катерачи от цяла България се събират на групи и набелязват следващите върхове за изкачване. Според размера на групата, катерачите ще изкачват различни върхове.
// •	Група до 5 човека – изкачват Мусала
// •	Група от 6 до 12 човека – изкачват Монблан
// •	Група от 13 до 25 човека – изкачват Килиманджаро
// •	Група от 26 до 40 човека –  изкачват К2
// •	Група от 41 или повече човека – изкачват Еверест
// Да се напише програма, която изчислява процента на катерачите изкачващи всеки връх.
int groups = int.Parse(Console.ReadLine());

int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0;
for (int i = 0; i < groups; i++)
{
    int peopleInGroup = int.Parse(Console.ReadLine());

    if (peopleInGroup <= 5)
        c1 += peopleInGroup;
    else if (peopleInGroup <= 12)
        c2 += peopleInGroup;
    else if (peopleInGroup <= 25)
        c3 += peopleInGroup;
    else if (peopleInGroup <= 40)
        c4 += peopleInGroup;
    else
        c5 += peopleInGroup;
}

int totalNumberOfClimbers = c1 + c2 + c3 + c4 + c5;

double p1 = 100.0 * c1 / totalNumberOfClimbers;
double p2 = 100.0 * c2 / totalNumberOfClimbers;
double p3 = 100.0 * c3 / totalNumberOfClimbers;
double p4 = 100.0 * c4 / totalNumberOfClimbers;
double p5 = 100.0 * c5 / totalNumberOfClimbers;
Console.WriteLine($"{p1:f2}%");
Console.WriteLine($"{p2:f2}%");
Console.WriteLine($"{p3:f2}%");
Console.WriteLine($"{p4:f2}%");
Console.WriteLine($"{p5:f2}%");
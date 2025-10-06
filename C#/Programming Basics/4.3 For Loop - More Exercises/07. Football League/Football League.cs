// Екипът на СофтУни си организира футболен турнир. Първоначално прочитаме от конзолата капацитета на стадиона и броят на всички фенове.
// След това за всеки фен се чете секторът, в който се намира. Феновете на първия отбор са в сектор А и Б, а на втория – В и Г.
// Да се напише програма, която изчислява процентите на феновете във всеки сектор, спрямо общия брой фенове на стадиона, както и общият процент на феновете за двата отбора,
// спрямо капацитета на стадиона. Общият брой на феновете НЕ надвишава капацитета на стадиона.
int stadiumCapacity = int.Parse(Console.ReadLine());
int fans = int.Parse(Console.ReadLine());

int fansInA = 0;
int fansInB = 0;
int fansInV = 0;
int fansInG = 0;
double fansInAInPercent = 0;
double fansInBInPercent = 0;
double fansInVInPercent = 0;
double fansInGInPercent = 0;
double allFans = 0;
for (int i = 0; i < fans; i++)
{
    string sector = Console.ReadLine();

    if (sector == "A")
        fansInA++;
    else if (sector == "B")
        fansInB++;
    else if (sector == "V")
        fansInV++;
    else if (sector == "G")
        fansInG++;
}

fansInAInPercent = ((double)fansInA / fans) * 100;
fansInBInPercent = ((double)fansInB / fans) * 100;
fansInVInPercent = ((double)fansInV / fans) * 100;
fansInGInPercent = ((double)fansInG / fans) * 100;
allFans = ((double)fans / stadiumCapacity) * 100;
Console.WriteLine($"{fansInAInPercent:f2}%");
Console.WriteLine($"{fansInBInPercent:f2}%");
Console.WriteLine($"{fansInVInPercent:f2}%");
Console.WriteLine($"{fansInGInPercent:f2}%");
Console.WriteLine($"{allFans:f2}%");
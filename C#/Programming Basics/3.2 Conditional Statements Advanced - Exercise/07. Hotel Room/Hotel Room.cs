// Хотел предлага 2 вида стаи: студио и апартамент. Напишете програма, която изчислява цената за целия престой за студио и апартамент. Цените зависят от месеца на престоя:
// Май и октомври                  Юни и септември                  Юли и август
// Студио – 50 лв./нощувка         Студио – 75.20 лв./нощувка       Студио – 76 лв./нощувка
// Апартамент – 65 лв./нощувка     Апартамент – 68.70 лв./нощувка   Апартамент – 77 лв./нощувка
// Предлагат се и следните отстъпки:
// •	За студио, при повече от 7 нощувки през май и октомври : 5 % намаление.
// •	За студио, при повече от 14 нощувки през май и октомври : 30 % намаление.
// •	За студио, при повече от 14 нощувки през юни и септември: 20 % намаление.
// •	За апартамент, при повече от 14 нощувки, без значение от месеца : 10 % намаление.
string month = Console.ReadLine();
int nights = int.Parse(Console.ReadLine());

double studio = 0;
double apartament = 0;
double sumStudio = 0;
double sumApartament = 0;
switch (month)
{
    case "May":
    case "October":
        studio = 50;
        apartament = 65;
        switch (nights)
        {
            case > 14:
                sumStudio = nights * studio - (nights * studio * 0.3);
                sumApartament = nights * apartament - (nights * apartament * 0.1);
                break;
            case > 7:
                sumStudio = nights * studio - (nights * studio * 0.05);
                sumApartament = nights * apartament;
                break;
            default:
                sumStudio = nights * studio;
                sumApartament = nights * apartament;
                break;
        }
        break;
    case "June":
    case "September":
        studio = 75.2;
        apartament = 68.7;
        switch (nights)
        {
            case > 14:
                sumStudio = nights * studio - (nights * studio * 0.2);
                sumApartament = nights * apartament - (nights * apartament * 0.1);
                break;
            default:
                sumStudio = nights * studio;
                sumApartament = nights * apartament;
                break;
        }
        break;
    case "July":
    case "August":
        studio = 76;
        apartament = 77;
        switch (nights)
        {
            case > 14:
                sumStudio = nights * studio;
                sumApartament = nights * apartament - (nights * apartament * 0.1);
                break;
            default:
                sumStudio = nights * studio;
                sumApartament = nights * apartament;
                break;
        }
        break;
}
Console.WriteLine($"Apartment: {sumApartament:f2} lv.");
Console.WriteLine($"Studio: {sumStudio:f2} lv.");
// Напишете програма, която спрямо даден бюджет и сезон да пресмята цената, локацията и мястото на настаняване за ваканция. Сезоните са лято и зима – "Summer" и "Winter".
// Локациите са – "Alaska" и "Morocco". Възможните места за настаняване – "Hotel", "Hut" или "Camp".
// •	При бюджет по-малък или равен от 1000лв.:
//    o    Настаняване в "Camp"
//    o    Според сезона локацията ще е една от следните и ще струва определен процент от бюджета:
//           Лято – Аляска – 65% от бюджета
//           Зима – Мароко – 45% от бюджета
// •	При бюджет по-голям от 1000лв. и по-малък или равен от 3000лв.:
//    o    Настаняване в "Hut"
//    o	   Според сезона локацията ще е една от следните и ще струва определен процент от бюджета:
//       	  Лято – Аляска – 80% от бюджета
//       	  Зима – Мароко – 60% от бюджета
// •	При бюджет по-голям от 3000лв.:
//    o    Настаняване в "Hotel"
//    o	   Според сезона локацията ще е една от следните и ще струва 90% от бюджета:
//       	  Лято – Аляска
//       	  Зима – Мароко
double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

string stay = "";
string place = "";
switch (budget)
{
    case > 3000:
        stay = "Hotel";

        switch (season)
        {
            case "Summer":
                place = "Alaska";
                break;
            case "Winter":
                place = "Morocco";
                break;
        }
        budget *= 0.9;
        break;
    case > 1000:
        stay = "Hut";

        switch (season)
        {
            case "Summer":
                place = "Alaska";
                budget *= 0.8;
                break;
            case "Winter":
                place = "Morocco";
                budget *= 0.6;
                break;
        }
        break;
    default:
        stay = "Camp";

        switch (season)
        {
            case "Summer":
                place = "Alaska";
                budget *= 0.65;
                break;
            case "Winter":
                place = "Morocco";
                budget *= 0.45;
                break;
        }
        break;
}
Console.WriteLine($"{place} - {stay} - {budget:f2}");
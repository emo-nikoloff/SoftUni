// Напишете програма, която спрямо даден бюджет и сезон да пресмята цената, типа и класа на кола под наем.
// Сезоните са лято и зима – "Summer" и "Winter". Типа коли са кабрио и джип – "Cabrio" и "Jeep". 
// •	При бюджет по-малък или равен от 100лв.:
//    o    Класът ще е - "Economy class"
//    o    Според сезона колата и цената ще са:
//           Лято – Кабрио – 35% от бюджета
//           Зима – Джип – 65% от бюджета
// •	При бюджет по-голям от 100лв. и по-малък или равен от 500лв.:
//    o    Класът ще е - "Compact class"
//    o    Според сезона колата и цената ще са:
//           Лято – Кабрио – 45% от бюджета
//           Зима – Джип – 80% от бюджета
// •	При бюджет по-голям от 500лв.:
//    o    Класът ще е – "Luxury class"
//    o    За всеки сезон колата ще е джип и цената ще е:
//           90 % от бюджета
double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

string carClass = "";
string carType = "";
switch (budget)
{
    case > 500:
        carClass = "Luxury class";
        carType = "Jeep";
        budget *= 0.9;
        break;
    case > 100:
        carClass = "Compact class";

        switch (season)
        {
            case "Summer":
                carType = "Cabrio";
                budget *= 0.45;
                break;
            case "Winter":
                carType = "Jeep";
                budget *= 0.8;
                break;
        }
        break;
    default:
        carClass = "Economy class";

        switch (season)
        {
            case "Summer":
                carType = "Cabrio";
                budget *= 0.35;
                break;
            case "Winter":
                carType = "Jeep";
                budget *= 0.65;
                break;
        }
        break;
}
Console.WriteLine(carClass);
Console.WriteLine($"{carType} - {budget:f2}");
// Странно, но повечето хора си плануват от рано почивката. Млад програмист разполага с определен бюджет и свободно време в даден сезон.
// Напишете програма, която да приема на входа бюджета и сезона, а на изхода да изкарва, къде ще почива програмиста и колко ще похарчи.
// Бюджета определя дестинацията, а сезона определя колко от бюджета ще изхарчи. Ако е лято ще почива на къмпинг, а зимата в хотел.
// Ако е в Европа, независимо от сезона ще почива в хотел. Всеки къмпинг или хотел, според дестинацията, има собствена цена която отговаря на даден процент от бюджета: 
// •   При 100лв. или по-малко – някъде в България
//    o  Лято – 30% от бюджета
//    o  Зима – 70% от бюджета
// •   При 1000лв. или по малко – някъде на Балканите
//    o  Лято – 40% от бюджета
//    o  Зима – 80% от бюджета
// •   При повече от 1000лв. – някъде из Европа
//    o   При пътуване из Европа, независимо от сезона ще похарчи 90% от бюджета.
double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

string destination = "";
string relax = "";
switch (budget)
{
    case <= 100:
        destination = "Bulgaria";

        switch (season)
        {
            case "summer":
                budget *= 0.3;
                relax = "Camp";
                break;
            case "winter":
                budget *= 0.7;
                relax = "Hotel";
                break;
        }
        break;
    case <= 1000:
        destination = "Balkans";

        switch (season)
        {
            case "summer":
                budget *= 0.4;
                relax = "Camp";
                break;
            case "winter":
                budget *= 0.8;
                relax = "Hotel";
                break;
        }
        break;
    default:
        destination = "Europe";
        budget = budget *= 0.9;
        relax = "Hotel";
        break;
}
Console.WriteLine($"Somewhere in {destination}");
Console.WriteLine($"{relax} - {budget:f2}");
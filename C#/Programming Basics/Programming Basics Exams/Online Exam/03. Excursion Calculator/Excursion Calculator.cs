// Туристическа агенция предлага екскурзии на различни цени, според сезона и броя на хората. Напишете програма, която да изчислява цената, според данните от таблицата:
//                Пролет(spring)        Лято(summer)          Есен(autumn)          Зима(winter)
// До 5 човека	  50.00 лв. на човек	48.50 лв. на човек	  60.00 лв. на човек	86.00 лв. на човек
// Над 5 човека	  48.00 лв. на човек	45.00 лв. на човек	  49.50 лв. на човек	85.00 лв. на човек
// В зависимост от сезона, може да има отстъпка или оскъпяване на цената, съответно:
// •	При "summer" -> 15% отстъпка
// •	При "winter" -> 8% оскъпяване
int people = int.Parse(Console.ReadLine());
string season = Console.ReadLine();

double price = 0;
switch (season)
{
    case "spring":
        switch (people)
        {
            case <= 5:
                price = 50;
                break;
            default:
                price = 48;
                break;
        }
        break;
    case "summer":
        switch (people)
        {
            case <= 5:
                price = 48.5;
                break;
            default:
                price = 45;
                break;
        }
        break;
    case "autumn":
        switch (people)
        {
            case <= 5:
                price = 60;
                break;
            default:
                price = 49.5;
                break;
        }
        break;
    case "winter":
        switch (people)
        {
            case <= 5:
                price = 86;
                break;
            default:
                price = 85;
                break;
        }
        break;
}
double sum = people * price;

switch (season)
{
    case "summer":
        sum = sum - (sum * 0.15);
        break;
    case "winter":
        sum = sum + (sum * 0.08);
        break;
}
Console.WriteLine($"{sum:f2} leva.");
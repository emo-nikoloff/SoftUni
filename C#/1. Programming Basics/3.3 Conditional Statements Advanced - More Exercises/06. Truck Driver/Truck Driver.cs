// Напишете програма която пресмята колко пари ще изкара шофьор на ТИР за един сезон.
// На входа програмата получава през кой сезон ще работи шофьора, както и колко километра на месец ще кара. Един сезон е 4 месеца.
// Според зависи сезона и броя километри на месец ще му се заплаща различна сума на километър:
//                                Пролет / Есен    Лято           Зима
// км на месец <= 5000            0.75 лв./км	   0.90 лв./км	  1.05 лв./км
// 5000 < км на месец <= 10000    0.95 лв./км	   1.10 лв./км	  1.25 лв./км
// 10000 < км на месец <= 20000   1.45 лв./км – за който и да е сезон
// След като са извадени 10% за данъци се отпечатват останалите пари.
string season = Console.ReadLine();
double kilometers = double.Parse(Console.ReadLine());

double salary = 0;
switch (kilometers)
{
    case < 5000:
        switch (season)
        {
            case "Spring":
            case "Autumn":
                salary = ((kilometers * 0.75) * 4) - (((kilometers * 0.75) * 4) * 0.1);
                break;
            case "Summer":
                salary = ((kilometers * 0.9) * 4) - (((kilometers * 0.9) * 4) * 0.1);
                break;
            case "Winter":
                salary = ((kilometers * 1.05) * 4) - (((kilometers * 1.05) * 4) * 0.1);
                break;
        }
        break;
    case < 10000:
        switch (season)
        {
            case "Spring":
            case "Autumn":
                salary = ((kilometers * 0.95) * 4) - (((kilometers * 0.95) * 4) * 0.1);
                break;
            case "Summer":
                salary = ((kilometers * 1.1) * 4) - (((kilometers * 1.1) * 4) * 0.1);
                break;
            case "Winter":
                salary = ((kilometers * 1.25) * 4) - (((kilometers * 1.25) * 4) * 0.1);
                break;
        }
        break;
    case <= 20000:
        switch (season)
        {
            case "Spring":
            case "Autumn":
            case "Summer":
            case "Winter":
                salary = ((kilometers * 1.45) * 4) - (((kilometers * 1.45) * 4) * 0.1);
                break;
        }
        break;
}
Console.WriteLine($"{salary:f2}");
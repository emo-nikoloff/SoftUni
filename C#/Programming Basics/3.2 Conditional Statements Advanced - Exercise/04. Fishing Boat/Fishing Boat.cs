// Тони и приятели много обичали да ходят за риба, те са толкова запалени по риболова, че решават да отидат на риболов с кораб. Цената за наема на кораба зависи от сезона и броя рибари.
// Цената зависи от сезона:
// •	Цената за наем на кораба през пролетта е  3000 лв.
// •	Цената за наем на кораба през лятото и есента е  4200 лв.
// •	Цената за наем на кораба през зимата е  2600 лв.
// В зависимост от броя си групата ползва отстъпка:
// •	Ако групата е до 6 човека включително  –  отстъпка от 10%.
// •	Ако групата е от 7 до 11 човека включително  –  отстъпка от 15%.
// •	Ако групата е от 12 нагоре  –  отстъпка от 25%. 
// Рибарите ползват допълнително 5% отстъпка, ако са четен брой освен ако не е есен - тогава нямат допълнителна отстъпка,
// която се начислява след като се приспадне отстъпката по горните критерии.
// Напишете програма, която да пресмята дали рибарите ще съберат достатъчно пари. 
int budget = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
int fisherMans = int.Parse(Console.ReadLine());

double rent = 0;

switch (season)
{
    case "Spring":
        rent = 3000;

        if (fisherMans <= 6)
        {
            rent = rent - (rent * 0.1);

            if (fisherMans % 2 == 0)
                rent = rent - (rent * 0.05);
        }
        else if (fisherMans <= 11)
        {
            rent = rent - (rent * 0.15);

            if (fisherMans % 2 == 0)
                rent = rent - (rent * 0.05);
        }
        else
        {
            rent = rent - (rent * 0.25);

            if (fisherMans % 2 == 0)
                rent = rent - (rent * 0.05);
        }

        if (rent > budget)
        {
            double money = Math.Abs(budget - rent);
            Console.WriteLine($"Not enough money! You need {money:f2} leva.");
        }
        else
        {
            double money = Math.Abs(budget - rent);
            Console.WriteLine($"Yes! You have {money:f2} leva left.");
        }
        break;
    case "Summer":
        rent = 4200;

        if (fisherMans <= 6)
        {
            rent = rent - (rent * 0.1);

            if (fisherMans % 2 == 0)
                rent = rent - (rent * 0.05);
        }
        else if (fisherMans <= 11)
        {
            rent = rent - (rent * 0.15);

            if (fisherMans % 2 == 0)
                rent = rent - (rent * 0.05);
        }
        else
        {
            rent = rent - (rent * 0.25);

            if (fisherMans % 2 == 0)
                rent = rent - (rent * 0.05);
        }

        if (rent > budget)
        {
            double money = Math.Abs(budget - rent);
            Console.WriteLine($"Not enough money! You need {money:f2} leva.");
        }
        else
        {
            double money = Math.Abs(budget - rent);
            Console.WriteLine($"Yes! You have {money:f2} leva left.");
        }
        break;
    case "Autumn":
        rent = 4200;

        if (fisherMans <= 6)
            rent = rent - (rent * 0.1);
        else if (fisherMans <= 11)
            rent = rent - (rent * 0.15);
        else
            rent = rent - (rent * 0.25);

        if (rent > budget)
        {
            double money = Math.Abs(budget - rent);
            Console.WriteLine($"Not enough money! You need {money:f2} leva.");
        }
        else
        {
            double money = Math.Abs(budget - rent);
            Console.WriteLine($"Yes! You have {money:f2} leva left.");
        }
        break;
    case "Winter":
        rent = 2600;

        if (fisherMans <= 6)
        {
            rent = rent - (rent * 0.1);

            if (fisherMans % 2 == 0)
                rent = rent - (rent * 0.05);
        }
        else if (fisherMans <= 11)
        {
            rent = rent - (rent * 0.15);

            if (fisherMans % 2 == 0)
                rent = rent - (rent * 0.05);
        }
        else
        {
            rent = rent - (rent * 0.25);

            if (fisherMans % 2 == 0)
                rent = rent - (rent * 0.05);
        }

        if (rent > budget)
        {
            double money = Math.Abs(budget - rent);
            Console.WriteLine($"Not enough money! You need {money:f2} leva.");
        }
        else
        {
            double money = Math.Abs(budget - rent);
            Console.WriteLine($"Yes! You have {money:f2} leva left.");
        }
        break;
}
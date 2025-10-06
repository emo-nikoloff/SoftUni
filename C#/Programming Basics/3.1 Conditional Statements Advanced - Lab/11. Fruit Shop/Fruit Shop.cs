// Магазин за плодове през работните дни работи на следните цени:
// плод   banana   apple   orange   grapefruit   kiwi   pineapple   grapes
// цена	  2.50     1.20    0.85     1.45         2.70   5.50        3.85
// Събота и неделя магазинът работи на по-високи цени:
// плод   banana   apple   orange   grapefruit   kiwi   pineapple   grapes
// цена   2.70     1.25    0.90     1.60         3.00   5.60        4.20
// Напишете програма, която чете от конзолата плод (banana / apple / orange / grapefruit / kiwi / pineapple / grapes),
// ден от седмицата (Monday / Tuesday / Wednesday / Thursday / Friday / Saturday / Sunday) и количество (реално число) , въведени от потребителя,
// и пресмята цената според цените от таблиците по-горе. Резултатът да се отпечата закръглен с 2 цифри след десетичната точка.
// При невалиден ден от седмицата или невалидно име на плод да се отпечата "error".
string fruit = Console.ReadLine();
string dayOfWeek = Console.ReadLine();
double amount = double.Parse(Console.ReadLine());


if (dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday")
{
    if (fruit == "banana")
    {
        double priceBanana = 2.5;
        double totalCosts = amount * priceBanana;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else if (fruit == "apple")
    {
        double priceApple = 1.2;
        double totalCosts = amount * priceApple;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else if (fruit == "orange")
    {
        double priceOrange = 0.85;
        double totalCosts = amount * priceOrange;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else if (fruit == "grapefruit")
    {
        double priceGrapefruit = 1.45;
        double totalCosts = amount * priceGrapefruit;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else if (fruit == "kiwi")
    {
        double priceKiwi = 2.7;
        double totalCosts = amount * priceKiwi;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else if (fruit == "pineapple")
    {
        double pricePineapple = 5.5;
        double totalCosts = amount * pricePineapple;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else if (fruit == "grapes")
    {
        double priceGrapes = 3.85;
        double totalCosts = amount * priceGrapes;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else
        Console.WriteLine("error");
}
else if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
{
    if (fruit == "banana")
    {
        double priceBanana = 2.7;
        double totalCosts = amount * priceBanana;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else if (fruit == "apple")
    {
        double priceApple = 1.25;
        double totalCosts = amount * priceApple;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else if (fruit == "orange")
    {
        double priceOrange = 0.9;
        double totalCosts = amount * priceOrange;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else if (fruit == "grapefruit")
    {
        double priceGrapefruit = 1.6;
        double totalCosts = amount * priceGrapefruit;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else if (fruit == "kiwi")
    {
        double priceKiwi = 3;
        double totalCosts = amount * priceKiwi;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else if (fruit == "pineapple")
    {
        double pricePineapple = 5.6;
        double totalCosts = amount * pricePineapple;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else if (fruit == "grapes")
    {
        double priceGrapes = 4.2;
        double totalCosts = amount * priceGrapes;
        Console.WriteLine($"{totalCosts:f2}");
    }
    else
        Console.WriteLine("error");
}
else
    Console.WriteLine("error");
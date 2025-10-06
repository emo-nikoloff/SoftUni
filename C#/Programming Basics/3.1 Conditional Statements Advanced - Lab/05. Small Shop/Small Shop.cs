// Предприемчив българин отваря квартални магазинчета в няколко града и продава на различни цени според града:
// град / продукт  coffee   water   beer   sweets   peanuts
// Sofia	       0.50	    0.80	1.20   1.45	    1.60
// Plovdiv	       0.40	    0.70	1.15   1.30	    1.50
// Varna	       0.45	    0.70	1.10   1.35	    1.55
// Напишете програма, която чете продукт (низ), град (низ) и количество (десетично число), въведени от потребителя,
// и пресмята и отпечатва колко струва съответното количество от избрания продукт в посочения град. 
string product = Console.ReadLine();
string city = Console.ReadLine();
double amount = double.Parse(Console.ReadLine());

double price = 0;
if (city == "Sofia")
{
    if (product == "coffee")
    {
        price = 0.5;
    }
    else if (product == "water")
    {
        price = 0.8;
    }
    else if (product == "beer")
    {
        price = 1.2;
    }
    else if (product == "sweets")
    {
        price = 1.45;
    }
    else if (product == "peanuts")
    {
        price = 1.6;
    }
}
if (city == "Plovdiv")
{
    if (product == "coffee")
    {
        price = 0.4;
    }
    else if (product == "water")
    {
        price = 0.7;
    }
    else if (product == "beer")
    {
        price = 1.15;
    }
    else if (product == "sweets")
    {
        price = 1.3;
    }
    else if (product == "peanuts")
    {
        price = 1.5;
    }
}
if (city == "Varna")
{
    if (product == "coffee")
    {
        price = 0.45;
    }
    else if (product == "water")
    {
        price = 0.7;
    }
    else if (product == "beer")
    {
        price = 1.1;
    }
    else if (product == "sweets")
    {
        price = 1.35;
    }
    else if (product == "peanuts")
    {
        price = 1.55;
    }
}

double totalCosts = amount * price;
Console.WriteLine(totalCosts);
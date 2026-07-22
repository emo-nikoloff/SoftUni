// Времето се затопля и туристите започват да си правят разходки високо в планината, където все още има сняг, като за целта те трябва да закупят нужната туристическа екипировка.
// Вашата задача е да напишете програма, която да изчислява, стойността на екипировката, както и дали определения бюджет е достатъчен или не,
// като се знае, че в магазина има следната промоция: Всеки трети продукт е на половин цена.
double budget = double.Parse(Console.ReadLine());

double sum = 0;
int boughtItems = 0;
while (true)
{
    string item = Console.ReadLine();
    if (item == "Stop")
    {
        Console.WriteLine($"You bought {boughtItems} products for {sum:f2} leva.");
        break;
    }

    double itemPrice = double.Parse(Console.ReadLine());
    boughtItems++;
    if (boughtItems % 3 == 0)
        itemPrice /= 2;

    if (itemPrice > budget)
    {
        Console.WriteLine($"You don't have enough money!");
        Console.WriteLine($"You need {itemPrice - budget:f2} leva!");
        break;
    }

    budget -= itemPrice;
    sum += itemPrice;
}
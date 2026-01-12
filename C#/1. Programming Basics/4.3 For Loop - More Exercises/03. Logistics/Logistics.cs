// Отговаряте за логистиката на различни товари. В зависимост от теглото на товара е нужно различно превозно средство.
// Цената на тон, за която се превозва товара е различна за всяко превозно средство:
// •	До 3 тона – микробус (200 лева на тон)
// •	От 4 до 11 тона – камион (175 лева на тон)
// •	12 и повече тона – влак (120 лева на тон)
// Вашата задача е да изчислите средната цена на тон превозен товар, както и процента на тоновете  превозвани с всяко превозно средство, спрямо общото тегло(в тонове) на всички товари.
int cargo = int.Parse(Console.ReadLine());

int allCargo = 0;
int allCargoPrice = 0;
double averageCargo = 0;
double vanCargo = 0;
double truckCargo = 0;
double trainCargo = 0;
for (int i = 1; i <= cargo; i++)
{
    int tonneCargo = int.Parse(Console.ReadLine());

    allCargo += tonneCargo;
    if (tonneCargo >= 12)
    {
        trainCargo += tonneCargo;
        tonneCargo *= 120;
    }
    else if (tonneCargo >= 4)
    {
        truckCargo += tonneCargo;
        tonneCargo *= 175;
    }
    else
    {
        vanCargo += tonneCargo;
        tonneCargo *= 200;
    }
    allCargoPrice += tonneCargo;
    averageCargo = allCargoPrice / (double)allCargo;
}

trainCargo = trainCargo / allCargo * 100;
truckCargo = truckCargo / allCargo * 100;
vanCargo = vanCargo / allCargo * 100;
Console.WriteLine($"{averageCargo:f2}");
Console.WriteLine($"{vanCargo:f2}%");
Console.WriteLine($"{truckCargo:f2}%");
Console.WriteLine($"{trainCargo:f2}%");
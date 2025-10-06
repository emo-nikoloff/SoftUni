// Напишете програма, която да изчислява, колко ще струва на един шофьор да напълни резервоара на автомобила си,
// като знаете – какъв тип гориво зарежда, каква е цената за литър гориво и дали разполага с карта за отстъпки. Цените на горивата са както следва: 
// •	Бензин – 2.22 лева за един литър,
// •	Дизел – 2.33 лева за един литър
// •	Газ – 0.93 лева за литър
// Ако водача има карта за отстъпки, той се възползва от следните намаления за литър гориво: 18 ст.за литър бензин, 12 ст. за литър дизел и 8 ст. за литър газ. 
// Ако шофьора е заредил между 20 и 25 литра включително, той получава 8 процента отстъпка от крайната цена,
// при повече от 25 литра гориво, той получава 10 процента отстъпка от крайната цена.
string fuel = Console.ReadLine();
double fuelLitres = double.Parse(Console.ReadLine());
string clubCard = Console.ReadLine();

double gasolinePrice = 2.22;
double dieselPrice = 2.33;
double gasPrice = 0.93;

double fuelPrice = 0;
if (fuel == "Gasoline")
{
    if (clubCard == "Yes")
    {
        fuelPrice = fuelLitres * (gasolinePrice - 0.18);

        if (fuelLitres >= 20 && fuelLitres <= 25)
            fuelPrice = fuelPrice - (fuelPrice * 0.08);
        else if (fuelLitres > 25)
            fuelPrice = fuelPrice - (fuelPrice * 0.1);
        else
            fuelPrice = fuelPrice;
    }
    else if (clubCard == "No")
    {
        fuelPrice = fuelLitres * gasolinePrice;

        if (fuelLitres >= 20 && fuelLitres <= 25)
            fuelPrice = fuelPrice - (fuelPrice * 0.08);
        else if (fuelLitres > 25)
            fuelPrice = fuelPrice - (fuelPrice * 0.1);
        else
            fuelPrice = fuelPrice;
    }
}
else if (fuel == "Diesel")
{
    if (clubCard == "Yes")
    {
        fuelPrice = fuelLitres * (dieselPrice - 0.12);

        if (fuelLitres >= 20 && fuelLitres <= 25)
            fuelPrice = fuelPrice - (fuelPrice * 0.08);
        else if (fuelLitres > 25)
            fuelPrice = fuelPrice - (fuelPrice * 0.1);
        else
            fuelPrice = fuelPrice;
    }
    else if (clubCard == "No")
    {
        fuelPrice = fuelLitres * dieselPrice;

        if (fuelLitres >= 20 && fuelLitres <= 25)
            fuelPrice = fuelPrice - (fuelPrice * 0.08);
        else if (fuelLitres > 25)
            fuelPrice = fuelPrice - (fuelPrice * 0.1);
        else
            fuelPrice = fuelPrice;
    }
}
if (fuel == "Gas")
{
    if (clubCard == "Yes")
    {
        fuelPrice = fuelLitres * (gasPrice - 0.08);

        if (fuelLitres >= 20 && fuelLitres <= 25)
            fuelPrice = fuelPrice - (fuelPrice * 0.08);
        else if (fuelLitres > 25)
            fuelPrice = fuelPrice - (fuelPrice * 0.1);
        else
            fuelPrice = fuelPrice;
    }
    else if (clubCard == "No")
    {
        fuelPrice = fuelLitres * gasPrice;

        if (fuelLitres >= 20 && fuelLitres <= 25)
            fuelPrice = fuelPrice - (fuelPrice * 0.08);
        else if (fuelLitres > 25)
            fuelPrice = fuelPrice - (fuelPrice * 0.1);
        else
            fuelPrice = fuelPrice;
    }
}
Console.WriteLine($"{fuelPrice:f2} lv.");
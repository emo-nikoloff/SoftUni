// Фирма-производител на алуминиева дограма приема поръчки за изработката и монтаж със следния ценоразпис за един брой. Фирмата приема само поръчки на едро (над 10 бр.).
// В зависимост от поръчания брой дограми, фирмата прави различна отстъпка на своите клиенти.
// Фирмата предлага също и доставка на поръчките си срещу 60 лв.
// Размер	  Единична цена	    Отстъпка от цената
// 90X130	  110 лв.	        Над 30 броя – 5%
//                              Над 60 броя – 8%
// 100X150	  140 лв.	        Над 40 броя – 6%
//                              Над 80 броя – 10%
// 130X180	  190 лв.	        Над 20 броя – 7% 
//                              Над 50 броя – 12%
// 200X300	  250 лв.	        Над 25 броя – 9%
//                              Над 50 броя – 14%
// Ако поръчката надвишава 99 броя  – върху крайната цена се начисляват допълнителни 4% отстъпка (след като се начисли цената за доставка, ако има такава).
// При поръчка под 10 бр. на конзолата да бъде изписано "Invalid order"
int windowFrames = int.Parse(Console.ReadLine());
string size = Console.ReadLine();
string deliveryType = Console.ReadLine();

double windowFramePrice = 0;
if (size == "90X130")
{
    windowFramePrice = windowFrames * 110;

    if (windowFrames > 60)
        windowFramePrice = windowFramePrice - (windowFramePrice * 0.08);
    else if (windowFrames > 30)
        windowFramePrice = windowFramePrice - (windowFramePrice * 0.05);
}
else if (size == "100X150")
{
    windowFramePrice = windowFrames * 140;

    if (windowFrames > 80)
        windowFramePrice = windowFramePrice - (windowFramePrice * 0.1);
    else if (windowFrames > 40)
        windowFramePrice = windowFramePrice - (windowFramePrice * 0.06);
}
else if (size == "130X180")
{
    windowFramePrice = windowFrames * 190;

    if (windowFrames > 50)
        windowFramePrice = windowFramePrice - (windowFramePrice * 0.12);
    else if (windowFrames > 20)
        windowFramePrice = windowFramePrice - (windowFramePrice * 0.07);
}
else if (size == "200X300")
{
    windowFramePrice = windowFrames * 250;

    if (windowFrames > 50)
        windowFramePrice = windowFramePrice - (windowFramePrice * 0.14);
    else if (windowFrames > 25)
        windowFramePrice = windowFramePrice - (windowFramePrice * 0.09);
}

if (deliveryType == "With delivery")
    windowFramePrice += 60;
if (windowFrames > 99)
    windowFramePrice = windowFramePrice - (windowFramePrice * 0.04);

if (windowFrames < 10)
    Console.WriteLine("Invalid order");
else
    Console.WriteLine($"{windowFramePrice:f2} BGN");
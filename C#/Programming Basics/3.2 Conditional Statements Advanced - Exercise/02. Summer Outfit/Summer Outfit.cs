// Лято е с много променливо време и Виктор има нужда от вашата помощ. Напишете програма която спрямо времето от денонощието и градусите да препоръча на Виктор какви дрехи да си облече.
// Вашия приятел има различни планове за всеки етап от деня, които изискват и различен външен вид, тях може да видите от таблицата.
// Време от денонощието / градуси   Morning               Afternoon            Evening
// 10 <= градуси <= 18              Outfit = Sweatshirt   Outfit = Shirt       Outfit = Shirt
//                                  Shoes = Sneakers      Shoes = Moccasins    Shoes = Moccasins
//-----------------------------------------------------------------------------------------------
// 18 < градуси <= 24	            Outfit = Shirt        Outfit = T-Shirt     Outfit = Shirt
//                                  Shoes = Moccasins     Shoes = Sandals      Shoes = Moccasins
//-----------------------------------------------------------------------------------------------
// градуси >= 25	                Outfit = T-Shirt      Outfit = Swim Suit   Outfit = Shirt
//                                  Shoes = Sandals       Shoes = Barefoot     Shoes = Moccasins
int temperature = int.Parse(Console.ReadLine());
string time = Console.ReadLine();

string outfit = "";
string shoes = "";
switch (time)
{
    case "Morning":
        if (temperature <= 18)
        {
            outfit = "Sweatshirt";
            shoes = "Sneakers";
        }
        else if (temperature <= 24)
        {
            outfit = "Shirt";
            shoes = "Moccasins";
        }
        else
        {
            outfit = "T-Shirt";
            shoes = "Sandals";
        }
        break;
    case "Afternoon":
        if (temperature <= 18)
        {
            outfit = "Shirt";
            shoes = "Moccasins";
        }
        else if (temperature <= 24)
        {
            outfit = "T-Shirt";
            shoes = "Sandals";
        }
        else
        {
            outfit = "Swim Suit";
            shoes = "Barefoot";
        }
        break;
    case "Evening":
        if (temperature <= 18)
        {
            outfit = "Shirt";
            shoes = "Moccasins";
        }
        else if (temperature <= 24)
        {
            outfit = "Shirt";
            shoes = "Moccasins";
        }
        else
        {
            outfit = "Shirt";
            shoes = "Moccasins";
        }
        break;
}
Console.WriteLine($"It's {temperature} degrees, get your {outfit} and {shoes}.");
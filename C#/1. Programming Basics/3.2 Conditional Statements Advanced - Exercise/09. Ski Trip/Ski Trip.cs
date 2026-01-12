// Атанас решава да прекара отпуската си в Банско и да кара ски. Преди да отиде обаче, трябва да резервира хотел и да изчисли колко ще му струва престоя.
// Налични са следните видове помещения, със следните цени за престой:
// 	"room for one person" – 18.00 лв за нощувка
// 	"apartment" – 25.00 лв за нощувка 
// 	"president apartment" – 35.00 лв за нощувка
// Според броят на дните, в които ще остане в хотела (пример: 11 дни = 10 нощувки) и видът на помещението, което ще избере, той може да ползва различно намаление. 
// Намаленията са както следва:
// вид помещение          по-малко от 10 дни        между 10 и 15 дни       повече от 15 дни
// room for one person    не ползва намаление       не ползва намаление     не ползва намаление
// apartment              30% от крайната цена      35% от крайната цена    50% от крайната цена
// president apartment    10% от крайната цена      15% от крайната цена    20% от крайната цена
// След престоя, оценката на Атанас за услугите на хотела може да е позитивна (positive) или негативна (negative).
// Ако оценката му е позитивна, към цената с вече приспаднатото намаление Атанас добавя 25% от нея. Ако оценката му е негативна приспада от цената 10%.
int stay = int.Parse(Console.ReadLine());
string room = Console.ReadLine();
string mark = Console.ReadLine();

int nights = stay - 1;
double roomForOnePerson = 18;
double apartment = 25;
double presidentApartment = 35;

if (stay > 15)
{
    if (room == "room for one person")
    {
        roomForOnePerson = nights * roomForOnePerson;

        if (mark == "positive")
            roomForOnePerson = roomForOnePerson + roomForOnePerson * 0.25;
        else if (mark == "negative")
            roomForOnePerson = roomForOnePerson - roomForOnePerson * 0.1;
        Console.WriteLine($"{roomForOnePerson:f2}");
    }
    else if (room == "apartment")
    {
        apartment = nights * apartment - (nights * apartment * 0.5);

        if (mark == "positive")
            apartment = apartment + apartment * 0.25;
        else if (mark == "negative")
            apartment = apartment - apartment * 0.1;
        Console.WriteLine($"{apartment:f2}");
    }
    else if (room == "president apartment")
    {
        presidentApartment = nights * presidentApartment - (nights * presidentApartment * 0.2);

        if (mark == "positive")
            presidentApartment = presidentApartment + presidentApartment * 0.25;
        else if (mark == "negative")
            presidentApartment = presidentApartment - presidentApartment * 0.1;
        Console.WriteLine($"{presidentApartment:f2}");
    }
}
else if (stay > 10)
{
    if (room == "room for one person")
    {
        roomForOnePerson = nights * roomForOnePerson;

        if (mark == "positive")
            roomForOnePerson = roomForOnePerson + roomForOnePerson * 0.25;
        else if (mark == "negative")
            roomForOnePerson = roomForOnePerson - roomForOnePerson * 0.1;
        Console.WriteLine($"{roomForOnePerson:f2}");
    }
    else if (room == "apartment")
    {
        apartment = nights * apartment - (nights * apartment * 0.35);

        if (mark == "positive")
            apartment = apartment + apartment * 0.25;
        else if (mark == "negative")
            apartment = apartment - apartment * 0.1;
        Console.WriteLine($"{apartment:f2}");
    }
    else if (room == "president apartment")
    {
        presidentApartment = nights * presidentApartment - (nights * presidentApartment * 0.15);

        if (mark == "positive")
            presidentApartment = presidentApartment + presidentApartment * 0.25;
        else if (mark == "negative")
            presidentApartment = presidentApartment - presidentApartment * 0.1;
        Console.WriteLine($"{presidentApartment:f2}");
    }
}
else
{
    if (room == "room for one person")
    {
        roomForOnePerson = nights * roomForOnePerson;

        if (mark == "positive")
            roomForOnePerson = roomForOnePerson + roomForOnePerson * 0.25;
        else if (mark == "negative")
            roomForOnePerson = roomForOnePerson - roomForOnePerson * 0.1;
        Console.WriteLine($"{roomForOnePerson:f2}");
    }
    else if (room == "apartment")
    {
        apartment = nights * apartment - (nights * apartment * 0.3);

        if (mark == "positive")
            apartment = apartment + apartment * 0.25;
        else if (mark == "negative")
            apartment = apartment - apartment * 0.1;
        Console.WriteLine($"{apartment:f2}");
    }
    else if (room == "president apartment")
    {
        presidentApartment = nights * presidentApartment - (nights * presidentApartment * 0.1);

        if (mark == "positive")
            presidentApartment = presidentApartment + presidentApartment * 0.25;
        else if (mark == "negative")
            presidentApartment = presidentApartment - presidentApartment * 0.1;
        Console.WriteLine($"{presidentApartment:f2}");
    }
}
// Снимките за дългоочаквания филм "Годзила срещу Конг" започват.
// Сценаристът Адам Уингард ви моли да напишете програма, която да изчисли, дали предвидените средства са достатъчни за снимането на филма.
// За снимките  ще бъдат нужни определен брой статисти, облекло за всеки един статист и декор.
// Известно е, че:
// •	Декорът за филма е на стойност 10% от бюджета. 
// •	При повече от 150 статиста, има отстъпка за облеклото на стойност 10%.
double budget = double.Parse(Console.ReadLine());
int staticians = int.Parse(Console.ReadLine());
double clothingPrice = double.Parse(Console.ReadLine());

double decor = budget * 0.1;
double clothing = staticians * clothingPrice;
if (staticians > 150)
    clothing = clothing - (clothing * 0.1);
double moviePrice = decor + clothing;

if (moviePrice > budget)
{
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {Math.Abs(budget - moviePrice):f2} leva more.");
}
else
{
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {budget - moviePrice:f2} leva left.");
}
// Снимките за дългоочаквания филм "Годзила срещу Конг" започват.
// Сценаристът Адам Уингард ви моли да напишете програма, която да изчисли, дали предвидените средства са достатъчни за снимането на филма.
// За снимките  ще бъдат нужни определен брой статисти, облекло за всеки един статист и декор.
// Известно е, че:
// •	Декорът за филма е на стойност 10% от бюджета. 
// •	При повече от 150 статиста, има отстъпка за облеклото на стойност 10%.
double budget = double.Parse(Console.ReadLine());
int statistician = int.Parse(Console.ReadLine());
double clothing = double.Parse(Console.ReadLine());

double decorSum = 0.1 * budget;
double clothingSum = statistician * clothing;
double filmSum = decorSum + clothingSum;
double money = Math.Abs(budget - filmSum);

if (statistician > 150)
{
    filmSum = decorSum + (clothingSum - (clothingSum * 0.1));
    money = Math.Abs(budget - filmSum);
}

if (budget < filmSum)
{
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {money:f2} leva more.");
}
else
{
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {money:f2} leva left.");
}
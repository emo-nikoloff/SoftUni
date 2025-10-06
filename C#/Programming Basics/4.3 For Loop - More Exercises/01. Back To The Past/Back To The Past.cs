// Иванчо е на 18 години и получава наследство, което се състои от X сума пари и машина на времето.
// Той решава да се върне до 1800 година, но не знае дали парите ще са достатъчни, за да живее без да работи.
// Напишете програма, която пресмята, дали Иванчо ще има достатъчно пари, за да не се налага да работи до дадена година включително.
// Като приемем, че за всяка четна (1800, 1802 и т.н.) година ще харчи 12 000 лева.
// За всяка нечетна (1801,1803  и т.н.) ще харчи 12 000 + 50 * [годините, които е навършил през дадената година].
double inheritedMoney = double.Parse(Console.ReadLine());
int yearsToLive = int.Parse(Console.ReadLine());

int age = 18;
for (int i = 1800; i <= yearsToLive; i++)
{
    if (i % 2 == 0)
        inheritedMoney -= 12000;
    else
        inheritedMoney = inheritedMoney - (12000 + (50 * age));
    age++;
}

if (inheritedMoney >= 0)
    Console.WriteLine($"Yes! He will live a carefree life and will have {inheritedMoney:f2} dollars left.");
else
    Console.WriteLine($"He will need {Math.Abs(inheritedMoney):f2} dollars to survive.");
// Джеси решава, че иска да се занимава с баскетбол, но за да тренира е нужна екипировка.
// Напишете програма, която изчислява какви разходи ще има Джеси, ако започне да тренира, като знаете колко е таксата за тренировки по баскетбол за период от 1 година. Нужна екипировка: 
// •	Баскетболни кецове – цената им е 40% по-малка от таксата за една година
// •	Баскетболен екип – цената му е 20% по-евтина от тази на кецовете
// •	Баскетболна топка – цената ѝ е 1 / 4 от цената на баскетболния екип
// •	Баскетболни аксесоари – цената им е 1 / 5 от цената на баскетболната топка
int yearlyTax = int.Parse(Console.ReadLine());

double sneakersPrice = yearlyTax - (yearlyTax * 0.4);
double outfitPrice = sneakersPrice - (sneakersPrice * 0.2);
double ballPrice = outfitPrice * 0.25;
double accessoriesPrice = ballPrice * 0.2;

double sum = yearlyTax + sneakersPrice + outfitPrice + ballPrice + accessoriesPrice;
Console.WriteLine(sum);
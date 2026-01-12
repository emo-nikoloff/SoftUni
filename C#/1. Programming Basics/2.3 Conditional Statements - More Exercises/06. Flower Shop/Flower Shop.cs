// Мария иска да купи подарък на сина си. Тя работи в магазин за цветя. В магазина идва поръчка за цветя.
// Напишете програма, която пресмята сумата от поръчката и дали печалбата е достатъчна за подаръка. Цветята имат следните цени:
// •	Магнолии – 3.25 лева
// •	Зюмбюли – 4 лева
// •	Рози – 3.50 лева
// •	Кактуси – 8 лева
// От общата сума, Мария трябва да плати 5% данъци.
int magnolias = int.Parse(Console.ReadLine());
int hyacinths = int.Parse(Console.ReadLine());
int roses = int.Parse(Console.ReadLine());
int cactuses = int.Parse(Console.ReadLine());
double giftPrice = double.Parse(Console.ReadLine());

double profit = (magnolias * 3.25) + (hyacinths * 4) + (roses * 3.5) + (cactuses * 8);
profit = profit - (profit * 0.05);

if (profit < giftPrice)
    Console.WriteLine($"She will have to borrow {Math.Ceiling(Math.Abs(profit - giftPrice))} leva.");
else
    Console.WriteLine($"She is left with {Math.Floor(profit - giftPrice)} leva.");
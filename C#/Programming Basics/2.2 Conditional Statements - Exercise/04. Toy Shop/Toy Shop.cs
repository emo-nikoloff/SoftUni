// Петя има магазин за детски играчки. Тя получава голяма поръчка, която трябва да изпълни. С парите, които ще спечели иска да отиде на екскурзия. 
// Цени на играчките:
// •	Пъзел - 2.60 лв.
// •	Говореща кукла - 3 лв.
// •	Плюшено мече - 4.10 лв.
// •	Миньон - 8.20 лв.
// •	Камионче - 2 лв.
// Ако поръчаните играчки са 50 или повече магазинът прави отстъпка 25% от общата цена. От спечелените пари Петя трябва да даде 10% за наема на магазина.
// Да се пресметне дали парите ще ѝ стигнат да отиде на екскурзия.
double vacationPrice = double.Parse(Console.ReadLine());
int puzzle = int.Parse(Console.ReadLine());
int talkingDoll = int.Parse(Console.ReadLine());
int TeddyBear = int.Parse(Console.ReadLine());
int minion = int.Parse(Console.ReadLine());
int truck = int.Parse(Console.ReadLine());

double puzzlePrice = 2.6;
double talkinDollPrice = 3;
double TeddyBearPrice = 4.1;
double minionPrice = 8.2;
double truckPrice = 2;
double rent = 0.1;

double totalSum = puzzle * puzzlePrice + talkingDoll * talkinDollPrice + TeddyBear * TeddyBearPrice + minion * minionPrice + truck * truckPrice;

double discountSum = 0;
double rentPrice = 0;
double sum = 0;
if ((puzzle + talkingDoll + TeddyBear + minion + truck) >= 50)
{
    double discount = totalSum * 0.25;
    discountSum = totalSum - discount;
    rentPrice = discountSum * rent;
    sum = discountSum - rentPrice;
}
else
{
    rentPrice = totalSum * rent;
    sum = totalSum - rentPrice;
}

double money = Math.Abs(sum - vacationPrice);
if (sum >= vacationPrice)
    Console.WriteLine($"Yes! {money:f2} lv left.");
else
    Console.WriteLine($"Not enough money! {money:f2} lv needed.");
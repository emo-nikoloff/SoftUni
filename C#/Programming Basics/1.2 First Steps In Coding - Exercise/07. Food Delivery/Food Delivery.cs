// Ресторант отваря врати и предлага няколко менюта на преференциални цени: 
// •	Пилешко меню –  10.35 лв. 
// •	Меню с риба – 12.40 лв. 
// •	Вегетарианско меню  – 8.15 лв. 
// Напишете програма, която изчислява колко ще струва на група хора да си поръчат храна за вкъщи.
// Групата ще си поръча и десерт, чиято цена е равна на 20% от общата сметка (без доставката). Цената на доставка е 2.50 лв и се начислява най-накрая.
double chickenMenu = 10.35;
double fishMenu = 12.40;
double vegeterianMenu = 8.15;

int chickenMenuCount = int.Parse(Console.ReadLine());
int fishMenuCount = int.Parse(Console.ReadLine());
int vegeterianMenuCount = int.Parse(Console.ReadLine());

double chickenMenusPrice = chickenMenuCount * chickenMenu;
double fishMenusPrice = fishMenuCount * fishMenu;
double vegeterianMenusPrice = vegeterianMenuCount * vegeterianMenu;
double totalMenusPrice = chickenMenusPrice + fishMenusPrice + vegeterianMenusPrice;
double dessertPrice = totalMenusPrice * 0.2;

double totalOrderPrice = totalMenusPrice + dessertPrice + 2.50;
Console.WriteLine(totalOrderPrice);
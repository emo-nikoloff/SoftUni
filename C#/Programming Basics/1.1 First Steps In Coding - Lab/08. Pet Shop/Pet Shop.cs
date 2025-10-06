// Напишете програма, която пресмята нужните разходи за закупуването на храна за кучета и котки. Храната се пазарува от зоомагазин,
// като една опаковка храна за кучета е на цена 2.50 лв, а опаковка храна за котки струва 4 лв.
int dogFoodPackaging = int.Parse(Console.ReadLine());
int catFoodPackaging = int.Parse(Console.ReadLine());

double finalDogPrice = dogFoodPackaging * 2.50;
int finalCatPrice = catFoodPackaging * 4;

double sum = finalDogPrice + finalCatPrice;
Console.WriteLine($"{sum} lv.");
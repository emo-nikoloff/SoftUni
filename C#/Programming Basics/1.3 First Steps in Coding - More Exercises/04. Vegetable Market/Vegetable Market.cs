// Градинар продавал реколтата от градината си на зеленчуковата борса. Продава зеленчуци за N лева на килограм и плодове за M лева за килограм.
// Напишете програма, която да пресмята приходите от реколтата в евро ( ако приемем, че едно евро е равно на 1.94лв).
double vegetables = double.Parse(Console.ReadLine());
double fruits = double.Parse(Console.ReadLine());
double vegetablesKGs = double.Parse(Console.ReadLine());
double fruitsKGs = double.Parse(Console.ReadLine());

double vegetablesPrice = vegetables * vegetablesKGs;
double fruitsPrice = fruits * fruitsKGs;

double sum = vegetablesPrice + fruitsPrice;
double sumInEuro = sum / 1.94;
Console.WriteLine($"{sumInEuro:f2}");
// Марин и Нели си купуват къща не далеч от София.
// Нели толкова много обича цветята, че Ви убеждава да напишете програма която да изчисли колко  ще им струва,
// да си засадят определен брой цветя и дали наличния бюджет ще им е достатъчен. Различните цветя са с различни цени. 
// цвете                  Роза   Далия   Лале   Нарцис   Гладиола
// Цена на брой в лева	  5      3.80    2.80   3        2.50
// Съществуват следните отстъпки:
// •	Ако Нели купи повече от 80 Рози - 10% отстъпка от крайната цена
// •	Ако Нели купи повече от 90  Далии - 15% отстъпка от крайната цена
// •	Ако Нели купи повече от 80 Лалета - 15% отстъпка от крайната цена
// •	Ако Нели купи по-малко от 120 Нарциса - цената се оскъпява с 15%
// •	Ако Нели Купи по-малко от 80 Гладиоли - цената се оскъпява с 20%
string flower = Console.ReadLine();
int flowers = int.Parse(Console.ReadLine());
int budget = int.Parse(Console.ReadLine());

int rosesPrice = 5;
double dahliasPrice = 3.8;
double tulipsPrice = 2.8;
int narcissusPrice = 3;
double gladiolusPrice = 2.5;

double sum = 0;
switch (flower)
{
    case "Roses":
        if (flowers > 80)
        {
            sum = flowers * rosesPrice;
            sum = sum - (sum * 0.1);
        }
        else
        {
            sum = flowers * rosesPrice;
        }

        if (sum > budget)
        {
            double money = Math.Abs(budget - sum);
            Console.WriteLine($"Not enough money, you need {money:f2} leva more.");
        }
        else
        {
            double money = Math.Abs(budget - sum);
            Console.WriteLine($"Hey, you have a great garden with {flowers} {flower} and {money:f2} leva left.");
        }
        break;
    case "Dahlias":
        if (flowers > 90)
        {
            sum = flowers * dahliasPrice;
            sum = sum - (sum * 0.15);
        }
        else
        {
            sum = flowers * dahliasPrice;
        }

        if (sum > budget)
        {
            double money = Math.Abs(budget - sum);
            Console.WriteLine($"Not enough money, you need {money:f2} leva more.");
        }
        else
        {
            double money = Math.Abs(budget - sum);
            Console.WriteLine($"Hey, you have a great garden with {flowers} {flower} and {money:f2} leva left.");
        }
        break;
    case "Tulips":
        if (flowers > 80)
        {
            sum = flowers * tulipsPrice;
            sum = sum - (sum * 0.15);
        }
        else
        {
            sum = flowers * tulipsPrice;
        }

        if (sum > budget)
        {
            double money = Math.Abs(budget - sum);
            Console.WriteLine($"Not enough money, you need {money:f2} leva more.");
        }
        else
        {
            double money = Math.Abs(budget - sum);
            Console.WriteLine($"Hey, you have a great garden with {flowers} {flower} and {money:f2} leva left.");
        }
        break;
    case "Narcissus":
        if (flowers < 120)
        {
            sum = flowers * narcissusPrice;
            sum = sum + (sum * 0.15);
        }
        else
        {
            sum = flowers * narcissusPrice;
        }

        if (sum > budget)
        {
            double money = Math.Abs(budget - sum);
            Console.WriteLine($"Not enough money, you need {money:f2} leva more.");
        }
        else
        {
            double money = Math.Abs(budget - sum);
            Console.WriteLine($"Hey, you have a great garden with {flowers} {flower} and {money:f2} leva left.");
        }
        break;
    case "Gladiolus":
        if (flowers < 80)
        {
            sum = flowers * gladiolusPrice;
            sum = sum + (sum * 0.2);
        }
        else
        {
            sum = flowers * gladiolusPrice;
        }

        if (sum > budget)
        {
            double money = Math.Abs(budget - sum);
            Console.WriteLine($"Not enough money, you need {money:f2} leva more.");
        }
        else
        {
            double money = Math.Abs(budget - sum);
            Console.WriteLine($"Hey, you have a great garden with {flowers} {flower} and {money:f2} leva left.");
        }
        break;
}
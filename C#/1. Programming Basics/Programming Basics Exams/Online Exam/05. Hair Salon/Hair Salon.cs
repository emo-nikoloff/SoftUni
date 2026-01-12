// Деси има фризьорски салон в София. Тя всеки ден си поставя за цел да постигне определена печалба.
// Напишете програма, която изчислява дали е успяла да постигне целта за деня, като знаете следното:
// Деси ще приема клиенти докато не приключи работния ден. Ако постигне желания приход обаче, тя ще затвори салона. Когато клиент влезе ще може да си избере една от следните услуги:
// • Подстригване(haircut):
//    o Мъжко(mens) -15лв.
//    o Дамско(ladies) – 20лв.
//    o Детско(kids) – 10лв.
// • Боядисване(color):
//    o Поддръжка(touch up) – 20лв.
//    o Пълно боядисване (full color) – 30лв.
int targetSum = int.Parse(Console.ReadLine());

string input = Console.ReadLine();
int sum = 0;
while (input != "closed")
{
    switch (input)
    {
        case "haircut":
            string age = Console.ReadLine();
            switch (age)
            {
                case "mens":
                    sum += 15;
                    break;
                case "ladies":
                    sum += 20;
                    break;
                case "kids":
                    sum += 10;
                    break;
            }
            break;
        case "color":
            string coloring = Console.ReadLine();
            switch (coloring)
            {
                case "touch up":
                    sum += 20;
                    break;
                case "full color":
                    sum += 30;
                    break;
            }
            break;
    }
    if (sum >= targetSum)
        break;
    input = Console.ReadLine();
}
if (sum >= targetSum)
    Console.WriteLine("You have reached your target for the day!");
else
    Console.WriteLine($"Target not reached! You need {targetSum - sum}lv. more.");
Console.WriteLine($"Earned money: {sum}lv.");
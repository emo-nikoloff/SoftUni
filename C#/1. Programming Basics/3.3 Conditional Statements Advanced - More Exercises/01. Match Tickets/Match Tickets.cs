// Когато пуснали билетите за Евро 2016, група запалянковци решили да си закупят. Билетите имат две категории с различни цени:
// •	VIP – 499.99 лева.
// •	Normal – 249.99 лева.
// Запалянковците имат определен бюджет, а броят на хората в групата определя какъв процент от бюджета трябва да се задели за транспорт
// •    От 1 до 4 – 75% от бюджета.
// •    От 5 до 9 – 60% от бюджета.
// •    От 10 до 24 – 50% от бюджета.
// •    От 25 до 49 – 40% от бюджета.
// •    50 или повече – 25% от бюджета.
// Напишете програма, която да пресмята дали с останалите пари от бюджета могат да си купят билети за избраната категория. И колко пари ще им останат или ще са им нужни.
double budget = double.Parse(Console.ReadLine());
string category = Console.ReadLine();
int people = int.Parse(Console.ReadLine());

double NormalTicket = 249.99;
double VIPTicket = 499.99;

if (people < 5)
{
    budget = budget - (budget * 0.75);
    NormalTicket *= people;
    VIPTicket *= people;

    if (category == "Normal")
    {
        if (budget < NormalTicket)
        {
            Console.WriteLine($"Not enough money! You need {Math.Abs(budget - NormalTicket):f2} leva.");
        }
        else
            Console.WriteLine($"Yes! You have {budget - NormalTicket:f2} leva left.");
    }
    else if (category == "VIP")
    {
        if (budget < VIPTicket)
        {
            Console.WriteLine($"Not enough money! You need {Math.Abs(budget - VIPTicket):f2} leva.");
        }
        else
            Console.WriteLine($"Yes! You have {budget - VIPTicket:f2} leva left.");
    }
}
else if (people < 10)
{
    budget = budget - (budget * 0.6);
    NormalTicket *= people;
    VIPTicket *= people;

    if (category == "Normal")
    {
        if (budget < NormalTicket)
        {
            Console.WriteLine($"Not enough money! You need {Math.Abs(budget - NormalTicket):f2} leva.");
        }
        else
            Console.WriteLine($"Yes! You have {budget - NormalTicket:f2} leva left.");
    }
    else if (category == "VIP")
    {
        if (budget < VIPTicket)
        {
            Console.WriteLine($"Not enough money! You need {Math.Abs(budget - VIPTicket):f2} leva.");
        }
        else
            Console.WriteLine($"Yes! You have {budget - VIPTicket:f2} leva left.");
    }
}
else if (people < 25)
{
    budget = budget - (budget * 0.5);
    NormalTicket *= people;
    VIPTicket *= people;

    if (category == "Normal")
    {
        if (budget < NormalTicket)
        {
            Console.WriteLine($"Not enough money! You need {Math.Abs(budget - NormalTicket):f2} leva.");
        }
        else
            Console.WriteLine($"Yes! You have {budget - NormalTicket:f2} leva left.");
    }
    else if (category == "VIP")
    {
        if (budget < VIPTicket)
        {
            Console.WriteLine($"Not enough money! You need {Math.Abs(budget - VIPTicket):f2} leva.");
        }
        else
            Console.WriteLine($"Yes! You have {budget - VIPTicket:f2} leva left.");
    }
}
else if (people < 50)
{
    budget = budget - (budget * 0.4);
    NormalTicket *= people;
    VIPTicket *= people;

    if (category == "Normal")
    {
        if (budget < NormalTicket)
        {
            Console.WriteLine($"Not enough money! You need {Math.Abs(budget - NormalTicket):f2} leva.");
        }
        else
            Console.WriteLine($"Yes! You have {budget - NormalTicket:f2} leva left.");
    }
    else if (category == "VIP")
    {
        if (budget < VIPTicket)
        {
            Console.WriteLine($"Not enough money! You need {Math.Abs(budget - VIPTicket):f2} leva.");
        }
        else
            Console.WriteLine($"Yes! You have {budget - VIPTicket:f2} leva left.");
    }
}
else
{
    budget = budget - (budget * 0.25);
    NormalTicket *= people;
    VIPTicket *= people;

    if (category == "Normal")
    {
        if (budget < NormalTicket)
        {
            Console.WriteLine($"Not enough money! You need {Math.Abs(budget - NormalTicket):f2} leva.");
        }
        else
            Console.WriteLine($"Yes! You have {budget - NormalTicket:f2} leva left.");
    }
    else if (category == "VIP")
    {
        if (budget < VIPTicket)
        {
            Console.WriteLine($"Not enough money! You need {Math.Abs(budget - VIPTicket):f2} leva.");
        }
        else
            Console.WriteLine($"Yes! You have {budget - VIPTicket:f2} leva left.");
    }
}
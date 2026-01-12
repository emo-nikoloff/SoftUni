// Джеси е решила да събира пари за екскурзия и иска от вас да ѝ помогнете да разбере дали ще успее да събере необходимата сума. Тя спестява или харчи част от парите си всеки ден.
// Ако иска да похарчи повече от наличните си пари, то тя ще похарчи колкото има и ще ѝ останат 0 лева.
double neededMoney = double.Parse(Console.ReadLine());
double money = double.Parse(Console.ReadLine());

int days = 0;
int daysSpendingMoney = 0;
bool isMoneySaved = true;
while (money < neededMoney && daysSpendingMoney < 5)
{
    string process = Console.ReadLine();
    double processedMoney = double.Parse(Console.ReadLine());

    days++;

    if (process == "spend")
    {
        money = money - processedMoney < 0 ? 0 : money - processedMoney;
        // Същото е като: 
        // if (money - processedMoney < 0)
        //     money = 0;
        // else
        //     money -= processedMoney;

        if (++daysSpendingMoney == 5)
        {
            isMoneySaved = false;
            break;
        }
    }
    else if (process == "save")
    {
        money += processedMoney;
        daysSpendingMoney = 0;
    }
}

if (isMoneySaved)
{
    Console.WriteLine($"You saved the money for {days} days.");
}
else
{
    Console.WriteLine("You can't save the money.");
    Console.WriteLine(days);
}
// Фирма дава следните комисионни на търговците си според града, в който работят и обема на продажбите:
// Град      0 ≤ s ≤ 500   500 < s ≤ 1 000   1 000 < s ≤ 10 000   s > 10 000
// Sofia	 5%            7%                8%                   12%
// Varna	 4.5%          7.5%              10%                  13%
// Plovdiv   5.5%          8%                12%                  14.5%
// Напишете конзолна програма, която чете име на град (стринг) и обем на продажби (реално число) , въведени от потребителя,
// и изчислява и извежда размера на търговската комисионна според горната таблица. Резултатът да се изведе форматиран до 2 цифри след десетичната точка.
// При невалиден град или обем на продажбите (отрицателно число) да се отпечата "error".
string city = Console.ReadLine();
double sales = double.Parse(Console.ReadLine());

double commissionPercentage = 0;
if (city == "Sofia")
{
    if (sales > 10000)
    {
        commissionPercentage = 0.12;
    }
    else if (sales > 1000)
    {
        commissionPercentage = 0.08;
    }
    else if (sales > 500)
    {
        commissionPercentage = 0.07;
    }
    else if (sales >= 0)
    {
        commissionPercentage = 0.05;
    }
}
else if (city == "Varna")
{
    if (sales > 10000)
    {
        commissionPercentage = 0.13;
    }
    else if (sales > 1000)
    {
        commissionPercentage = 0.1;
    }
    else if (sales > 500)
    {
        commissionPercentage = 0.075;
    }
    else if (sales >= 0)
    {
        commissionPercentage = 0.045;
    }
}
else if (city == "Plovdiv")
{
    if (sales > 10000)
    {
        commissionPercentage = 0.145;
    }
    else if (sales > 1000)
    {
        commissionPercentage = 0.12;
    }
    else if (sales > 500)
    {
        commissionPercentage = 0.08;
    }
    else if (sales >= 0)
    {
        commissionPercentage = 0.055;
    }
}

if (commissionPercentage == 0)
    Console.WriteLine("error");
else
{
    double profit = sales * commissionPercentage;
    Console.WriteLine($"{profit:f2}");
}
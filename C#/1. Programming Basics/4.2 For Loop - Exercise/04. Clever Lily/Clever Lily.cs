// Лили вече е на N години. За всеки свой рожден ден тя получава подарък. 
// •	За нечетните рождени дни (1, 3, 5...n) получава играчки.
// •	За четните рождени дни (2, 4, 6...n) получава пари. 
// За втория рожден ден получава 10.00 лв, като сумата се увеличава с 10.00 лв., за всеки следващ четен рожден ден (2 -> 10, 4 -> 20, 6 -> 30...и т.н.).
// През годините Лили тайно е спестявала парите. Братът на Лили, в годините, които тя получава пари, взима по 1.00 лев от тях.
// Лили продала играчките получени през годините, всяка за P лева и добавила сумата към спестените пари. С парите искала да си купи пералня за X лева.
// Напишете програма, която да пресмята, колко пари е събрала и дали ѝ стигат да си купи пералня.
int birthday = int.Parse(Console.ReadLine());
double washingMachinePrice = double.Parse(Console.ReadLine());
int toyPrice = int.Parse(Console.ReadLine());

int sum = 0;
int giftedMoney = 10;
for (int i = 1; i <= birthday; i++)
{
    if (i % 2 != 0)
        sum += toyPrice;
    else
    {
        sum += giftedMoney - 1;
        giftedMoney += 10;
    }
}

double diff = Math.Abs(sum - washingMachinePrice);
if (sum >= washingMachinePrice)
{
    Console.WriteLine($"Yes! {diff:f2}");
}
else
{
    Console.WriteLine($"No! {diff:f2}");
}
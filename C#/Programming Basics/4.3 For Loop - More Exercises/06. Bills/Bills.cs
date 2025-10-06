// Напишете програма която да пресмята средният разход за месец на семейство за даден период време. За всеки месец разходите са следните:
// •	За ток – всеки месец е различен, ще се чете от конзолата
// •	за вода – 20 лв.
// •	за интернет – 15 лв.
// •	за други – събират се тока, водата и интернета за месеца и към сумата се прибавят 20%.
// За всеки разход трябва да се пресметне колко общо е платено за всички месеци.
int months = int.Parse(Console.ReadLine());

double electricitySum = 0;
double waterSum = 20;
double internetSum = 15;
double othersSum = 0;
double average = 0;
for (int i = 0; i < months; i++)
{
    double electricity = double.Parse(Console.ReadLine());

    electricitySum += electricity;
    othersSum += (electricity + 20 + 15) + ((electricity + 20 + 15) * 0.2);
}

waterSum *= months;
internetSum *= months;
average = (electricitySum + waterSum + internetSum + othersSum) / months;
Console.WriteLine($"Electricity: {electricitySum:f2} lv");
Console.WriteLine($"Water: {waterSum:f2} lv");
Console.WriteLine($"Internet: {internetSum:f2} lv");
Console.WriteLine($"Other: {othersSum:f2} lv");
Console.WriteLine($"Average: {average:f2} lv");
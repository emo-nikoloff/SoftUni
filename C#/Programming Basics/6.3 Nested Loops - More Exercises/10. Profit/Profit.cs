// Имаме банкноти и монети по 1лв., по 2лв. и по 5лв.
// Да се напише програма, която прочита въведените от потребителя брой банкноти и монети и сума, и извежда на екран всички възможни начини по които сумата може да се изплати с наличните банкноти. 

int coinsOfOneLev = int.Parse(Console.ReadLine());
int coinsOfTwoLeva = int.Parse(Console.ReadLine());
int banknotesOfFiveLeva = int.Parse(Console.ReadLine());
int sum = int.Parse(Console.ReadLine());


for (int oneLevCount = 0; oneLevCount <= coinsOfOneLev; oneLevCount++)
{
    for (int twoLevaCount = 0; twoLevaCount <= coinsOfTwoLeva; twoLevaCount++)
    {
        for (int fiveLevaCount = 0; fiveLevaCount <= banknotesOfFiveLeva; fiveLevaCount++)
        {
            if ((oneLevCount * 1 + twoLevaCount * 2 + fiveLevaCount * 5) == sum)
                Console.WriteLine($"{oneLevCount} * 1 lv. + {twoLevaCount} * 2 lv. + {fiveLevaCount} * 5 lv. = {sum} lv.");
        }
    }
}
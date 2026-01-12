// Да се напише програма, която чете едно цяло число N, въведено от потребителя, и генерира всички възможни "специални" числа от 1111 до 9999.
// За да бъде "специалнo" едно число,то трябва да отговаря на следното условие: 
// •	N да се дели на всяка една от неговите цифри без остатък.
// Пример: при N = 16, 2418 е специално число:
// •	16 / 2 = 8 без остатък
// •	16 / 4 = 4 без остатък
// •	16 / 1 = 16 без остатък
// •	16 / 8 = 2 без остатък
int num = int.Parse(Console.ReadLine());

for (int num1 = 1; num1 <= 9; num1++)
{
    for (int num2 = 1; num2 <= 9; num2++)
    {
        for (int num3 = 1; num3 <= 9; num3++)
        {
            for (int num4 = 1; num4 <= 9; num4++)
            {
                if (num % num1 == 0 && num % num2 == 0 && num % num3 == 0 && num % num4 == 0)
                    Console.Write($"{num1}{num2}{num3}{num4} ");
            }
        }
    }
}

/*for (int i = 1111; i <= 9999; i++)
{
    int number = i;
    bool isSpecial = true;

    while (number != 0)
    {
        int lastDigit = number % 10;

        if (lastDigit == 0 || num % lastDigit != 0)
        {
            isSpecial = false;
            break;
        }

        number /= 10;
    }

    if (isSpecial)
    {
        Console.Write($"{i} ");
    }
}*/
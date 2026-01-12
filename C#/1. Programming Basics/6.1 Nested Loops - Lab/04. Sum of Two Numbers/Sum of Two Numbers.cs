// Напишете програма която проверява всички възможни комбинации от двойка числа в интервала от две дадени числа.
// На изхода се отпечатва, коя поред е комбинацията чиито сбор от числата е равен на дадено магическо число.
// Ако няма нито една комбинация отговаряща на условието се отпечатва съобщение, че не е намерено.
int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());
int number = int.Parse(Console.ReadLine());

int combinations = 0;
bool isFound = false;
for (int i = start; i <= end; i++)
{
    for (int j = start; j <= end; j++)
    {
        combinations++;

        if (i + j == number)
        {
            Console.WriteLine($"Combination N:{combinations} ({i} + {j} = {number})");
            isFound = true;
            break;
        }
    }
    if (isFound)
        break;
}
if (!isFound)
    Console.WriteLine($"{combinations} combinations - neither equals {number}");
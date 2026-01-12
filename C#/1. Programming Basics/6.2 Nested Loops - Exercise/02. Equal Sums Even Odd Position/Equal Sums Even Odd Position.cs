// Напишете програма, която чете от конзолата две шестцифрени цели числа в диапазона от 100000 до 300000. Винаги първото въведено число ще бъде по малко от второто.
// На конзолата да се отпечатат на 1 ред разделени с интервал всички числа, които се намират между двете, прочетени от конзолата числа и отговарят на следното условие:
// •	сумата от цифрите на четни и нечетни позиции да са равни. Ако няма числа, отговарящи на условието на конзолата не се извежда резултат. 
int firstNumber = int.Parse(Console.ReadLine());
int secondNumber = int.Parse(Console.ReadLine());

for (int i = firstNumber; i <= secondNumber; i++)
{
    int oddSum = 0;
    int evenSum = 0;
    int number = i;
    int position = 0;

    while (number != 0)
    {
        int lastDigit = number % 10;

        if (position % 2 == 0)
            evenSum += lastDigit;
        else
            oddSum += lastDigit;
        position++;
        number /= 10;
    }
    if (oddSum == evenSum)
        Console.Write($"{i} ");
}
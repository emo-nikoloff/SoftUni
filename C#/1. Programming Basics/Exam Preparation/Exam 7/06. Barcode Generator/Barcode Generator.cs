// Техниката в магазин за коледни украси се разваля. Артикулите, които съдържат четни числа в своя баркод не могат да бъдат маркирани от касиерите.
// Вашата задача е, да напишете програма, която генерира всички баркодове, които НЕ съдържат четни цифри в себе си.
int starting = int.Parse(Console.ReadLine());
int ending = int.Parse(Console.ReadLine());

int fourthDigitStart = starting % 10;
int processedNumberStart = starting / 10;
int thirdDigitStart = processedNumberStart % 10;
processedNumberStart = processedNumberStart / 10;
int secondDigitStart = processedNumberStart % 10;
processedNumberStart = processedNumberStart / 10;
int firstDigitStart = processedNumberStart % 10;

int fourthDigitEnd = ending % 10;
int processedNumberEnd = ending / 10;
int thirdDigitEnd = processedNumberEnd % 10;
processedNumberEnd = processedNumberEnd / 10;
int secondDigitEnd = processedNumberEnd % 10;
processedNumberEnd = processedNumberEnd / 10;
int firstDigitEnd = processedNumberEnd % 10;

for (int i = firstDigitStart; i <= firstDigitEnd; i++)
{
    for (int j = secondDigitStart; j <= secondDigitEnd; j++)
    {
        for (int k = thirdDigitStart; k <= thirdDigitEnd; k++)
        {
            for (int l = fourthDigitStart; l <= fourthDigitEnd; l++)
            {
                if ((i % 2 != 0) && (j % 2 != 0) && (k % 2 != 0) && (l % 2 != 0))
                    Console.Write($"{i}{j}{k}{l} ");
            }
        }
    }
}
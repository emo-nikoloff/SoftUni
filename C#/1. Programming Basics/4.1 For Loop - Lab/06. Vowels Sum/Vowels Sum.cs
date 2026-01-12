// Да се напише програма, която чете текст (стринг), въведен от потребителя, и изчислява и отпечатва сумата от стойностите на гласните букви според таблицата по-долу:
// буква      a   e   i   o   u
// стойност   1   2   3   4   5
string text = Console.ReadLine();

int sum = 0;
for (int i = 0; i < text.Length; i++)
{
    char currentSymbol = text[i];

    int points = 0;
    if (currentSymbol == 'a')
        points = 1;
    else if (currentSymbol == 'e')
        points = 2;
    else if (currentSymbol == 'i')
        points = 3;
    else if (currentSymbol == 'o')
        points = 4;
    else if (currentSymbol == 'u')
        points = 5;

    sum += points;
}
Console.WriteLine(sum);
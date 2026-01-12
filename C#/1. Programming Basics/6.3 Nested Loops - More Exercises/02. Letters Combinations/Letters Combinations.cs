// Напишете програма, която да принтира на конзолата всички комбинации от 3 букви в зададен интервал, като се пропускат комбинациите съдържащи зададена от конзолата буква.
// Накрая трябва да се изпринтира броят на отпечатаните комбинации.
char letter1 = char.Parse(Console.ReadLine());
char letter2 = char.Parse(Console.ReadLine());
char letter3 = char.Parse(Console.ReadLine());

int combinations = 0;
for (char lett1 = letter1; lett1 <= letter2; lett1++)
{
    for (char lett2 = letter1; lett2 <= letter2; lett2++)
    {
        for (char lett3 = letter1; lett3 <= letter2; lett3++)
        {
            if (lett1 == letter3 || lett2 == letter3 || lett3 == letter3)
                continue;
            Console.Write($"{lett1}{lett2}{lett3} ");
            combinations++;
        }
    }
}
Console.WriteLine(combinations);
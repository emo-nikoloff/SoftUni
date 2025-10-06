// Да се напише програма, която генерира трицифрени PIN кодове, като цифрите на всеки PIN код са в определен интервал.
// За да бъде валиден един PIN код той трябва да отговаря на следните условия:
//•	Първата и третата цифра трябва да бъдат четни.
//•	Втората цифра трябва да бъде просто число в диапазона [2...7].
int n1 = int.Parse(Console.ReadLine());
int n2 = int.Parse(Console.ReadLine());
int n3 = int.Parse(Console.ReadLine());

for (int i = 2; i <= 8; i += 2)
{
    if (i > n1)
        break;

    for (int j = 2; j <= 7; j++)
    {
        if (j > n2)
            break;
        if (j == 4 || j == 6)
            continue;
        for (int k = 2; k <= 8; k += 2)
        {
            if (k > n3)
                break;
            Console.WriteLine($"{i} {j} {k}");
        }
    }
}
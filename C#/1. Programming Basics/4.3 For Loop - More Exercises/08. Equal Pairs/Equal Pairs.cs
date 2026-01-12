// Дадени са 2*n-на брой числа. Първото и второто формират двойка, третото и четвъртото също и т.н. Всяка двойка има стойност – сумата от съставящите я числа.
// Напишете програма, която проверява дали всички двойки имат еднаква стойност или печата максималната разлика между две последователни двойки.
// Ако всички двойки имат еднаква стойност, отпечатайте "Yes, value={Value}" + стойността. В противен случай отпечатайте "No, maxdiff={Difference}" + максималната разлика. 
int n = int.Parse(Console.ReadLine());

int sumPrevious = 0;
int maxDiff = 0;
for (int i = 0; i < n; i++)
{
    int n1 = int.Parse(Console.ReadLine());
    int n2 = int.Parse(Console.ReadLine());

    int sum = n1 + n2;

    if (i > 0)
        maxDiff = Math.Max(maxDiff, Math.Abs(sum - sumPrevious));
    sumPrevious = sum;
}

if (maxDiff == 0)
    Console.WriteLine($"Yes, value={sumPrevious}");
else
    Console.WriteLine($"No, maxdiff={maxDiff}");
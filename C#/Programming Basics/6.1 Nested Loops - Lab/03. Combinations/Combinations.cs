// Напишете програма, която изчислява колко решения в естествените числа (включително и нулата) има уравнението:
// x1 + x2 + x3 = n
// Числото n е цяло число и се въвежда от конзолата. 
int n = int.Parse(Console.ReadLine());

int k = 0;
for (int i = 0; i <= n; i++)
{
    for (int j = 0; j <= n; j++)
    {
        for (int c = 0; c <= n; c++)
        {
            if (i + j + c == n)
                k++;
        }
    }

}
Console.WriteLine(k);
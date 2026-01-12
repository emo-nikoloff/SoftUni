// Да се напише програма, която чете 2*n-на брой цели числа, подадени от потребителя,
// и проверява дали сумата на първите n числа (лява сума) е равна на сумата на вторите n числа (дясна сума).
// При равенство печата " Yes, sum = " + сумата; иначе печата " No, diff = " + разликата. Разликата се изчислява като положително число (по абсолютна стойност). 
int n = int.Parse(Console.ReadLine());

int leftSum = 0;
for (int i = 1; i < n; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());
    leftSum += currentNumber;
}

int rightSum = 0;
for (int i = 0; i < n; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());
    rightSum += currentNumber;
}

if (leftSum == rightSum)
    Console.WriteLine($"Yes, sum = {leftSum}");
else
    Console.WriteLine($"No, diff = {Math.Abs(leftSum - rightSum)}");

/*int leftSum = 0;
int rightSum = 0;
for (int i = 0; i < 2 * n; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());

    if (i < n)
        leftSum += currentNumber;
    else
        rightSum += currentNumber;
}
if (leftSum == rightSum)
    Console.WriteLine($"Yes, sum = {leftSum}");
else
    Console.WriteLine($"No, diff = {Math.Abs(leftSum - rightSum)}");*/
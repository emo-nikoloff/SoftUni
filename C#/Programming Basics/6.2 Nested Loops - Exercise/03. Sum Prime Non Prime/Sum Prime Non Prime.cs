// Напишете програма, която чете от конзолата цели числа в диапазона, докато не се получи команда "stop".
// Да се намери сумата на всички въведени прости и сумата на всички въведени непрости числа.
// Тъй като по дефиниция от математиката отрицателните числа не могат да бъдат прости,
// ако на входа се подаде отрицателно число да се изведе следното съобщение "Number is negative.".
// В този случай въведено число се игнорира и не се прибавя към нито една от двете суми, а програмата продължава своето изпълнение, очаквайки въвеждане на следващо число. 
string input;

int primeSum = 0;
int compositeSum = 0;
while ((input = Console.ReadLine()) != "stop")
{
    int number = int.Parse(input);

    if (number < 0)
    {
        Console.WriteLine("Number is negative.");
        continue;
    }

    bool isPrime = true;
    for (int i = 2; i <= Math.Sqrt(number); i++)
    {
        if (number % i == 0)
            isPrime = false;
    }

    if (isPrime)
        primeSum += number;
    else
        compositeSum += number;
}
Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
Console.WriteLine($"Sum of all non prime numbers is: {compositeSum}");
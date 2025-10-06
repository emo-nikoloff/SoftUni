Console.Write("Въведи цяло число: ");
string name = Console.ReadLine();

int number = int.Parse(name);
Console.WriteLine("Въведено число: " + number);

Console.Write("Въведи дробно или цяло число: ");
string input = Console.ReadLine();

double num = double.Parse(input);
Console.WriteLine("Въведено число: " + num);

Console.WriteLine("------------------------------------------------------------------");

Console.WriteLine("Операции с числа:");
Console.Write("Въведи цяло число: ");
int a = int.Parse(Console.ReadLine());
Console.Write("Въведи цяло число: ");
int b = int.Parse(Console.ReadLine());
Console.Write("I. Събиране: ");
Console.WriteLine(a + b);
Console.Write("II. Изваждане: ");
Console.WriteLine(a - b);
Console.Write("III. Умножение: ");
Console.WriteLine(a * b);
Console.WriteLine("IV. Деление:");
Console.Write("IV.I. Целочислено деление: ");
int result = a / b;
Console.WriteLine(result);
Console.Write("IV.II. Реално деление: ");

double answer = (1.0 * a) / b; // умножаваме една от зададените стойностите по число с подвижна запетая, защото са от тип int, а резултатът е тип double
Console.WriteLine(answer);
Console.Write("IV.III. Модулно деление: ");
Console.WriteLine(a % b);

Console.WriteLine("------------------------------------------------------------------");

Console.Write("Въведи цяло число: ");
int n = int.Parse(Console.ReadLine());
Console.WriteLine("Отпечатай само четните числа: ");
for (int i = 1; i <= n; i++)
{
    if (i % 2 == 0)
        Console.WriteLine(i);
}
Console.WriteLine("Отпечатай само нечетните числа: ");
for (int i = 1; i <= n; i++)
{
    if (i % 2 != 0)
        Console.WriteLine(i);
}

Console.WriteLine("------------------------------------------------------------------");
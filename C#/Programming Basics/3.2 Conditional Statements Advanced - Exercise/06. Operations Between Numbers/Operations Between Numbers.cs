// Напишете програма, която чете две цели числа (N1 и N2) и оператор, с който да се извърши дадена математическа операция с тях.
// Възможните операции са: Събиране(+), Изваждане(-), Умножение(*), Деление(/) и Модулно деление(%).
// При събиране, изваждане и умножение на конзолата трябва да се отпечатат резултата и дали той е четен или нечетен. При обикновеното деление – резултата.
// При модулното деление – остатъка. Трябва да се има предвид, че делителят може да е равен на 0(нула), а на нула не се дели. В този случай трябва да се отпечата специално съобщениe.
int n1 = int.Parse(Console.ReadLine());
int n2 = int.Parse(Console.ReadLine());
char operation = char.Parse(Console.ReadLine());

double sum = 0;
string result = $"{n1} {operation} {n2}";
switch (operation)
{
    case '+':
        sum = n1 + n2;

        if (sum % 2 == 0)
        {
            Console.WriteLine($"{result} = {sum} - even");
        }
        else
            Console.WriteLine($"{result} = {sum} - odd");
        break;
    case '-':
        sum = n1 - n2;

        if (sum % 2 == 0)
        {
            Console.WriteLine($"{result} = {sum} - even");
        }
        else
            Console.WriteLine($"{result} = {sum} - odd");
        break;
    case '*':
        sum = n1 * n2;

        if (sum % 2 == 0)
        {
            Console.WriteLine($"{result} = {sum} - even");
        }
        else
            Console.WriteLine($"{result} = {sum} - odd");
        break;
    case '/':
        sum = (double)n1 / n2;

        if (n2 == 0)
            Console.WriteLine($"Cannot divide {n1} by zero");
        else
            Console.WriteLine($"{result} = {sum:f2}");
        break;
    case '%':
        sum = (double)n1 % n2;

        if (n2 == 0)
            Console.WriteLine($"Cannot divide {n1} by zero");
        else
            Console.WriteLine($"{result} = {sum}");
        break;
}
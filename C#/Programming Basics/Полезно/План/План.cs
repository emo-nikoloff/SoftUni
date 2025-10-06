// Полезни команди:
//-> Ctrl + K + Ctrl + D - форматира кода
//-> Ctrl + X - изрязва
//-> Ctrl + Shift + Z или Ctrl + Y - връща последно отменения елемент
//-> Ctrl + F5 - стартира програмата без дебъгер
//-> Ctrl + A - селектира целия код
//-> Ctrl + K + Ctrl + C - превръща в коментар селектираната част
//-> Ctrl + Shift + <- или -> (зависи от стартовата позиция) - селектира всяка дума и знак; ☆ако е без Ctrl - селектира всеки елемент

// Полезна информация:
//-> Тернарен оператор: type1 = type1 - type2 < 0 ? 0 : type1 - type2; - знакът "?" означава "if(...)", а знакът ":" означава "else"
//-> Константа: const <type> <name> = <value>; - не променя стойността си
//-> Проверка дали даден символ е буква: <bool> char.IsLetter(type)
//-> Дадено число е с по-малко от 2 цифри: {...:D2} - слага нула, за да допълни числото
//-> Процент: {...:P2} - умножава числото по 100, форматира го до 2 знака след десетичната запетая и слага знак "%" накрая

// <тип> <име> = <стойност>;

int number = 10;
//-> 1. Името трябва да бъде уникално
//-> 2. Името трябва да следва camelCase конвенция

// Променливи:
int mySpecialNumber = 25; // цяло число
double number1 = 3.14; // дробно число (реално число)
string text = "Hello!"; // текст
char symbol = 'A'; // символ
bool isNumber1Positive = number > 0; // вярно или грешно
Console.Write("Цяло число: ");
Console.WriteLine(number); // отпечатва въведената променлива
Console.Write("Моето специално число: ");
Console.WriteLine(mySpecialNumber);
Console.Write("Дробно число: ");
Console.WriteLine(number1);
Console.Write("Текст: ");
Console.WriteLine(text);
Console.Write("Символ: ");
Console.WriteLine(symbol);
Console.Write("Вярно ли е, че 10 е по-голямо от 0: ");
Console.WriteLine(isNumber1Positive);

Console.WriteLine(); // не е зададено нищо за отпечатване -> отпечатва празен ред

Console.Write("Въведи текст: ");
string name = Console.ReadLine(); // команда за четене от конзолата -> връща ни текста въведен от потребителя
Console.Write("Въведен текст: ");
Console.WriteLine(name);

Console.WriteLine("------------------------------------------------------------------");

// Събиране на числа:
Console.Write("Събиране: ");
int a = 15;
int b = 7;
int sum = a + b;
Console.WriteLine(sum);
// Изваждане на числа:
Console.Write("Изваждане: ");
int c = 15;
int d = 7;
int result = c - d;
Console.WriteLine(result);
// Умножение на числа:
Console.Write("Умножение: ");
int e = 15;
int f = 7;
int product = e * f;
Console.WriteLine(product);
// Деление на числа:
//-> Целочислено деление: резултатът е цяло число
Console.Write("Целочислено деление: ");
int g = 15;
int h = 7;
int outcome = g / h;
Console.WriteLine(outcome);
//-> Реално деление: резултатът е число с подвижна запетая(floating-point number); ☆стойностите винаги са от тип double
Console.Write("Реално деление: ");
double j = 15;
double k = 7;
double answer = j / k;
Console.WriteLine(answer);
//-> Модулно деление: резултатът е остатъкът от делението
Console.Write("Модулно деление: ");
int l = 15;
int m = 7;
int solution = l % m;
Console.WriteLine(solution);

Console.WriteLine("------------------------------------------------------------------");

// Съединяване на текст и число:
Console.Write("Име, фамилия, години: ");
string firstName = "Мария";
string lastName = "Иванова";
int age = 19;
string str = firstName + " " + lastName + " на " + age + " години";
Console.WriteLine(str);

Console.WriteLine();

double num = 1.5;
double num1 = 2.5;
string total = "Сборът е: " + num + num1; // "Сборът е: " + 1.5 + 2.5 => "Сборът е: 1.5" + 2.5 => "Сборът е: 1.52.5"
Console.WriteLine(total);

Console.WriteLine("------------------------------------------------------------------");

// Съединяване чрез интерполация - означава се с '$':
string nameFirst = "Емилиян";
string nameLast = "Николов";
int years = 19;
string town = "Силистра";
Console.WriteLine($"Ти си {nameFirst} {nameLast}, на {years} години от {town}.");

Console.WriteLine("------------------------------------------------------------------");

// Оператори за сравнение: 
int a1 = 10;
int b1 = 10;
//-> Равенство: ==
Console.WriteLine("10 е равно на 10 - " + (a1 == b1));
//-> Различно: !=
Console.WriteLine("10 е различно от 10 - " + (a1 != b1));
//-> По-голямо: >
Console.WriteLine("10 е по-голямо от 10 - " + (a1 > b1));
//-> По-голямо или равно: >=
Console.WriteLine("10 е по-голямо или равно на 10 - " + (a1 >= b1));
//-> По-малко: <
Console.WriteLine("10 е по-малко от 10 - " + (a1 < b1));
//-> По-малко или равно: <=
Console.WriteLine("10 е по-малко или равно на 10 - " + (a1 <= b1));

Console.WriteLine("------------------------------------------------------------------");

// Блок от код - {}:
string color = "червено";

Console.WriteLine("Ако цветът е червено отпечатай: ");
if (color == "червено")
{
    Console.WriteLine("домат");
    Console.WriteLine("ягода");
}
else
{
    Console.WriteLine("банан");
    Console.WriteLine("довиждане");
}
/* ако премахнем {} скоби ще се изпълни само:
string color = "red";
if (color == "red")
    Console.WriteLine("tomato");
else
    Console.WriteLine("banana");*/

Console.WriteLine("------------------------------------------------------------------");

int number2 = 7;

if (number2 > 4)
    Console.WriteLine($"Числото {number2} е по-голямо от 4");
else if (number2 > 5)
    Console.WriteLine($"Числото {number2} е по-голямо от 5");
else
    Console.WriteLine("Равно на 7");
//-> програмата проверява първото условие, установява, че е вярно и приключва

Console.WriteLine("------------------------------------------------------------------");

// Закръгляне до следващо (по-голямо) цяло число:
double up = Math.Ceiling(23.45);
// Закръгляне до предишно (по-малко) цяло число:
double down = Math.Floor(45.67);
// Намиране на абсолютна стойност:
int example1 = Math.Abs(-50);
int example2 = Math.Abs(50);
Console.WriteLine($"Закръгли 23,45 до следващо цяло число: {up}");
Console.WriteLine($"Закръгли 45,67 до предишно цяло число: {down}");
Console.WriteLine($"Абсолютната стойност на -50 е: {example1}");
Console.WriteLine($"Абсолютната стойност на 50 е: {example2}");
// Закръгляне до 2 знака след десетичната запетая:
double round = Math.Round(45.67852, 2);
Console.WriteLine($"Закръгли 45.67852 до 2 знака след десетичната запетая: {round}");
// Форматиране до 2 знака след десетичната запетая:
Console.Write("Форматирай 123.456 до 2 знака след десетичната запетая: ");
Console.WriteLine("{0:F2}", 123.456);
Console.WriteLine($"Форматирай 4583.7563 до 2 знака след десетичната запетая: {4583.7563:F2}");
/* Разлика между форматиране и закръгляне:
Console.WriteLine(Math.Round(45.60000, 4)); // 45.6
Console.WriteLine("{0:F4}", 45.60000); // 45.6000*/
// Съкращаване до цяла част:
double truncate = Math.Truncate(3.14);
Console.WriteLine($"Съкрати 3,14 до цяла част: {truncate}");

Console.WriteLine("------------------------------------------------------------------");

// Switch-case конструкция:
Console.Write("Въведи число: ");
int day = int.Parse(Console.ReadLine());

Console.Write("Ден от седмицата: ");
switch (day)
{
    case 1:
        Console.WriteLine("Понеделник");
        break;
    case 2:
        Console.WriteLine("Вторник");
        break;
    case 3:
        Console.WriteLine("Сряда");
        break;
    case 4:
        Console.WriteLine("Четвъртък");
        break;
    case 5:
        Console.WriteLine("Петък");
        break;
    case 6:
        Console.WriteLine("Събота");
        break;
    case 7:
        Console.WriteLine("Неделя");
        break;
    default:
        Console.WriteLine("Грешка!");
        break;
}

Console.WriteLine("------------------------------------------------------------------");

// Логически оператори:
//-> && - и (проверява изпълнението на няколко условия едновременно)
Console.Write("Проверка дали числото е по-голямо от 5 и по-малко от 10 и е четно: ");
int number3 = int.Parse(Console.ReadLine());

if (number3 == 5 && number3 == 10 && number3 % 2 == 0)
    Console.WriteLine($"Числото {number3} е по-голямо от 5 и по-малко от 10 и е четно");
else if (number3 < 5)
    Console.WriteLine($"Грешка, защото числото {number3} е по-малко от 5");
else if (number3 == 5)
    Console.WriteLine($"Грешка, защото числото {number3} е равно на 5");
else if (number3 > 10)
    Console.WriteLine($"Грешка, защото числото {number3} е по-голямо от 10");
else if (number3 == 10)
    Console.WriteLine($"Грешка, защото числото {number3} е равно на 10");

//-> || - или (проверява дали е изпълнено поне едно измежду няколко условия)
Console.Write("Проверка дали думата е Example или Demo: ");
string word = Console.ReadLine();

if (word == "Example" || word == "Demo")
    Console.WriteLine($"Думата е: {word}");
else
    Console.WriteLine("Думата е друга");
//-> ! - отрицание (проверява дали не е изпълнено дадено условиe)
Console.WriteLine("Проверка дали числото е по-голямо от 10 и е четно ");
Console.Write(" - Отпечатай на конзолата само, ако числото е невалидно: ");
int number4 = int.Parse(Console.ReadLine());
bool isValid = (number4 > 10) && (number4 % 2 == 0);

if (!isValid)
{
    Console.WriteLine("Невалидно!");
}

Console.WriteLine("------------------------------------------------------------------");

// Увеличаване и намаляване на стойността на променливи:
// ☆ако искаме да увеличим или намалим дадена стойност слагаме + или - пред =
int num2 = 10;
num2 += 5; // num2 = num2 + 5;
Console.WriteLine($"Увеличи числото 10 с пет единици: {num2}");
num2 -= 5; // num2 = num2 - 5;
Console.WriteLine($"Намали числото 15 с пет единици: {num2}");
// Инкрементиране:
//-> Пре-инкрементация - стойността на променливата се увеличава с 1 и след това се принтира
Console.Write("Увеличава стойността с единица и отпечатва променливата: ");
int num3 = 1;
Console.Write($"{++num3} ");
Console.WriteLine(num3);
//-> Пост-инкрементация - първо се принтира променливата и след това се увеличава с 1
Console.Write("Отпечатва променливата и увеличава стойността с единица: ");
int num4 = 1;
Console.Write($"{num4++} ");
Console.WriteLine(num4);
// Декрементиране:
//-> Пре-декрементация - стойността на променливата се намалява с 1 и след това се принтира
Console.Write("Намалява стойността с единица и отпечатва променливата: ");
int num5 = 1;
Console.Write($"{--num5} ");
Console.WriteLine(num5);
//-> Пост-декрементация - първо се принтира променливата и след това се намалява с 1
Console.Write("Отпечатва променливата и намалява стойността с единица: ");
int num6 = 1;
Console.Write($"{num6--} ");
Console.WriteLine(num6);

Console.WriteLine("------------------------------------------------------------------");

// For-цикъл – конструкция:
Console.WriteLine("Отпечатай числата от 1 до 12:");
for (int i = 1; i <= 12; i += 1) // 1.Начална стойност; 2.Крайна стойност; 3.Стъпка
    Console.WriteLine(i);

Console.WriteLine("------------------------------------------------------------------");

// Работа с текст:
//-> Дължина на текст
Console.Write("Колко символа има думата 'SoftUni': ");
string text1 = "SoftUni";
int length = text1.Length;
Console.WriteLine(length);
//-> Символ от текст по индекс
Console.Write("Четвъртият символ от думата 'SoftUni' е: ");
string text2 = "SoftUni";
char letter = text2[4]; // броенето започва от 0
Console.WriteLine(letter);

Console.WriteLine("------------------------------------------------------------------");

// While цикъл:
Console.WriteLine($"Отпечатай числата от 5 до 10 и обратно:");
int digit1 = 5; // 1.Начална стойност
while (digit1 <= 10) // 2.Крайна стойност
{
    Console.WriteLine(digit1);
    digit1++; // 3.Стъпка
}

//-> Прекратяване на цикъл чрез оператор break
int digit2 = 9;
while (true)
{
    if (digit2 < 5)
    {
        break;
    }

    Console.WriteLine(digit2);
    digit2--;
}

//-> Продължаване на цикъл чрез оператор continue
Console.WriteLine($"Отпечатай положителните числа по-малки от 10 през 2:");
int digit3 = 0;
while (digit3 < 10)
{
    if (digit3 % 2 == 0)
    {
        digit3++;
        continue;
    }

    Console.WriteLine(digit3);
    digit3++;
}
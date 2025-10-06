// Напишете програма, която да умножава положителни числа по 2. От конзолата се четат поредица от реални числа, всяко на нов ред, докато не се въведе отрицателно.
// След всяко умножено число на нов ред да се отпечата "Result: {резултата от умножението}". Резултата от умножението да бъде форматиран до втория знак след десетичния разделител.
// При получаване на негативно число, на конзолата да се отпечата "Negative number!" и програмата да приключи изпълнение.
double number = double.Parse(Console.ReadLine());

double multipliedNumber = 0;
while (number >= 0)
{
    number *= 2;
    multipliedNumber += number;
    Console.WriteLine($"Result: {number:f2}");
    number = double.Parse(Console.ReadLine());
}
Console.WriteLine("Negative number!");
// Да се напише програма, в която потребителят въвежда вида и размерите на геометрична фигура и пресмята лицето й.
// Фигурите са четири вида: квадрат (square), правоъгълник (rectangle), кръг (circle) и триъгълник (triangle).
// На първия ред на входа се чете вида на фигурата (текст със следните възможности: square, rectangle, circle или triangle). 
// •	Ако фигурата е квадрат (square): на следващия ред се чете едно дробно число - дължина на страната му
// •	Ако фигурата е правоъгълник (rectangle): на следващите два реда четат две дробни числа - дължините на страните му
// •	Ако фигурата е кръг (circle): на следващия ред чете едно дробно число - радиусът на кръга
// •	Ако фигурата е триъгълник (triangle): на следващите два реда четат две дробни числа - дължината на страната му и дължината на височината към нея
// Резултатът да се закръгли до 3 цифри след десетичната запетая. 
string figure = Console.ReadLine();

double area = 0;
if (figure == "square")
{
    double side = double.Parse(Console.ReadLine());
    area = side * side;
}
else if (figure == "rectangle")
{
    double length = double.Parse(Console.ReadLine());
    double width = double.Parse(Console.ReadLine());
    area = length * width;
}
else if (figure == "circle")
{
    double radius = double.Parse(Console.ReadLine());
    area = Math.PI * radius * radius;
}
else if (figure == "triangle")
{
    double side = double.Parse(Console.ReadLine());
    double height = double.Parse(Console.ReadLine());
    area = side * height / 2;
}
Console.WriteLine($"{area:f3}");
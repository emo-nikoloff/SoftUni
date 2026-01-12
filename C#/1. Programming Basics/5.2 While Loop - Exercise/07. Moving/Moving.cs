// На осемнадесетия си рожден ден на Хосе взел решение, че ще се изнесе да живее на квартира. Опаковал багажа си в кашони и намерил подходяща обява за апартамент под наем.
// Той започва да пренася своя багаж на части, защото не може да пренесе целия наведнъж.
// Има ограничено свободно пространство в новото си жилище, където може да разположи вещите, така че мястото да бъде подходящо за живеене.
// Напишете програма, която изчислява свободния обем от жилището на Хосе, който остава след като пренесе багажа си. 
// Бележка: Един кашон е с точни размери:  1m.x 1m.x 1m.
int widthSpace = int.Parse(Console.ReadLine());
int lengthSpace = int.Parse(Console.ReadLine());
int heightSpace = int.Parse(Console.ReadLine());

int space = widthSpace * lengthSpace * heightSpace;

string input = Console.ReadLine();
int leftSpace = 0;
while (input != "Done")
{
    int boxes = int.Parse(input);
    leftSpace += boxes;

    if (leftSpace > space)
    {
        Console.WriteLine($"No more free space! You need {Math.Abs(space - leftSpace)} Cubic meters more.");
        break;
    }

    input = Console.ReadLine();
}

if (input == "Done")
{
    Console.WriteLine($"{space - leftSpace} Cubic meters left.");
}
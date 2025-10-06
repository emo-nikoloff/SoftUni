// От лозе с площ X квадратни метри се заделя 40% от реколтата за производство на вино. От 1 кв.м лозе се изкарват Y килограма грозде. За 1 литър вино са нужни 2,5 кг. грозде.
// Желаното количество вино за продан е Z литра.
// Напишете програма, която пресмята колко вино може да се произведе и дали това количество е достатъчно. Ако е достатъчно, остатъкът се разделя по равно между работниците на лозето.
int vineyardArea = int.Parse(Console.ReadLine());
double grapesKG = double.Parse(Console.ReadLine());
int wantedWineLitres = int.Parse(Console.ReadLine());
int workers = int.Parse(Console.ReadLine());

double grapesTotal = vineyardArea * grapesKG;
double wineLitres = (0.4 * grapesTotal) / 2.5;

if (wineLitres < wantedWineLitres)
    Console.WriteLine($"It will be a tough winter! More {Math.Floor(Math.Abs(wineLitres - wantedWineLitres))} liters wine needed.");
else
{
    Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineLitres)} liters.");
    Console.WriteLine($"{Math.Ceiling(wineLitres - wantedWineLitres)} liters left -> {Math.Ceiling((wineLitres - wantedWineLitres) / workers)} liters per person.");
}
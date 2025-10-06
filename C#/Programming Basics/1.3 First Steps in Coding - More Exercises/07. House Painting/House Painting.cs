// Напишете програма, която да пресмята колко литра боя е нужна за боядисването на къщa. Като за стените се използва зелена боя, а за покрива – червена.
// Разхода на зелената боя е 1 литър за 3.4 м2, а на червената – 1 литър за 4.3 м2.
// Стените имат следните размери:
// •	Предната и задната стена са квадрати със страна „x“
//   o	  на предната стена има правоъгълна врата с широчина 1.2м и височина 2м
// •	Страничните стени са правоъгълници със страни „x“ и „y“
//   o	  и на двете странични стени има по един квадратен прозорец със страна 1.5м
// Покривът има следните размери:
// •	Два правоъгълника със страни „x“ и „y“
// •	Два равностранни триъгълника със страна „x“ и височина „h“
// Трябва да пресметнете площта на всички страни и площта на покрива, за да намерите колко литра от всяка боя ще са нужни.
double x = double.Parse(Console.ReadLine());
double y = double.Parse(Console.ReadLine());
double h = double.Parse(Console.ReadLine());

double sideWall = x * y;
double sideWalls = 2 * sideWall - 2 * (1.5 * 1.5);
double wall = x * x;
double walls = 2 * wall - (1.2 * 2);
double wallsArea = sideWalls + walls;

double greenPaint = wallsArea / 3.4;

double roofRectangles = 2 * (x * y);
double roofTriangles = 2 * (x * h / 2);
double roofArea = roofRectangles + roofTriangles;

double redPaint = roofArea / 4.3;
Console.WriteLine($"{greenPaint:f2}");
Console.WriteLine($"{redPaint:f2}");
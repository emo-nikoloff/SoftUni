// Иван решава да подобри Световния рекорд по плуване на дълги разстояния.
// На конзолата се въвежда рекордът в секунди, който Иван трябва да подобри,  разстоянието в метри, което трябва да преплува и времето в секунди, за което плува разстояние от 1 м.
// Да се напише програма, която изчислява дали се е справил със задачата, като се има предвид, че: съпротивлението на водата го забавя на всеки 15 м. с 12.5 секунди.
// Когато се изчислява колко пъти Иванчо ще се забави, в резултат на съпротивлението на водата, резултатът трябва да се закръгли надолу до най-близкото цяло число.
// Да се изчисли времето в секунди, за което Иванчо ще преплува разстоянието и разликата спрямо Световния рекорд. 
double record = double.Parse(Console.ReadLine());
double meters = double.Parse(Console.ReadLine());
double secondsForMeter = double.Parse(Console.ReadLine());

double swimTime = meters * secondsForMeter;
double resistance = Math.Floor(meters / 15) * 12.5;
double totalSwim = swimTime + resistance;

if (totalSwim < record)
    Console.WriteLine($"Yes, he succeeded! The new world record is {totalSwim:f2} seconds.");
else
{
    double slowerWith = totalSwim - record;
    Console.WriteLine($"No, he failed! He was {slowerWith:f2} seconds slower.");
}
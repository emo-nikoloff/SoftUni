// Григор Димитров е тенисист, чиято следваща цел е изкачването в световната ранглиста по тенис за мъже. 
// През годината Гришо участва в определен брой турнири, като за всеки турнир получава точки, които зависят от позицията, на която е завършил в турнира.
// Има три варианта за завършване на турнир:
// 	W - ако е победител получава 2000 точки
// 	F - ако е финалист получава 1200 точки
// 	SF - ако е полуфиналист получава 720 точки
// Напишете програма, която изчислява колко ще са точките на Григор след изиграване на всички турнири, като знаете с колко точки стартира сезона.
// Също изчислете колко точки средно печели от всички изиграни турнири и колко процента от турнирите е спечелил. 
int tournaments = int.Parse(Console.ReadLine());
int tournamentPoints = int.Parse(Console.ReadLine());

int tournamentsWon = 0;
int tournamentPointsWon = 0;
for (int i = 0; i < tournaments; i++)
{
    string place = Console.ReadLine();

    if (place == "W")
    {
        tournamentPointsWon += 2000;
        tournamentsWon++;
    }
    else if (place == "F")
        tournamentPointsWon += 1200;
    else if (place == "SF")
        tournamentPointsWon += 720;
}
Console.WriteLine($"Final points: {tournamentPoints + tournamentPointsWon}");
Console.WriteLine($"Average points: {tournamentPointsWon / tournaments}");
Console.WriteLine($"{100.0 * tournamentsWon / tournaments:f2}%");
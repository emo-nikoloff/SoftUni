// Деси много обича да гледа филми, но често й е трудно да си избере подходящ за гледане.
// Набелязва си определен брой филми и иска да си избере кой филм да гледа спрямо рейтинга на филмите.
// Напишете програма, която показва кой филм е с най-висок рейтинг, кой е с най-нисък и колко е средният рейтинг от всички филми, които си е набелязала да гледа.
int movies = int.Parse(Console.ReadLine());

double allRatings = 0;
double maxRating = double.MinValue;
double minRating = double.MaxValue;
string maxRatedMovie = "";
string minRatedMovie = "";
for (int movie = 1; movie <= movies; movie++)
{
    string movieName = Console.ReadLine();
    double rating = double.Parse(Console.ReadLine());

    allRatings += rating;
    if (rating > maxRating)
    {
        maxRating = rating;
        maxRatedMovie = movieName;
    }
    if (rating < minRating)
    {
        minRating = rating;
        minRatedMovie = movieName;
    }
}
Console.WriteLine($"{maxRatedMovie} is with highest rating: {maxRating:f1}");
Console.WriteLine($"{minRatedMovie} is with lowest rating: {minRating:f1}");
Console.WriteLine($"Average rating: {allRatings / movies:f1}");
// По време на обедната почивка искате да изгледате епизод от своя любим сериал.
// Вашата задача е да напишете програма, с която ще разберете дали имате достатъчно време да изгледате епизода. По време на почивката отделяте време за обяд и време за отдих.
// Времето за обяд ще бъде 1/8 от времето за почивка, а времето за отдих ще бъде 1/4 от времето за почивка. 
string serial = Console.ReadLine();
double episodeLength = double.Parse(Console.ReadLine());
double restLength = double.Parse(Console.ReadLine());

double lunch = restLength * 0.125;
double restTime = restLength * 0.25;
double leftTime = restLength - lunch - restTime;

double time = Math.Ceiling(Math.Abs(leftTime - episodeLength));

if (leftTime >= episodeLength)
    Console.WriteLine($"You have enough time to watch {serial} and left with {time} minutes free time.");
else
{
    Console.WriteLine($"You don't have enough time to watch {serial}, you need {time} more minutes.");
}
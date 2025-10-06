// Котката Том обича по цял ден да спи, за негово съжаление стопанинът му си играе с него винаги когато  има свободно време.
// За да се наспи добре, нормата за игра на Том е 30 000  минути в година. Времето за игра на Том зависи от почивните дни на стопанина му:
// •	Когато е на работа, стопанинът му си играе с него по 63 минути на ден.
// •	Когато почива, стопанинът му си играе с него  по 127 минути на ден.
// Напишете програма, която въвежда броя почивни дни и отпечатва дали Том може да се наспи добре и колко е разликата от нормата за текущата година, като приемем че годината има 365 дни.
int freeDays = int.Parse(Console.ReadLine());

int workingDays = 365;
int playTime = 30000;

workingDays -= freeDays;
int realPlayTime = (workingDays * 63) + (freeDays * 127);

int diffH = Math.Abs(realPlayTime - playTime);
int diffM = Math.Abs(realPlayTime - playTime);
if (realPlayTime > playTime)
{
    Console.WriteLine("Tom will run away");
    diffH /= 60;
    diffM %= 60;
    Console.WriteLine($"{diffH} hours and {diffM} minutes more for play");
}
else
{
    Console.WriteLine("Tom sleeps well");
    diffH /= 60;
    diffM %= 60;
    Console.WriteLine($"{diffH} hours and {diffM} minutes less for play");
}
// Предстои Вело състезание за благотворителност в което участниците са разпределени в младша("juniors") и старша("seniors") група.
// Парите се набавят от таксата за участие на велосипедистите. Според възрастовата група и вида на трасето на което ще се провежда състезанието, таксата е различна.
// Група      trail   cross-country   downhill   road
// juniors    5.50    8               12.25      20
// seniors    7       9.50            13.75      21.50
// Ако в "cross-country" състезанието се съберат 50 или повече участника(общо младши и старши), таксата  намалява с 25%. Организаторите отделят 5% процента от събраната сума за разходи.

int juniors = int.Parse(Console.ReadLine());
int seniors = int.Parse(Console.ReadLine());
string track = Console.ReadLine();

double juniorsFee = 0;
double seniorsFee = 0;

double sum = 0;
switch (track)
{
    case "trail":
        juniorsFee += 5.5;
        seniorsFee += 7;
        sum = juniors * juniorsFee + seniors * seniorsFee;
        sum = sum - (sum * 0.05);

        break;
    case "cross-country":
        juniorsFee += 8;
        seniorsFee += 9.5;

        if ((juniors + seniors) >= 50)
        {
            sum = juniors * juniorsFee + seniors * seniorsFee;
            sum = sum - (sum * 0.25);
            sum = sum - (sum * 0.05);
        }
        else
        {
            sum = juniors * juniorsFee + seniors * seniorsFee;
            sum = sum - (sum * 0.05);
        }

        break;
    case "downhill":
        juniorsFee += 12.25;
        seniorsFee += 13.75;
        sum = juniors * juniorsFee + seniors * seniorsFee;
        sum = sum - (sum * 0.05);

        break;
    case "road":
        juniorsFee += 20;
        seniorsFee += 21.5;
        sum = juniors * juniorsFee + seniors * seniorsFee;
        sum = sum - (sum * 0.05);

        break;
}

Console.WriteLine($"{sum:f2}");
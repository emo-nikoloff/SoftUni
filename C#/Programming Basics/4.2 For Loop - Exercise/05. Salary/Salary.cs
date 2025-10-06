// Шеф на компания забелязва че все повече служители прекарват  време в сайтове, които ги разсейват.  
// За да предотврати това, той въвежда изненадващи проверки на отворените табове на браузъра на служителите си. 
// Според отворения сайт в таба се налагат следните глоби:
// •	"Facebook" -> 150 лв.
// •	"Instagram" -> 100 лв.
// •	"Reddit" -> 50 лв.
// От конзолата се четат два реда:
// •	Брой отворени табове в браузъра n - цяло число в интервала [1...10]
// •	Заплата - число в интервала [500...1500]
// След това n – на брой пъти се чете име на уебсайт – текст
int openedTabs = int.Parse(Console.ReadLine());
double salary = double.Parse(Console.ReadLine());

int fine = 0;
for (int i = 0; i < openedTabs && fine < salary; i++)
{
    string website = Console.ReadLine();
    if (website == "Facebook")
    {
        fine += 150;
    }
    else if (website == "Instagram")
    {
        fine += 100;
    }
    else if (website == "Reddit")
    {
        fine += 50;
    }
}

if (fine >= salary)
{
    Console.WriteLine("You have lost your salary.");
}
else
{
    Console.WriteLine(salary - fine);
}
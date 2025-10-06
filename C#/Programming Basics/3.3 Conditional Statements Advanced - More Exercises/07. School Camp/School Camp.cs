// Частно училище организира лагери за учениците по време на ваканциите.
// В зависимост от вида на ваканцията (пролетна, лятна или зимна) и вида на групата (момчета/момичета или смесена) цената на нощувката в хотела е различна,
// както и спортът, който ще практикуват учениците.
//                     Зимна ваканция	 Пролетна ваканция	 Лятна ваканция
// момчета/момичета	   9.60	             7.20	             15
// смесена група	   10	             9.50	             20
// Училището получава отстъпка от крайната цена, в зависимост от броя на настанените в хотела ученици:
// •	Ако броят на учениците е 50 или повече, училището получава 50% отстъпка
// •	Ако броят на учениците е 20 или повече и в същото време по-малък от 50, училището получава 15% отстъпка
// •	Ако броят на учениците е 10 или повече и в същото време по-малък от 20, училището получава 5% отстъпка
// В таблицата по-долу са дадени спортовете, които ще се практикуват в зависимост от вида на ваканцията и групата:
//	                Зимна ваканция	  Пролетна ваканция	   Лятна ваканция
// момичета	        Gymnastics	      Athletics	           Volleyball
// момчета	        Judo	          Tennis	           Football
// смесена група	Ski	              Cycling	           Swimming
// Да се напише програма, която пресмята цената, която ще заплати училището за нощувките и принтира спорта, който ще се практикува от учениците.
string season = Console.ReadLine();
string group = Console.ReadLine();
int students = int.Parse(Console.ReadLine());
int nights = int.Parse(Console.ReadLine());

string sport = "";
double sum = 0;
if (season == "Winter")
{
    if (group == "boys")
    {
        sum = 9.6 * nights * students;
        sport = "Judo";
    }
    else if (group == "girls")
    {
        sum = 9.6 * nights * students;
        sport = "Gymnastics";
    }
    else if (group == "mixed")
    {
        sum = 10 * nights * students;
        sport = "Ski";
    }
}
else if (season == "Spring")
{
    if (group == "boys")
    {
        sum = 7.2 * nights * students;
        sport = "Tennis";
    }
    else if (group == "girls")
    {
        sum = 7.2 * nights * students;
        sport = "Athletics";
    }
    else if (group == "mixed")
    {
        sum = 9.5 * nights * students;
        sport = "Cycling";
    }
}
else if (season == "Summer")
{
    if (group == "boys")
    {
        sum = 15 * nights * students;
        sport = "Football";
    }
    else if (group == "girls")
    {
        sum = 15 * nights * students;
        sport = "Volleyball";
    }
    else if (group == "mixed")
    {
        sum = 20 * nights * students;
        sport = "Swimming";
    }
}

if (students >= 10 && students < 20)
{
    sum = sum - (sum * 0.05);
}
else if (students >= 20 && students < 50)
{
    sum = sum - (sum * 0.15);
}
else if (students >= 50)
{
    sum = sum - (sum * 0.5);
}
else
{
    sum = sum;
}
Console.WriteLine($"{sport} {sum:f2} lv.");
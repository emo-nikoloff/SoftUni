// Магазин за цветя предлага 3 вида цветя: хризантеми, рози и лалета. Цените зависят от сезона.
// Сезон            Хризантеми      Рози            Лалета
// Пролет / Лято    2.00 лв./бр.    4.10 лв./бр.    2.50 лв./бр.
// Есен / Зима      3.75 лв./бр.    4.50 лв./бр.    4.15 лв./бр.
// В празнични дни цените на всички цветя се увеличават с 15%. Предлагат се следните отстъпки:
// •	За закупени повече от 7 лалета през пролетта – 5% от цената на целият букет.
// •	За закупени 10 или повече рози през зимата – 10% от цената на целият букет.
// •	За закупени повече от 20 цветя общо през всички сезони – 20% от цената на целият букет.
// Отстъпките се правят по така написания ред и могат да се наслагват! Всички отстъпки важат след оскъпяването за празничен ден!
// Цената за аранжиране на букета винаги е 2лв. Напишете програма, която изчислява цената за един букет.
int chrysanthemums = int.Parse(Console.ReadLine());
int roses = int.Parse(Console.ReadLine());
int tulips = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
string isHoliday = Console.ReadLine();

double chrysanthemumsPrice = 0;
double rosesPrice = 0;
double tulipsPrice = 0;

double sum = 0;
if (season == "Spring" || season == "Summer")
{
    chrysanthemumsPrice += 2;
    rosesPrice += 4.1;
    tulipsPrice += 2.5;
    sum = chrysanthemums * chrysanthemumsPrice + roses * rosesPrice + tulips * tulipsPrice;

    if (isHoliday == "Y")
    {
        sum = sum + (sum * 0.15);

        if (tulips > 7 && season == "Spring")
        {
            sum = sum - (sum * 0.05);

            if ((chrysanthemums + roses + tulips) > 20)
            {
                sum = sum - (sum * 0.2);
                sum += 2;
            }
            else
                sum += 2;
        }
        else
        {
            if ((chrysanthemums + roses + tulips) > 20)
            {
                sum = sum - (sum * 0.2);
                sum += 2;
            }
            else
                sum += 2;
        }
    }
    else if (isHoliday == "N")
    {
        if (tulips > 7 && season == "Spring")
        {
            sum = sum - (sum * 0.05);

            if ((chrysanthemums + roses + tulips) > 20)
            {
                sum = sum - (sum * 0.2);
                sum += 2;
            }
            else
                sum += 2;
        }
        else
        {
            if ((chrysanthemums + roses + tulips) > 20)
            {
                sum = sum - (sum * 0.2);
                sum += 2;
            }
            else
                sum += 2;
        }
    }
}
else if (season == "Autumn" || season == "Winter")
{
    chrysanthemumsPrice += 3.75;
    rosesPrice += 4.5;
    tulipsPrice += 4.15;
    sum = chrysanthemums * chrysanthemumsPrice + roses * rosesPrice + tulips * tulipsPrice;

    if (isHoliday == "Y")
    {
        sum = sum + (sum * 0.15);

        if (roses > 10 && season == "Winter")
        {
            sum = sum - (sum * 0.1);

            if ((chrysanthemums + roses + tulips) > 20)
            {
                sum = sum - (sum * 0.2);
                sum += 2;
            }
            else
                sum += 2;
        }
        else
        {
            if ((chrysanthemums + roses + tulips) > 20)
            {
                sum = sum - (sum * 0.2);
                sum += 2;
            }
            else
                sum += 2;
        }
    }
    else if (isHoliday == "N")
    {
        if (roses >= 10 && season == "Winter")
        {
            sum = sum - (sum * 0.1);

            if ((chrysanthemums + roses + tulips) > 20)
            {
                sum = sum - (sum * 0.2);
                sum += 2;
            }
            else
                sum += 2;
        }
        else
        {
            if ((chrysanthemums + roses + tulips) > 20)
            {
                sum = sum - (sum * 0.2);
                sum += 2;
            }
            else
                sum += 2;
        }
    }
}
Console.WriteLine($"{sum:f2}");
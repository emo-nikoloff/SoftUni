// Мобилен оператор предлага договори с различна месечна такса в зависимост от срока - 1 или 2 години.
// Да се напише програма, която изчислява дължимата сума, която трябва да се плати за определен брой месеци.
// срок / тип       Small       Middle	    Large	    ExtraLarge
// 1 година(one)	9.98 лв.	18.99 лв.	25.98 лв.	35.99 лв.
// 2 години(two)	8.58 лв.	17.09 лв.	23.59 лв.	31.79 лв.
// Условия:
// •   при добавен мобилен интернет, към таксата за един месец се добавя:
//    o   при такса по-малка или равна на 10.00 лв.  5.50 лв.
//    o   при такса по-малка или равна на 30.00 лв.  4.35 лв.
//    o   при такса по-голяма от 30.00 лв.  3.85 лв.
// •   ако договорът e за две години, общата сума се намалява с 3.75%
string termOfContract = Console.ReadLine();
string typeOfContract = Console.ReadLine();
string mobileInternet = Console.ReadLine();
int monthsToPay = int.Parse(Console.ReadLine());

double contractPrice = 0;
switch (termOfContract)
{
    case "one":
        switch (typeOfContract)
        {
            case "Small":
                contractPrice = 9.98;
                break;
            case "Middle":
                contractPrice = 18.99;
                break;
            case "Large":
                contractPrice = 25.98;
                break;
            case "ExtraLarge":
                contractPrice = 35.99;
                break;
        }
        break;
    case "two":
        switch (typeOfContract)
        {
            case "Small":
                contractPrice = 8.58;
                break;
            case "Middle":
                contractPrice = 17.09;
                break;
            case "Large":
                contractPrice = 23.59;
                break;
            case "ExtraLarge":
                contractPrice = 31.79;
                break;
        }
        break;
}

switch (mobileInternet)
{
    case "yes":
        if (contractPrice <= 10)
            contractPrice = contractPrice + 5.5;
        else if (contractPrice <= 30)
            contractPrice = contractPrice + 4.35;
        else
            contractPrice = contractPrice + 3.85;
        break;
}

double sum = contractPrice * monthsToPay;

if (termOfContract == "two")
    sum = sum - (sum * 0.0375);

Console.WriteLine($"{sum:f2} lv.");
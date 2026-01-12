// На благотворително събитие плащанията за закупените продукти винаги се редуват: плащане в брой и плащане с карта. Установени са следните правила за заплащане:
// •	Ако продуктът надвишава 100лв., за него не може да се плати в брой
// •	Ако продуктът е на цена под 10лв., за него не може да се плати с кредитна карта
// Програмата приключва или след като получим команда "End" или след като средствата бъдат събрани.
int estimatedSum = int.Parse(Console.ReadLine());

string input = Console.ReadLine();
int turn = 0, soldProductsSum = 0, soldProductsCash = 0, soldProductsCreditCard = 0, productsCash = 0, productsCreditCard = 0;
while (input != "End")
{
    turn++;
    int transaction = int.Parse(input);

    if (turn % 2 == 0)
    {
        if (transaction < 10)
        {
            Console.WriteLine("Error in transaction!");
        }
        else
        {
            Console.WriteLine("Product sold!");
            soldProductsCreditCard += transaction;
            productsCreditCard++;
        }
    }
    else
    {
        if (transaction > 100)
        {
            Console.WriteLine("Error in transaction!");
        }
        else
        {
            Console.WriteLine("Product sold!");
            soldProductsCash += transaction;
            productsCash++;
        }
    }
    soldProductsSum = soldProductsCreditCard + soldProductsCash;

    if (soldProductsSum >= estimatedSum)
    {
        Console.WriteLine($"Average CS: {soldProductsCash / (double)productsCash:f2}");
        Console.WriteLine($"Average CC: {soldProductsCreditCard / (double)productsCreditCard:f2}");
        break;
    }
    input = Console.ReadLine();
}

if (input == "End")
{
    if (soldProductsSum < estimatedSum)
    {
        Console.WriteLine("Failed to collect required money for charity.");
    }
}
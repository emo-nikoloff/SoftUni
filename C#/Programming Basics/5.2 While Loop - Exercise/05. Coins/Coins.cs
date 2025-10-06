// Производителите на вендинг машини искали да направят машините си да връщат възможно най-малко монети ресто.
// Напишете програма, която приема сума - рестото, което трябва да се върне и изчислява с колко най-малко монети може да стане това.
double change = double.Parse(Console.ReadLine());

double changeInPennies = Math.Floor(change * 100);

int coins = 0;
while (changeInPennies > 0)
{
    if (changeInPennies >= 200)
        changeInPennies -= 200;
    else if (changeInPennies >= 100)
        changeInPennies -= 100;
    else if (changeInPennies >= 50)
        changeInPennies -= 50;
    else if (changeInPennies >= 20)
        changeInPennies -= 20;
    else if (changeInPennies >= 10)
        changeInPennies -= 10;
    else if (changeInPennies >= 5)
        changeInPennies -= 5;
    else if (changeInPennies >= 2)
        changeInPennies -= 2;
    else if (changeInPennies >= 1)
        changeInPennies -= 1;
    coins++;
}
Console.WriteLine(coins);
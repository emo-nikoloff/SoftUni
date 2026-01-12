// Гошо работи в ресторант и отговаря за зареждането на съдомиялната накрая на деня.
// Вашата задача е да напишете програма, която изчислява, дали дадено закупено количество бутилки от препарат за съдомиялна е достатъчно, за да измие определено количество съдове.
// Знае се, че всяка бутилка съдържа 750 мл. препарат, за 1 чиния са нужни 5 мл., а за тенджера 15 мл.
// Приемете, че на всяко трето зареждане със съдове, съдомиялната се пълни само с тенджери, а останалите пъти с чинии.
// Докато не получите команда "End" ще продължите да получавате бройка съдове, които трябва да бъдат измити.
int cleanerBottles = int.Parse(Console.ReadLine());

int cleaner = cleanerBottles * 750;

string input = Console.ReadLine();
int dishes = 0;
int platesSum = 0;
int potsSum = 0;
while (input != "End")
{
    dishes++;
    int numberDishes = int.Parse(input);
    if (dishes % 3 == 0)
    {
        potsSum += numberDishes;
        numberDishes *= 15;
    }
    else
    {
        platesSum += numberDishes;
        numberDishes *= 5;
    }

    if (cleaner < numberDishes)
    {
        Console.WriteLine($"Not enough detergent, {Math.Abs(cleaner - numberDishes)} ml. more necessary!");
        break;
    }
    cleaner -= numberDishes;
    input = Console.ReadLine();
}

if (input == "End")
{
    Console.WriteLine("Detergent was enough!");
    Console.WriteLine($"{platesSum} dishes and {potsSum} pots were washed.");
    Console.WriteLine($"Leftover detergent {cleaner} ml.");
}
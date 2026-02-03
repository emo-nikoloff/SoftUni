// В кутия имаме неопределен брой топки с различни цветове, които ни носят различен брой точки.
// Задачата ни е да извадим Х бр. топки, които ще бъдат въведени от конзолата, като се има в предвид, че всеки различен цвят влияе на точките ни по следния начин:
// •	Ако топката е “red” точките ни се повишават с 5.
// •	Ако топката е “orange” точките ни се повишават с 10.
// •	Ако топката е “yellow” точките ни се повишават с 15.
// •	Ако топката е “white” точките ни се повишават с 20.
// •	Ако топката е “black” точките ни се делят на 2, като закръгляме към по-малкото цяло число.
// Ако топката е с какъвто и да е цвят, различен от по-горните, точките не се манипулират и програмата продължава да работи.
int balls = int.Parse(Console.ReadLine());

int totalPoints = 0, redBalls = 0, orangeBalls = 0, yellowBalls = 0, whiteBalls = 0, otherBalls = 0, blackBalls = 0;
for (int ballsCounter = 1; ballsCounter <= balls; ballsCounter++)
{
    string ballColour = Console.ReadLine();

    if (ballColour == "red")
    {
        redBalls++;
        totalPoints += 5;
    }
    else if (ballColour == "orange")
    {
        orangeBalls++;
        totalPoints += 10;
    }
    else if (ballColour == "yellow")
    {
        yellowBalls++;
        totalPoints += 15;
    }
    else if (ballColour == "white")
    {
        whiteBalls++;
        totalPoints += 20;
    }
    else if (ballColour == "black")
    {
        blackBalls++;
        totalPoints /= 2;
    }
    else
    {
        otherBalls++;
    }
}
Console.WriteLine($"Total points: {totalPoints}");
Console.WriteLine($"Red balls: {redBalls}");
Console.WriteLine($"Orange balls: {orangeBalls}");
Console.WriteLine($"Yellow balls: {yellowBalls}");
Console.WriteLine($"White balls: {whiteBalls}");
Console.WriteLine($"Other colors picked: {otherBalls}");
Console.WriteLine($"Divides from black balls: {blackBalls}");
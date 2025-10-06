// Напишете програма, която отпечатва часовете в денонощието от 0:0 до 23:59, всеки на отделен ред. Часовете трябва да се изписват във формат "{час}:{минути}".
for (int hours = 0; hours < 24; hours++)
{
    for (int minutes = 0; minutes < 60; minutes++)
        Console.WriteLine($"{hours}:{minutes}");
}
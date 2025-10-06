// Напишете програма, която да отпечатва часовете в денонощието от 0:0:0 до 23:59:59, всеки на отделен ред.
// Часовете да се изписват във формат "{час} : {минути} : {секунди} ".
for (int hours = 0; hours < 24; hours++)
{
    for (int minutes = 0; minutes < 60; minutes++)
    {
        for (int seconds = 0; seconds < 60; seconds++)
            Console.WriteLine($"{hours} : {minutes} : {seconds}");
    }
}
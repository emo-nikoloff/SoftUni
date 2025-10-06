// Пепи иска да напишете програма, чрез която да разбере кой е най-добрият играч от световното първенство. Информацията, която получавате ще бъде играч и колко гола е отбелязал.
// От вас се иска да отпечатате кой е играчът с най-много голове и дали е направил хет-трик. Хет-трик е, когато футболистът е вкарал 3 или повече гола.
// Ако футболистът е вкарал 10 или повече гола, програмата трябва да спре.
string player = Console.ReadLine();

int highestGoals = int.MinValue;
string bestPlayer = "";
while (player != "END")
{
    int goals = int.Parse(Console.ReadLine());
    if (goals > highestGoals)
    {
        highestGoals = goals;
        bestPlayer = player;
    }
    if (goals >= 10)
        break;
    player = Console.ReadLine();
}
Console.WriteLine($"{bestPlayer} is the best player!");
if (highestGoals >= 3)
    Console.WriteLine($"He has scored {highestGoals} goals and made a hat-trick !!!");
else
    Console.WriteLine($"He has scored {highestGoals} goals.");
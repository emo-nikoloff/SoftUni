// Габи иска да започне здравословен начин на живот и си е поставила за цел да върви 10 000 стъпки всеки ден.
// Някои дни обаче е много уморена от работа и ще иска да се прибере преди да постигне целта си.
// Напишете програма, която чете от конзолата по колко стъпки изминава тя всеки път като излиза през деня и когато постигне целта си да се изписва
// "Goal reached! Good job!"  и колко стъпки повече е извървяла "{разликата между стъпките} steps over the goal!".
// Ако иска да се прибере преди това, тя ще въведе командата "Going home" и ще въведе стъпките, които е извървяла докато се прибира. След което, ако не е успяла да постигне целта си, на конзолата трябва да се изпише: "{разликата между стъпките} more steps to reach goal."
const int goal = 10000;
int steps = 0;

string input = Console.ReadLine();

while (input != "Going home")
{
    int stepsToGoal = int.Parse(input);
    steps += stepsToGoal;

    if (steps > goal)
    {
        steps -= goal;
        break;
    }
    input = Console.ReadLine();
}

if (input == "Going home")
{
    int stepsToGoal = int.Parse(Console.ReadLine());
    steps += stepsToGoal;
    if (steps > goal)
    {
        steps -= goal;
        Console.WriteLine("Goal reached! Good job!");
        Console.WriteLine($"{steps} steps over the goal!");
    }
    else
        Console.WriteLine($"{Math.Abs(steps - goal)} more steps to reach goal.");
}
else
{
    Console.WriteLine("Goal reached! Good job!");
    Console.WriteLine($"{steps} steps over the goal!");
}
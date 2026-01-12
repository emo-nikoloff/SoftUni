// Студент трябва да отиде на изпит в определен час (например в 9:30 часа). Той идва в изпитната зала в даден час на пристигане (например 9:40).
// Счита се, че студентът е дошъл навреме, ако е пристигнал в часа на изпита или до половин час преди това. Ако е пристигнал по-рано повече от 30 минути, той е подранил.
// Ако е дошъл след часа на изпита, той е закъснял.
// Напишете програма, която прочита време на изпит и време на пристигане и отпечатва дали студентът е дошъл навреме,
// дали е подранил или е закъснял и с колко часа или минути е подранил или закъснял.
int examHour = int.Parse(Console.ReadLine());
int examMinute = int.Parse(Console.ReadLine());
int arrivalHour = int.Parse(Console.ReadLine());
int arrivalMinute = int.Parse(Console.ReadLine());

int examTime = examHour * 60 + examMinute;
int arrivalTime = arrivalHour * 60 + arrivalMinute;

int diff = Math.Abs(arrivalTime - examTime);
int hour = 0;

if (arrivalTime > examTime)
{
    if (diff >= 60)
    {
        hour = diff / 60;
        diff %= 60;

        if (diff < 10)
        {
            Console.WriteLine("Late");
            Console.WriteLine($"{hour}:0{diff} hours after the start");
        }
        else
        {
            Console.WriteLine("Late");
            Console.WriteLine($"{hour}:{diff} hours after the start");
        }
    }
    else
    {
        Console.WriteLine("Late");
        Console.WriteLine($"{diff} minutes after the start");
    }
}
else if (arrivalTime == examTime || diff <= 30)
{
    if (diff == 0)
        Console.WriteLine("On Time");
    else
    {
        Console.WriteLine("On Time");
        Console.WriteLine($"{diff} minutes before the start");
    }
}
else
{
    hour = diff / 60;
    diff %= 60;

    if (hour == 0)
    {
        Console.WriteLine("Early");
        Console.WriteLine($"{diff} minutes before the start");
    }
    else if (diff < 10)
    {
        Console.WriteLine("Early");
        Console.WriteLine($"{hour}:0{diff} hours before the start");
    }
    else
    {
        Console.WriteLine("Early");
        Console.WriteLine($"{hour}:{diff} hours before the start");
    }
}
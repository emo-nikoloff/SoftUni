// Поканени сте от академията да напишете софтуер, който да пресмята точките за актьор/актриса. Академията ще ви даде първоначални точки за актьора.
// След това всеки оценяващ ще дава своята оценка. Точките, които актьора получава се формират от: дължината на името на оценяващия умножено по точките, които дава делено на две. 
// Ако резултатът в някой момент надхвърли 1250.5 програмата трябва да прекъсне и да се отпечата, че дадения актьор е получил номинация.
string name = Console.ReadLine();
double points = double.Parse(Console.ReadLine());
int referees = int.Parse(Console.ReadLine());

double neededPoints = 1250.5;
for (int i = 0; i < referees && points <= neededPoints; i++)
{
    string referee = Console.ReadLine();
    double refereePoints = double.Parse(Console.ReadLine());

    int lengthRefereeName = referee.Length;
    points += ((lengthRefereeName * refereePoints) / 2);
}

if (points > neededPoints)
{
    Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {points:f1}!");
}
else
{
    Console.WriteLine($"Sorry, {name} you need {Math.Abs(points - neededPoints):f1} more!");
}
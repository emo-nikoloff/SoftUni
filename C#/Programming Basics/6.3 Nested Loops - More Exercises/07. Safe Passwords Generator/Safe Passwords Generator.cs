// Ани се страхува от това, да не й бъде хакнат някой от профилите в социалните мрежи, затова решава да направи генератор за пароли, които да бъдат достатъчно сигурни.
// Вашата задача е да й помогнете да напише програма, която ще генерира тези пароли, разделени една от друга от знака "|".
// Да се напише програма, която генерира серия от символи като в шаблона:
//                                                          ABxyBA
// като при всяко генериране на нов код, стойностите на символите се увеличават с 1. Ако A надхвърли 55, се връща на 35. Ако B надхвърли 96, се връща на 64.
int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int maxPasswords = int.Parse(Console.ReadLine());

int A = 35;
int B = 64;
int passwordCounter = 0;
for (int x = 1; x <= a; x++)
{
    for (int y = 1; y <= b; y++)
    {
        if (passwordCounter >= maxPasswords) return;
        if (A > 55) A = 35;
        if (B > 96) B = 64;
        Console.Write($"{(char)A}{(char)B}{x}{y}{(char)B}{(char)A}|");
        A++;
        B++;
        if (x == a && y == b) return;
        passwordCounter++;
    }
}
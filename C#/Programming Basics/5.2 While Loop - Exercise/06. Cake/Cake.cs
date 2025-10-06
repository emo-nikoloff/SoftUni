// Поканени сте на 30-ти рожден ден, на който рожденикът черпи с огромна торта. Той обаче не знае колко парчета могат да си вземат гостите от нея.
// Вашата задача е да напишете програма, която изчислява броя на парчетата, които гостите са взели, преди тя да свърши.
// Ще получите размерите на тортата (широчина и дължина – цели числа в интервала [1...1000]) и след това на всеки ред, до получаване на командата "STOP"
// или докато не свърши тортата, броят на парчетата, които гостите вземат от нея. 
// Бележка: Едно парче торта е с размер 1х1 см.
int lengthPiece = int.Parse(Console.ReadLine());
int widthPiece = int.Parse(Console.ReadLine());

int pieces = lengthPiece * widthPiece;

string input = Console.ReadLine();
while (input != "STOP")
{
    int piecesCake = int.Parse(input);
    pieces -= piecesCake;

    if (pieces <= 0)
    {
        Console.WriteLine($"No more cake left! You need {Math.Abs(pieces)} pieces more.");
        break;
    }
    input = Console.ReadLine();
}
if (input == "STOP")
    Console.WriteLine($"{pieces} pieces are left.");
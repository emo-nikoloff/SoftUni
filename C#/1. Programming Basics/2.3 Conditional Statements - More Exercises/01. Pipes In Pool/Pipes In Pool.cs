// Басейн с обем V има две тръби от които се пълни. Всяка тръба има определен дебит (литрите вода минаващи през една тръба за един час).
// Работникът пуска тръбите едновременно и излиза за N часа. Напишете програма, която изкарва състоянието на басейна, в момента, когато работникът се върне. 
int poolVolume = int.Parse(Console.ReadLine());
int pipe1 = int.Parse(Console.ReadLine());
int pipe2 = int.Parse(Console.ReadLine());
double hoursAbsent = double.Parse(Console.ReadLine());

double pipe1Litres = pipe1 * hoursAbsent;
double pipe2Litres = pipe2 * hoursAbsent;
double sumLitres = pipe1Litres + pipe2Litres;

if (sumLitres > poolVolume)
{
    Console.WriteLine($"For {hoursAbsent:f2} hours the pool overflows with {sumLitres - poolVolume:f2} liters.");
}
else
{
    Console.WriteLine($"The pool is {(sumLitres / poolVolume) * 100:f2}% full. Pipe 1: {(pipe1Litres / sumLitres) * 100:f2}%. Pipe 2: {(pipe2Litres / sumLitres) * 100:f2}%.");
}
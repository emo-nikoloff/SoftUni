// Напишете програма, която изчислява каква сума ще получите в края на депозитния период при определен лихвен процент.
// Използвайте следната формула: сума = депозирана сума  + срок на депозита * ((депозирана сума * годишен лихвен процент ) / 12)
double depositSum = double.Parse(Console.ReadLine());
int depositTerm = int.Parse(Console.ReadLine());
double annualInterestRate = double.Parse(Console.ReadLine());

double sum = depositSum + depositTerm * ((depositSum * (annualInterestRate * 0.01)) / 12);
Console.WriteLine(sum);
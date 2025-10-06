// Напишете програма, която до получаване на командата "Stop", чете цели числа, въведени от потребителя и намира най-малкото измежду тях. Въвежда се по едно число на ред. 
string input = Console.ReadLine();
int min = int.MaxValue;
while (input != "Stop")
{
    int n = int.Parse(input);
    if (n < min)
        min = n;
    input = Console.ReadLine();
}
Console.WriteLine(min);
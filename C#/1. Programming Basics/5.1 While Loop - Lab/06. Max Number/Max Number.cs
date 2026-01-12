// Напишете програма, която до получаване на командата "Stop", чете цели числа, въведени от потребителя и намира най-голямото измежду тях. Въвежда се по едно число на ред. 
string input = Console.ReadLine();
int max = int.MinValue;
while (input != "Stop")
{
    int n = int.Parse(input);
    if (n > max)
        max = n;
    input = Console.ReadLine();
}
Console.WriteLine(max);
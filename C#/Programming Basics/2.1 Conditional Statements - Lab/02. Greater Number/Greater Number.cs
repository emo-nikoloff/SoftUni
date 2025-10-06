// Да се напише програма, която чете две цели числа въведени от потребителя и отпечатва по-голямото от двете.
int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());
if (number1 > number2)
{
    Console.WriteLine(number1);
}
else
{
    Console.WriteLine(number2);
}
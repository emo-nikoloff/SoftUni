// Напишете програма, която чете текст от конзолата (стринг) и го принтира, докато не получи командата "Stop".
string input = Console.ReadLine();

while (input != "Stop")
{
    Console.WriteLine(input);
    input = Console.ReadLine();
}
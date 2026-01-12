// Младоженците искат да направят списък кой на кое място ще седи на сватбената церемония. Местата са разделени на различни сектори.
// Секторите са главните латински букви като започват от A. Във всеки сектор има определен брой редове.
// От конзолата се чете броят на редовете в първия сектор (A), като във всеки следващ сектор редовете се увеличават с 1.
// На всеки ред има определен брой места - тяхната номерация е представена с малките латински букви.
// Броя на местата на нечетните редове се прочита от конзолата, а на четните редове местата са с 2 повече.
char lastSector = char.Parse(Console.ReadLine());
int rowsInFirstSector = int.Parse(Console.ReadLine());
int seatsInOddRows = int.Parse(Console.ReadLine());

int seats = 0;
for (char sector = 'A'; sector <= lastSector; sector++)
{
    for (int row = 1; row <= rowsInFirstSector; row++)
    {
        int seatsInRow = seatsInOddRows;
        if (row % 2 == 0)
            seatsInRow += 2;

        for (char seat = 'a'; seat < 'a' + seatsInRow; seat++)
        {
            Console.WriteLine($"{sector}{row}{seat}");
            seats++;
        }
    }
    rowsInFirstSector++;
}
Console.WriteLine(seats);
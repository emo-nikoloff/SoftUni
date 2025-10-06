// Вашата задача е да напишете програма, която да изчислява процента на билетите за всеки тип от продадените билети:
// студентски(student), стандартен(standard) и детски(kid), за всички прожекции.
// Трябва да изчислите и колко процента от залата е запълнена за всяка една прожекция.
string movie = Console.ReadLine();

double tickets = 0, studentTickets = 0, standardTickets = 0, kidTickets = 0;
while (movie != "Finish")
{
    int capacity = int.Parse(Console.ReadLine());
    double soldStudentTickets = 0, soldStandardTickets = 0, soldKidTickets = 0;

    for (int i = 1; i <= capacity; i++)
    {
        string ticket = Console.ReadLine();

        if (ticket == "End")
            break;
        if (ticket == "student")
        {
            studentTickets++;
            soldStudentTickets++;
        }
        else if (ticket == "standard")
        {
            standardTickets++;
            soldStandardTickets++;
        }
        else if (ticket == "kid")
        {
            kidTickets++;
            soldKidTickets++;
        }
        tickets++;
    }
    Console.WriteLine($"{movie} - {((soldStudentTickets + soldStandardTickets + soldKidTickets) / capacity) * 100:f2}% full.");
    movie = Console.ReadLine();
}
Console.WriteLine($"Total tickets: {tickets}");
Console.WriteLine($"{(studentTickets / tickets) * 100:f2}% student tickets.");
Console.WriteLine($"{(standardTickets / tickets) * 100:f2}% standard tickets.");
Console.WriteLine($"{(kidTickets / tickets) * 100:f2}% kids tickets.");
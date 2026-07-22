// Вашата задача е да напишете програма, която да изчислява процента на билетите за всеки тип от продадените билети: студентски(student), стандартен(standard) и детски(kid),
// за всички прожекции. Трябва да изчислите и колко процента от залата е запълнена за всяка една прожекция.
string movie = Console.ReadLine();

double studentTicket = 0, standardTicket = 0, kidTicket = 0;
while (movie != "Finish")
{
    int seats = int.Parse(Console.ReadLine());

    double soldTickets = 0;
    for (int seat = 1; seat <= seats; seat++)
    {
        string ticketType = Console.ReadLine();

        if (ticketType == "student")
        {
            studentTicket++;
            soldTickets++;
        }
        else if (ticketType == "standard")
        {
            standardTicket++;
            soldTickets++;
        }
        else if (ticketType == "kid")
        {
            kidTicket++;
            soldTickets++;
        }

        if (ticketType == "End")
            break;
    }
    Console.WriteLine($"{movie} - {soldTickets / seats:p2} full.");
    movie = Console.ReadLine();
}
Console.WriteLine($"Total tickets: {studentTicket + standardTicket + kidTicket}");
Console.WriteLine($"{studentTicket / (studentTicket + standardTicket + kidTicket):p2} student tickets.");
Console.WriteLine($"{standardTicket / (studentTicket + standardTicket + kidTicket):p2} standard tickets.");
Console.WriteLine($"{kidTicket / (studentTicket + standardTicket + kidTicket):p2} kids tickets.");
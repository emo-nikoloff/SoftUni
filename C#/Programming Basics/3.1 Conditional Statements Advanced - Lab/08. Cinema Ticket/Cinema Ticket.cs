// Да се напише програма която чете ден от седмицата (текст) – въведен от потребителя и принтира на конзолата цената на билет за кино според деня от седмицата:
// Monday   Tuesday   Wednesday   Thursday   Friday   Saturday   Sunday
// 12       12        14          14         12       16         16
string dayOfWeek = Console.ReadLine();
int ticketPrice = 0;

if (dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Friday")
    ticketPrice = 12;
else if (dayOfWeek == "Wednesday" || dayOfWeek == "Thursday")
    ticketPrice = 14;
else if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
    ticketPrice = 16;

/*switch (dayOfWeek)
{
    case "Monday":
    case "Tuesday":
    case "Friday":
        ticketPrice = 12;
        break;
    case "Wednesday":
    case "Thursday":
        ticketPrice = 14;
        break;
    case "Saturday":
    case "Sunday":
        ticketPrice = 16;
        break;
}*/

Console.WriteLine(ticketPrice);
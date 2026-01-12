// Напишете програма която, чете ден от седмицата (текст), на английски език - въведен от потребителя.
// Ако денят е работен отпечатва на конзолата - "Working day", ако е почивен - "Weekend". Ако се въведе текст различен от ден от седмицата да се отпечата - "Error".
string dayOfWeek = Console.ReadLine();

string output = "";
switch (dayOfWeek)
{
    case "Monday":
    case "Tuesday":
    case "Wednesday":
    case "Thursday":
    case "Friday":
        output = "Working day";
        break;
    case "Saturday":
    case "Sunday":
        output = "Weekend";
        break;
    default:
        output = "Error";
        break;
}
Console.WriteLine(output);
// Напишете програма, която чете цяло число, въведено от потребителя, и отпечатва ден от седмицата (на английски език), в граници [1...7]
// или отпечатва "Error" в случай, че въведеното число е невалидно. 
int dayOfWeek = int.Parse(Console.ReadLine());

string output = "";
switch (dayOfWeek)
{
    case 1:
        output = "Monday";
        break;
    case 2:
        output = "Tuesday";
        break;
    case 3:
        output = "Wednesday";
        break;
    case 4:
        output = "Thursday";
        break;
    case 5:
        output = "Friday";
        break;
    case 6:
        output = "Saturday";
        break;
    case 7:
        output = "Sunday";
        break;
    default:
        output = "Error";
        break;
}
Console.WriteLine(output);
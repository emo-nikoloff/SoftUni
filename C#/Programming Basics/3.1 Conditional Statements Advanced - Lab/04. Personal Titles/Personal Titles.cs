// Да се напише конзолна програма, която прочита възраст (реално число) и пол ('m' или 'f'), въведени от потребителя, и отпечатва обръщение измежду следните:
// •	"Mr." – мъж(пол 'm') на 16 или повече години
// •	"Master" – момче (пол 'm') под 16 години
// •	"Ms." – жена (пол 'f') на 16 или повече години
// •	"Miss" – момиче (пол 'f') под 16 години
double age = double.Parse(Console.ReadLine());
string gender = Console.ReadLine();

string title = "";
if (gender == "f")
{
    if (age < 16)
        title = "Miss";
    else
        title = "Ms.";
}
else if (gender == "m")
{
    if (age < 16)
        title = "Master";
    else
        title = "Mr.";
}
Console.WriteLine(title);
// Напишете програма, която прочита от конзолата име, фамилия, възраст и град и печата следното съобщение: "You are <firstName> <lastName>, a <age>-years old person from <town>."
string nameFirst = Console.ReadLine();
string nameLast = Console.ReadLine();
int years = int.Parse(Console.ReadLine());
string town = Console.ReadLine();
Console.WriteLine($"You are {nameFirst} {nameLast}, a {years}-years old person from {town}.");
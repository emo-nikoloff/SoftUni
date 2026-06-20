// Напишете програма, която изчислява печалбата на агенция за продажба на самолетни билети. Агенцията продава самолетни билети на различни авиокомпании.
// Ще получите информация за броя продадени билети за възрастни и броя продадени детски билети.
// Нетната цена на билета за възрастен се определя от авиокомпанията, а детският билет е със 70% по-евтин. Агенцията добавя към нетната цена на всеки билет такса обслужване.
// Крайната печалба на Агенцията е 20% от общата цена на всички билети.
string aviocompany = Console.ReadLine();
int adultTickets = int.Parse(Console.ReadLine());
int kidTickets = int.Parse(Console.ReadLine());
double adultTicketPrice = double.Parse(Console.ReadLine());
double servicePrice = double.Parse(Console.ReadLine());

double kidTicketPrice = adultTicketPrice - (adultTicketPrice * 0.7);
adultTicketPrice += servicePrice;
kidTicketPrice += servicePrice;

Console.WriteLine($"The profit of your agency from {aviocompany} tickets is {((kidTickets * kidTicketPrice) + (adultTickets * adultTicketPrice)) * 0.2:f2} lv.");
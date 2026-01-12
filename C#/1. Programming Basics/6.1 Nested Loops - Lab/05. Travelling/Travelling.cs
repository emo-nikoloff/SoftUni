// Ани обича да пътува и иска тази година да посети няколко различни дестинации.
// Като си избере дестинация, ще прецени колко пари ще й трябват, за да отиде до там и ще започне да спестява. Когато е спестила достатъчно, ще може да пътува.
string destination = Console.ReadLine();

while (destination != "End")
{
    double budget = double.Parse(Console.ReadLine());

    double sum = 0;
    while (sum < budget)
    {
        double money = double.Parse(Console.ReadLine());
        sum += money;
    }
    Console.WriteLine($"Going to {destination}!");

    destination = Console.ReadLine();
}
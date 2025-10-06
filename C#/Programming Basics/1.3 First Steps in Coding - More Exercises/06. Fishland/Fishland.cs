// Георги ще има гости вечерта и решава да ги нагости с паламуд, сафрид и миди. Затова отива на рибната борса, за да си купи по няколко килограма.
// Oт конзолата се въвеждат цените в лева на скумрията и цацата. Също количеството на паламуд, сафрид и миди в килограми.
// Колко пари ще са му необходими, за да плати сметката си, ако цените на борсата са:
// •	Паламуд – 60% по-скъп от скумрията
// •	Сафрид – 80% по-скъп от цацата
// •	Миди – 7.50 лв. за килограм
double mackerelPrice = double.Parse(Console.ReadLine());
double spratPrice = double.Parse(Console.ReadLine());

double beltedBonitoPrice = mackerelPrice + mackerelPrice * 0.6;
double beltedBonitoKg = double.Parse(Console.ReadLine());
double beltedBonitoTotal = beltedBonitoKg * beltedBonitoPrice;
double scadPrice = spratPrice + spratPrice * 0.8;
double scadKg = double.Parse(Console.ReadLine());
double scadTotal = scadKg * scadPrice;
double clamPrice = 7.5;
double clamKg = double.Parse(Console.ReadLine());
double clamTotal = clamKg * clamPrice;

double totalPrice = beltedBonitoTotal + scadTotal + clamTotal;
Console.WriteLine($"{totalPrice:f2}");
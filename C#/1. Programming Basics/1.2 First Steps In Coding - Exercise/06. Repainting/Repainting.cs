// Румен иска да пребоядиса хола и за целта е наел майстори. Напишете програма, която изчислява разходите за ремонта, предвид следните цени:
// •	Предпазен найлон - 1.50 лв. за кв. метър
// •	Боя - 14.50 лв. за литър
// •	Разредител за боя - 5.00 лв. за литър
// За всеки случай, към необходимите материали, Румен иска да добави още 10% от количеството боя и 2 кв.м. найлон, разбира се и 0.40 лв. за торбички.
// Сумата, която се заплаща на майсторите за 1 час работа, е равна на 30% от сбора на всички разходи за материали.
double nylonPrice = 1.50;
double paintPrice = 14.50;
double paintThinnerPrice = 5;

int nylon = int.Parse(Console.ReadLine());
int paint = int.Parse(Console.ReadLine());
int paintThinner = int.Parse(Console.ReadLine());
int workersHours = int.Parse(Console.ReadLine());

double totalNylonPrice = (nylon + 2) * nylonPrice;
double totalPaintPrice = (paint * 1.1) * paintPrice;
double totalPaintThinnerPrice = paintThinner * paintThinnerPrice;
double totalItemsSum = totalNylonPrice + totalPaintPrice + totalPaintThinnerPrice + 0.4;
double workersSalaryPerHour = totalItemsSum * 0.3;
double totalWorkersSalary = workersHours * workersSalaryPerHour;

double total = totalItemsSum + totalWorkersSalary;
Console.WriteLine(total);
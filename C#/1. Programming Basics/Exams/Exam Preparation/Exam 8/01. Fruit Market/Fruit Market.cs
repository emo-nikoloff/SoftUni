// Мария решава да мине на диета и отива до близкия пазар, за да купи ягоди, банани, портокали и малини.
// На конзолата се въвежда цената на ягодите в лв./кг. и количеството на бананите, портокалите, малините и ягодите, които трябва да закупи.
// Да се напише програма, която пресмята колко пари са ѝ необходими за да плати сметката, като знаете, че:
// •	цената на малините е на половина по-ниска от тази на ягодите;
// •	цената на портокалите е с 40% по-ниска от цената на малините;
// •	цената на бананите е с 80% по-ниска от цената на малините. 
double strawberriesPrice = double.Parse(Console.ReadLine());
double bananasKG = double.Parse(Console.ReadLine());
double orangesKG = double.Parse(Console.ReadLine());
double raspberriesKG = double.Parse(Console.ReadLine());
double strawberriesKG = double.Parse(Console.ReadLine());

double raspberriesPrice = strawberriesPrice / 2;
double orangesPrice = raspberriesPrice - (0.4 * raspberriesPrice);
double bananasPrice = raspberriesPrice - (0.8 * raspberriesPrice);

double raspberriesSum = raspberriesKG * raspberriesPrice;
double orangesSum = orangesKG * orangesPrice;
double bananasSum = bananasKG * bananasPrice;
double strawberriesSum = strawberriesKG * strawberriesPrice;
double sum = raspberriesSum + orangesSum + bananasSum + strawberriesSum;

Console.WriteLine($"{sum:f2}");
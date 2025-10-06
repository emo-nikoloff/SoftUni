// Петър иска да купи N видеокарти, M процесора и P на брой рам памет. Ако броя на видеокартите е по-голям от този на процесорите получава 15% отстъпка от крайната сметка.
// Важат следните цени:
// •	Видеокарта – 250 лв./бр.
// •	Процесор – 35% от цената на закупените видеокарти/бр.
// •	Рам памет – 10% от цената на закупените видеокарти/бр.
// Да се изчисли нужната сума за закупуване на материалите и да се пресметне дали бюджета ще му стигне.
double budget = double.Parse(Console.ReadLine());
int gpu = int.Parse(Console.ReadLine());
int cpu = int.Parse(Console.ReadLine());
int ram = int.Parse(Console.ReadLine());

int gpuPrice = 250;
double cpuPrice = 0.35 * (gpu * gpuPrice);
double ramPrice = 0.1 * (gpu * gpuPrice);

double sum = gpu * gpuPrice + cpu * cpuPrice + ram * ramPrice;

if (gpu > cpu)
    sum = sum - (sum * 0.15);

double money = Math.Abs(sum - budget);

if (sum <= budget)
    Console.WriteLine($"You have {money:f2} leva left!");
else
    Console.WriteLine($"Not enough money! You need {money:f2} leva more!");
// За да са здрави котките, храненето им трябва да следва определена диета.
// Напишете програма, която изчислява котешкото процентно разпределение на макроелементите в храната за един ден и пресмята колко средно калории дава един грам от тази храна.
// Макроелементите са: мазнини, протеини и въглехидрати.
// Разполагате с общия брой калории, които котката трябва да приеме за един ден.
// Известно е, че:
// •	1 грам мазнини = 9 калории
// •	1 грам протеини = 4 калории
// •	1 грам въглехидрати = 4 калории
// За да разберете колко калории дава един грам храна на котката, ще трябва да направите изчисления с реалното тегло на храната, тъй като тя съдържа вода.
// Трябва да се изчислят грамовете на мазнините, протеините и въглехидратите. Тяхната сума дава общото тегло на храната и от него трябва да извадим процентите вода. 
int fatsPercentage = int.Parse(Console.ReadLine());
int proteinsPercentage = int.Parse(Console.ReadLine());
int carbohydratesPercentage = int.Parse(Console.ReadLine());
double calories = double.Parse(Console.ReadLine());
double waterContent = double.Parse(Console.ReadLine());

double fatsGrams = (((double)fatsPercentage / 100) * calories) / 9;
double proteinsGrams = (((double)proteinsPercentage / 100) * calories) / 4;
double carbohydratesGrams = (((double)carbohydratesPercentage / 100) * calories) / 4;
double foodGrams = fatsGrams + proteinsGrams + carbohydratesGrams;
calories /= foodGrams;
waterContent = 100 - waterContent;
waterContent = (waterContent / 100) * calories;
Console.WriteLine($"{waterContent:f4}");
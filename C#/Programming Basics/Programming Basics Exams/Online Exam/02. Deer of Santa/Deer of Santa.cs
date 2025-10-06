// Дядо Коледа много обича да пътешества, но за съжаление се случило, така че точно преди да замине на почивка три от елените му се разболяли и трябва да ги остави.
// Когато заминава, той трябва да съобрази колко храна да остави на всеки един от елените, за да не останат гладни.
// Напишете програма, която пресмята дали оставената от Дядо Коледа храна ще е достатъчна за времето, в което него няма да го има.
// Всеки елен изяжда определено количество храна на ден.
int daysAbsend = int.Parse(Console.ReadLine());
int leftFood = int.Parse(Console.ReadLine());
double foodForDeer1 = double.Parse(Console.ReadLine());
double foodForDeer2 = double.Parse(Console.ReadLine());
double foodForDeer3 = double.Parse(Console.ReadLine());

if ((daysAbsend * foodForDeer1) + (daysAbsend * foodForDeer2) + (daysAbsend * foodForDeer3) > leftFood)
    Console.WriteLine($"{Math.Ceiling(Math.Abs(leftFood - ((daysAbsend * foodForDeer1) + (daysAbsend * foodForDeer2) + (daysAbsend * foodForDeer3))))} more kilos of food are needed.");
else
    Console.WriteLine($"{Math.Floor(leftFood - ((daysAbsend * foodForDeer1) + (daysAbsend * foodForDeer2) + (daysAbsend * foodForDeer3)))} kilos of food left.");
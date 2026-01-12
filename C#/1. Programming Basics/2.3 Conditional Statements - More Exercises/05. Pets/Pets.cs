// Марина обича да пътува. Тя има 3 домашни любимеца (куче, котка и костенурка). Когато заминава на пътешествие трябва да съобрази колко храна да им остави, за да не останат гладни.
// Напишете програма, която пресмята колко килограма храна ще изядат всички за времето, в което Марина отсъства и дали оставената храна от нея ще им е достатъчна.
// Всяко животно изяжда определено количество храна на ден.
int daysAbsent = int.Parse(Console.ReadLine());
int leftFood = int.Parse(Console.ReadLine());
double dogFood = double.Parse(Console.ReadLine());
double catFood = double.Parse(Console.ReadLine());
double turtleFood = double.Parse(Console.ReadLine());

dogFood *= daysAbsent;
catFood *= daysAbsent;
turtleFood *= daysAbsent;
double foodTotal = dogFood + catFood + (turtleFood / 1000);

if (foodTotal < leftFood)
    Console.WriteLine($"{Math.Floor(Math.Abs(foodTotal - leftFood))} kilos of food left.");
else
{
    Console.WriteLine($"{Math.Ceiling(Math.Abs(foodTotal - leftFood))} more kilos of food are needed.");
}
// Напишете програма, която чете от конзолата число r и пресмята и отпечатва лицето и периметъра на кръг / окръжност с радиус r, като форматирате изхода в следния вид:
// "<calculated area>" "<calculated parameter>". Форматирайте изходните данни до втория знак след десетичната запетая.
double r = double.Parse(Console.ReadLine());

double area = Math.PI * r * r;
double parameter = 2 * Math.PI * r;
Console.WriteLine($"{area:f2}");
Console.WriteLine($"{parameter:f2}");
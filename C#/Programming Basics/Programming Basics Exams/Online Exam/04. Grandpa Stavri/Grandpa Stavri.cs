// Дядо Ставри има казан за ракия и всеки ден вари от любимата си напитка.
// Ако вари N дни и всеки ден получава различно количество ракия и алкохолен градус, да се намери за всички дни общото количество ракия и градуса на получената смес. 
int days = int.Parse(Console.ReadLine());

double rakiasSum = 0, degreesSum = 0, averageDegreesSum = 0;
for (int i = 1; i <= days; i++)
{
    double rakia = double.Parse(Console.ReadLine());
    double degree = double.Parse(Console.ReadLine());

    double sum = rakia * degree;
    rakiasSum += rakia;
    degreesSum += sum;
    averageDegreesSum = degreesSum / rakiasSum;
}
Console.WriteLine($"Liter: {rakiasSum:f2}");
Console.WriteLine($"Degrees: {averageDegreesSum:f2}");

if (averageDegreesSum < 38)
    Console.WriteLine("Not good, you should baking!");
else if (averageDegreesSum <= 42)
    Console.WriteLine("Super!");
else
    Console.WriteLine("Dilution with distilled water!");
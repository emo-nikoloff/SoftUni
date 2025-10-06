// Филмовата академия на САЩ от 1929г. ежегодно раздава награди Оскар на грандиозна церемония.
// Организаторите искат да разберат колко са разходите по организирането на една такава церемония.
// Напишете програма, която изчислява какви разходи ще има академията по организацията на събитието, като знаете колко е наемът на залата, в която ще се проведе. 
// •	Статуетки  – цената им е 30% по-малка от наема на залата
// •	Кетъринг – цената му е 15% по-малка от тази на статуетките
// •	Озвучаване – цената му е 1 / 2 от цената за кетъринг
int rentPrice = int.Parse(Console.ReadLine());
double statuettePrice = rentPrice - (rentPrice * 0.3);
double cateringPrice = statuettePrice - (statuettePrice * 0.15);
double soundCheckPrice = cateringPrice / 2;
double sum = rentPrice + statuettePrice + cateringPrice + soundCheckPrice;
Console.WriteLine($"{sum:f2}");
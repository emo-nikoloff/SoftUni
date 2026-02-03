// Мими има закупени самолетни билети, но в последствие решава да си добави багаж към тях.
// Таксите за багаж се изчисляват въз основа на теглото на чекирания багаж:
// •	до 10кг – 20% от цената на багаж над 20кг
// •	между 10кг и 20кг вкл. – 50% от цената на багаж над 20кг.
// •	над 20кг – таксата се чете от конзолата
// В зависимост от броя на дните, които остават до пътуването, цената се оскъпява:
// •	повече от 30 дни - цената на багажа се оскъпява с 10%
// •	между 7 и 30 дни вкл. - цената на багажа се оскъпява с 15%
// •	по-малко от 7 дни - цената на багажа се оскъпява с 40%
// Напишете програма, която пресмята колко ще трябва да заплати Мими, спрямо горните условия.
double luggageOver20KgPrice = double.Parse(Console.ReadLine());
double luggageKg = double.Parse(Console.ReadLine());
int daysUntillFlight = int.Parse(Console.ReadLine());
int luggages = int.Parse(Console.ReadLine());

if (luggageKg < 10)
    luggageOver20KgPrice *= 0.2;
else if (luggageKg <= 20)
    luggageOver20KgPrice *= 0.5;

if (daysUntillFlight < 7)
    luggageOver20KgPrice = luggageOver20KgPrice + (luggageOver20KgPrice * 0.4);
else if (daysUntillFlight <= 30)
    luggageOver20KgPrice = luggageOver20KgPrice + (luggageOver20KgPrice * 0.15);
else
    luggageOver20KgPrice = luggageOver20KgPrice + (luggageOver20KgPrice * 0.1);
Console.WriteLine($"The total price of bags is: {luggageOver20KgPrice * luggages:f2} lv.");
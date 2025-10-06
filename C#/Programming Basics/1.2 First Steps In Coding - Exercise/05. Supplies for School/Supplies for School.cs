// Учебната година вече е започнала и отговорничката на 10Б клас - Ани трябва да купи определен брой пакетчета с химикали, пакетчета с маркери, както и препарат за почистване на дъска.
// Тя е редовна клиентка на една книжарница, затова има намаление за нея, което представлява някакъв процент от общата сума.
// Напишете програма, която изчислява колко пари ще трябва да събере Ани, за да плати сметката, като имате предвид следния ценоразпис: 
// •	Пакет химикали - 5.80 лв. 
// •	Пакет маркери - 7.20 лв. 
// •	Препарат - 1.20 лв (за литър)
int penPackets = int.Parse(Console.ReadLine());
int markerPackets = int.Parse(Console.ReadLine());
int cleanerLiters = int.Parse(Console.ReadLine());
int discount = int.Parse(Console.ReadLine());

double penPacketsPrice = penPackets * 5.80;
double markerPacketsPrice = markerPackets * 7.20;
double cleanerPrice = cleanerLiters * 1.20;
double discountPrice = discount * 0.01;
double totalPrice = penPacketsPrice + markerPacketsPrice + cleanerPrice;

double totalPriceWithDiscount = totalPrice - (totalPrice * discountPrice);
Console.WriteLine(totalPriceWithDiscount);
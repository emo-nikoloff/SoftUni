// Напишете програма, която познава дали е топло или студено навън. От конзолата се чете един ред – текст, който подсказва какво е времето.
// При въвеждане на "sunny" трябва да се отпечата "It's warm outside!". Във всички останали случаи трябва да се отпечата "It's cold outside!". 
string weather = Console.ReadLine();

if (weather == "sunny")
    Console.WriteLine("It's warm outside!");
else
    Console.WriteLine("It's cold outside!");
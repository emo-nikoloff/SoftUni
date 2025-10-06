// За лятната ваканция в списъка със задължителна литература на Жоро има определен брой книги.
// Понеже Жоро предпочита да играе с приятели навън, вашата задача е да му помогнете да изчисли колко часа на ден трябва да отделя, за да прочете необходимата литература.
int pageCount = int.Parse(Console.ReadLine());
int pagesPerHour = int.Parse(Console.ReadLine());
int daysCount = int.Parse(Console.ReadLine());

int timeToReadTheBook = pageCount / pagesPerHour;

int hoursPerDay = timeToReadTheBook / daysCount;
Console.WriteLine(hoursPerDay);
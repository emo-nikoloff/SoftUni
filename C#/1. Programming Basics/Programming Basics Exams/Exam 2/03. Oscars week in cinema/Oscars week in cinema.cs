// По време на седмицата на Оскарите, градското кино пуска прожекции на някои от филмите, които са номинирани в категорията за "Най-добър филм".
// В таблицата са показани кои са филмите и каква е цената за прожекция спрямо залата, в която се прожектира филмът. 
// Филм                 normal	    luxury	     ultra luxury
// A Star Is Born	    7.50 лв.	10.50 лв.	 13.50 лв.
// Bohemian Rhapsody	7.35 лв.	9.45 лв.	 12.75 лв.
// Green Book	        8.15 лв.	10.25 лв.	 13.25 лв.
// The Favourite	    8.75 лв.	11.55 лв.	 13.95 лв.
// Напишете програма, която изчислява какъв е приходът от даден филм, като знаете в какъв тип зала се прожектира и колко човека са си купили билет за прожекцията.
string movie = Console.ReadLine();
string cinema = Console.ReadLine();
int tickets = int.Parse(Console.ReadLine());

double ticketsSold = 0;
switch (movie)
{
    case "A Star Is Born":
        switch (cinema)
        {
            case "normal":
                ticketsSold = tickets * 7.5;
                break;
            case "luxury":
                ticketsSold = tickets * 10.5;
                break;
            case "ultra luxury":
                ticketsSold = tickets * 13.5;
                break;
        }
        break;
    case "Bohemian Rhapsody":
        switch (cinema)
        {
            case "normal":
                ticketsSold = tickets * 7.35;
                break;
            case "luxury":
                ticketsSold = tickets * 9.45;
                break;
            case "ultra luxury":
                ticketsSold = tickets * 12.75;
                break;
        }
        break;
    case "Green Book":
        switch (cinema)
        {
            case "normal":
                ticketsSold = tickets * 8.15;
                break;
            case "luxury":
                ticketsSold = tickets * 10.25;
                break;
            case "ultra luxury":
                ticketsSold = tickets * 13.25;
                break;
        }
        break;
    case "The Favourite":
        switch (cinema)
        {
            case "normal":
                ticketsSold = tickets * 8.75;
                break;
            case "luxury":
                ticketsSold = tickets * 11.55;
                break;
            case "ultra luxury":
                ticketsSold = tickets * 13.95;
                break;
        }
        break;
}
Console.WriteLine($"{movie} -> {ticketsSold:f2} lv.");
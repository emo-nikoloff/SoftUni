using System.Diagnostics;
using System.Globalization;
using System.Text;

using BookShop.Data;
using BookShop.Models;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop;

public class StartUp
{
    public static void Main()
    {
        using var dbContext = new BookShopContext();
        //DbInitializer.ResetDatabase(dbContext);
        /*
        // Задача 2
        string ageCheck = Console.ReadLine()!;
        string ageRestrictedBooks = GetBooksByAgeRestriction(dbContext, ageCheck);
        Console.WriteLine(ageRestrictedBooks);
        
        // Задача 3
        string goldenBooks = GetGoldenBooks(dbContext);
        Console.WriteLine(goldenBooks);

        // Задача 4
        string booksByPrice = GetBooksByPrice(dbContext);
        Console.WriteLine(booksByPrice);

        // Задача 5
        int year = int.Parse(Console.ReadLine()!);
        string booksNotReleased = GetBooksNotReleasedIn(dbContext, year);
        Console.WriteLine(booksNotReleased);

        // Задача 6
        string categoryCheck = Console.ReadLine()!;
        string booksByCategory = GetBooksByCategory(dbContext, categoryCheck);
        Console.WriteLine(booksByCategory);

        // Задача 7
        string dateInput = Console.ReadLine()!;
        string booksReleasedBefore = GetBooksReleasedBefore(dbContext, dateInput);
        Console.WriteLine(booksReleasedBefore);

        // Задача 8
        string firstNameCheck = Console.ReadLine()!;
        string authorNames = GetAuthorNamesEndingIn(dbContext, firstNameCheck);
        Console.WriteLine(authorNames);

        // Задача 9
        string inputCheck = Console.ReadLine()!;
        string bookTitles = GetBookTitlesContaining(dbContext, inputCheck);
        Console.WriteLine(bookTitles);

        // Задача 10
        string lastNameCheck = Console.ReadLine()!;
        string booksByAuthors = GetBooksByAuthor(dbContext, lastNameCheck);
        Console.WriteLine(booksByAuthors);

        // Задача 11
        int lengthCheck = int.Parse(Console.ReadLine()!);
        int booksCount = CountBooks(dbContext, lengthCheck);
        Console.WriteLine(booksCount);

        // Задача 12
        string authorsBooks = CountCopiesByAuthor(dbContext);
        Console.WriteLine(authorsBooks);

        // Задача 13
        string categoryBooksProfit = GetTotalProfitByCategory(dbContext);
        Console.WriteLine(categoryBooksProfit);

        // Задача 14
        string recentBooks = GetMostRecentBooks(dbContext);
        Console.WriteLine(recentBooks);

        // Задача 15
        Stopwatch stopwatch = Stopwatch.StartNew();
        IncreasePrices(dbContext);
        stopwatch.Stop();

        Console.WriteLine($"Query run time in ms: {stopwatch.ElapsedMilliseconds}");

        // Задача 16
        int removedBooks = RemoveBooks(dbContext);
        Console.WriteLine(removedBooks);
       */
    }

    // Задача 2
    public static string GetBooksByAgeRestriction(BookShopContext dbContext, string command)
    {
        // Тази енумерация е всъщност маскиран int, което дава възможност да правим сравнение между integers
        AgeRestriction? ageRestriction = null;
        if (command != null &&
            Enum.GetValues<AgeRestriction>().Any(ev => ev.ToString().ToLowerInvariant() == command.ToLowerInvariant()))
        {
            ageRestriction = Enum.Parse<AgeRestriction>(command, true);
        }

        if (!ageRestriction.HasValue)
        {
            return string.Empty;
        }

        // SQL Server не разбира от енумерации и техните стрингови литерали
        // Енумерацията е INT в SQL Server. Следователно при сравняване на текст на енумерация със стринг води до неефективна заявка
        /* Съвети за ефективни заявки:
         * 1. Селектирайте само това, което е нужно
         * 2. Филтрирайте само записите, които са нужни
         * 3. Използвайте променливи (parameters), когато е възможно, за .Where(), за да позволите употребата на кеширани заявки, понеже константите и литералите не могат да се кешират, което
              води до некеширана заявка и при всяко изпълнение на заявката тя се регенерира
         * 4. Използвайте .AsNoTracking(), когато заявката ви е нужна само за четене (readonly) - това спира ChangeTracker-а и пести памет и време */
        IEnumerable<string> ageRestrictedBooks = dbContext.Books
            .AsNoTracking()
            .Where(b => b.AgeRestriction == ageRestriction.Value)
            .Select(b => b.Title)
            .OrderBy(bt => bt)
            .ToArray();

        return string.Join(Environment.NewLine, ageRestrictedBooks);
    }

    // Задача 3
    public static string GetGoldenBooks(BookShopContext dbContext)
    {
        IEnumerable<string> goldenBooks = dbContext.Books
            .AsNoTracking()
            .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, goldenBooks);
    }

    // Задача 4
    public static string GetBooksByPrice(BookShopContext dbContext)
    {
        StringBuilder result = new();

        decimal bookPrice = 40m;

        var booksByPrice = dbContext.Books
            .AsNoTracking()
            .Where(b => b.Price > bookPrice)
            .Select(b => new
            {
                b.Title,
                b.Price
            })
            .OrderByDescending(b => b.Price)
            .ToArray();

        foreach (var book in booksByPrice)
        {
            result.AppendLine($"{book.Title} - ${book.Price:f2}");
        }

        return result.ToString().TrimEnd();
    }

    // Задача 5
    public static string GetBooksNotReleasedIn(BookShopContext dbContext, int year)
    {
        IEnumerable<string> booksNotReleased = dbContext.Books
            .AsNoTracking()
            .Where(b => b.ReleaseDate != null && b.ReleaseDate.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, booksNotReleased);
    }

    // Задача 6
    public static string GetBooksByCategory(BookShopContext dbContext, string input)
    {
        string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(c => c.ToLowerInvariant())
            .ToArray();

        // EF Core доставя ефективна поддръжка за Collection.Contains() LINQ, като го превежда в IN ()
        /* Поведението на EF Core по подразбиране е Eager Loading -> Всички свързани данни се зареждат наведнъж при материализацията на заявката. Ако искаме експлицитно да направим 
           Eager Loading -> .Include()/.ThenInclude. EF Core ще добави всички навигационни обекти, които се използват в заявката автоматично */
        // В този случай SQL заявката остава същата независимо дали правим експлицитно (.Include()) или имплицитно (EF Core) Eager Loading
        IEnumerable<string> booksByCategory = dbContext.Books
            .AsNoTracking()
            .Include(b => b.BookCategories)
            .ThenInclude(bc => bc.Category)
            .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLowerInvariant())))
            .Select(b => b.Title)
            .OrderBy(bt => bt)
            .ToArray();

        return string.Join(Environment.NewLine, booksByCategory);
    }

    // Задача 7
    public static string GetBooksReleasedBefore(BookShopContext dbContext, string date)
    {
        StringBuilder result = new();

        DateTime dateCheck = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        var booksReleasedBefore = dbContext.Books
            .AsNoTracking()
            .Where(b => b.ReleaseDate < dateCheck)
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => new
            {
                b.Title,
                b.EditionType,
                b.Price
            })
            .ToArray();

        foreach (var book in booksReleasedBefore)
        {
            result.AppendLine($"{book.Title} - {book.EditionType.ToString()} - ${book.Price:f2}");
        }

        return result.ToString().TrimEnd();
    }

    // Задача 8
    public static string GetAuthorNamesEndingIn(BookShopContext dbContext, string input)
    {
        /* СЪвет за ефективност: Използвайте computed SQL колона по време на извличане на данните за name concatenation, защото тази computed колона няма да отнеме много от времето за изпълнение
           на заявката и ще ни спести бавни операции в клиента. Конкатенацията е сложна, трудна и бавна процедура. Клиентската машина обикновено е по-слаба от DB сървъра, следователно DB сървъра,
           който има повече ресурси, би трябвало да направи конкатенацията по-бързо */
        // EF Core умее да превежда .StartsWith(), .EndsWith(), .Contains() за текстове към оптималните SQL built-in функции
        /* Простите RegEx могат да бъдат преведени към SQL LIKE с wildcards, но поведението на EF Core по подразбиране е да НЕ ги обработва. Решението е EF.Functions - съдържат се  DB функции,
           които EF Core може да преведе */
        var authorFullNames = dbContext.Authors
            .AsNoTracking()
            .Where(a => a.FirstName.EndsWith(input))
            .OrderBy(a => a.FirstName)
            .ThenBy(a => a.LastName)
            .Select(a => a.FirstName + " " + a.LastName)
            .ToArray();

        return string.Join(Environment.NewLine, authorFullNames);
    }

    // Задача 9
    public static string GetBookTitlesContaining(BookShopContext dbContext, string input)
    {
        IEnumerable<string> bookTitles = dbContext.Books
            .AsNoTracking()
            .Where(b => EF.Functions.Like(b.Title.ToLower(), $"%{input.ToLower()}%"))
            .Select(b => b.Title)
            .OrderBy(bt => bt)
            .ToArray();

        return string.Join(Environment.NewLine, bookTitles);
    }

    // Задача 10
    public static string GetBooksByAuthor(BookShopContext dbContext, string input)
    {
        StringBuilder result = new();

        var booksByAuthors = dbContext.Books
            .AsNoTracking()
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => new
            {
                b.Title,
                AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
            })
            .ToArray();

        foreach (var book in booksByAuthors)
        {
            result.AppendLine($"{book.Title} ({book.AuthorFullName})");
        }

        return result.ToString().TrimEnd();
    }

    // Задача 11
    public static int CountBooks(BookShopContext dbContext, int lengthCheck)
    {
        return dbContext.Books
            .AsNoTracking()
            .Where(b => b.Title.Length > lengthCheck)
            .ToArray()
            .Count();
    }

    // Задача 12
    public static string CountCopiesByAuthor(BookShopContext dbContext)
    {
        StringBuilder result = new();

        // Така или иначе итерираме резултатите, за да извършим output форматирането, следователно е по-ефикасно да използваме конкатенация (интерполация) в тази итерация
        // EF Core поддържа агрегиращи функции LINQ -> SQL (.Sum(), .Min(), .Max(), .Avg(), ...) без проблем
        var authorsBooks = dbContext.Authors
            .AsNoTracking()
            .Include(a => a.Books)
            .Select(a => new
            {
                a.FirstName,
                a.LastName,
                TotalBooksCopies = a.Books.Sum(b => b.Copies)
            })
            .OrderByDescending(a => a.TotalBooksCopies)
            .ToArray();

        foreach (var author in authorsBooks)
        {
            result.AppendLine($"{author.FirstName} {author.LastName} - {author.TotalBooksCopies}");
        }

        return result.ToString().TrimEnd();
    }

    // Задача 13
    public static string GetTotalProfitByCategory(BookShopContext dbContext)
    {
        StringBuilder result = new();

        var categoryBooksProfit = dbContext.Categories
            .AsNoTracking()
            .Select(c => new
            {
                c.Name,
                TotalProfit = c.CategoryBooks
                    .Select(cb => cb.Book) // пропускане на навигационно пропърти
                    .Sum(b => b.Copies * b.Price)
            })
            .OrderByDescending(c => c.TotalProfit)
            .ThenBy(c => c.Name)
            .ToArray();

        foreach (var category in categoryBooksProfit)
        {
            result.AppendLine($"{category.Name} ${category.TotalProfit:f2}");
        }

        return result.ToString().TrimEnd();
    }

    // Задача 14
    public static string GetMostRecentBooks(BookShopContext dbContext)
    {
        StringBuilder result = new();

        var recentBooks = dbContext.Categories
            .AsNoTracking()
            .Select(c => new
            {
                c.Name,
                CategoryBooks = c.CategoryBooks
                    .Select(cb => cb.Book)
                    .Where(b => b.ReleaseDate.HasValue)
                    .Select(b => new
                    {
                        b.Title,
                        b.ReleaseDate
                    })
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                    .ToArray()
            })
            .OrderBy(c => c.Name)
            .ToArray();

        foreach (var category in recentBooks)
        {
            result.AppendLine($"--{category.Name}");

            foreach (var book in category.CategoryBooks)
            {
                result.AppendLine($"{book.Title} ({book.ReleaseDate!.Value.Year})");
            }
        }

        return result.ToString().TrimEnd();
    }

    // Задача 15
    public static void IncreasePrices(BookShopContext dbContext)
    {
        // Сравнение: III. > II. > I.

        /*
        // I. Стандартен подход - извличаме книгите, които трябва да се актуализират, актуализираме ги и ги запазваме - прост, но много неефективен -> 165 SQL заявки за UPDATE
        // EF Core трябва да може да преведе DateTime.Year пропъртито към SQL Server YEAR()/DATEPART() функцията
        // Книгите са закачени към ChangeTracker
        IQueryable<Book> booksToUpdate = dbContext.Books
            .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010);

        foreach (Book book in booksToUpdate) // материализацията се случва имплицитно тук
        {
            book.Price += 5;
        }
        
        dbContext.SaveChanges();
        */

        /* С този подход няма да минат Judge тестовете
        // II. Bulk подход - UPDATE на всички книги в една заявка
        // EF Core 7.0+ поддържа bulk updates и deletes
        // EF Core 6.0 не поддържа bulk updates и deletes, но можем да използваме Z.EntityFramework.Plus.EFCore пакет
        dbContext.Books
            .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010)
            .Update(b => new Book() // функция от пакета; операцията се изпълнява директно в базата
            {
                Price = b.Price + 5
            });
        */

        // III. Bulk подход с EF Core 7.0+
        // NOTE: С този подход отново няма да минат Judge тестовете, понеже той работи с InMemoryDatabase!!!
        dbContext.Books
            .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010)
            .ExecuteUpdate(bk => bk.SetProperty(b => b.Price, b => b.Price + 5)); // операцията се изпълнява директно в базата
    }

    // Задача 16
    public static int RemoveBooks(BookShopContext dbContext)
    {
        int removedBooks = 0;

        IQueryable<Book> booksToRemove = dbContext.Books
            .Where(b => b.Copies < 4200);

        foreach (Book book in booksToRemove)
        {
            dbContext.Remove(book);
            removedBooks++;
        }

        dbContext.SaveChanges();

        return removedBooks;
    }
}
using System.Text;

using Microsoft.EntityFrameworkCore;

using MusicHub.Data;
using MusicHub.Initializer;

namespace MusicHub;

public class StartUp
{
    public static void Main()
    {
        using MusicHubDbContext dbContext = new();

        DbInitializer.ResetDatabase(dbContext);

        string albumsInfo = ExportAlbumsInfo(dbContext, 9);
        Console.WriteLine(albumsInfo);

        Console.WriteLine();

        string songsInfo = ExportSongsAboveDuration(dbContext, 4);
        Console.WriteLine(songsInfo);
    }

    public static string ExportAlbumsInfo(MusicHubDbContext dbContext, int producerId)
    {
        StringBuilder result = new();

        /* Някои по-сложни заявки не могат да бъдат преведени от EF Core Db Provider. Ако се получи такава грешка, решението е -> изместваме материализацията на заявката (.ToArray()) преди
           проблемната заявка */
        // .AsEnumerable() - използва се, за да изпрати изпълнението на заявката в клиентската част по-рано - без да викаме .ToArray()
        /* Препоръчително е да се използва .Skip()/.Take(), за да ограничим обема на резултата от заявката. .Skip()/.Take() са бавни LINQ операции, защото .Skip() минава през всички пропуснати
           записи.*/
        /* Среща се по разширено в ASP.NET => Ако искаме на имплементираме Basic Pagination with Number Navigation -> .Skip()/.Take(). Ако искаме да правим Advanced Pagination with
           Sequence Loading -> уникален .OrderBy() + .Where(paginationFilter) */
        // Съвет: използвайте .AsSplitQuery(), когато заявката извършва много LEFT JOINs с други обекти на същото ниво на заявката (CROSS-PRODUCT - съдържа много ненужни стойности)
        var albumsInfo = dbContext.Albums
            .AsNoTracking() /* ако искаме само да четем данни, без да се следят от ChangeTracker - казва на EF Core, че нямаме нужда да следим промени и да извършваме Identity Resolution -
                               повишава производителността, защото ChangeTracker не присъства */
            .AsSplitQuery() // за оптимизация - разделя голямата заявка на няколко по-малки заявки и резултатите от тези заявки ще бъдат свързани client-side
            .Include(a => a.Songs) // зареждаме цялата колекция еднократно, а не само каквото е нужно на заявката (Songs = a.Songs.Select(...))
            .Where(a => a.ProducerId == producerId)
            .Select(a => new
            {
                AlbumName = a.Name,
                a.ReleaseDate,
                ProducerName = a.Producer != null ?
                    a.Producer.Name : null,
                Songs = a.Songs
                    .Select(s => new
                    {
                        SongName = s.Name,
                        s.Price,
                        WriterName = s.Writer.Name,
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.WriterName)
                    .ToArray(),
                TotalPrice = a.Price,
            })
            .AsEnumerable()
            .OrderByDescending(a => a.TotalPrice)
            .ToArray();

        foreach (var album in albumsInfo)
        {
            result.AppendLine($"-AlbumName: {album.AlbumName}")
                .AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}")
                .AppendLine($"-ProducerName: {album.ProducerName}")
                .AppendLine("-Songs:");

            int songCounter = 1;
            foreach (var song in album.Songs)
            {
                result.AppendLine($"---#{songCounter++}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Price: {song.Price:f2}")
                    .AppendLine($"---Writer: {song.WriterName}");
            }

            result.AppendLine($"-AlbumPrice: {album.TotalPrice:f2}");
        }

        return result.ToString().TrimEnd();
    }

    public static string ExportSongsAboveDuration(MusicHubDbContext dbContext, int duration)
    {
        StringBuilder result = new();

        // Duration.TotalSeconds не може да бъде преведен в SQL
        /* Начини да заобиколим този проблем:
         * I. Местим филтрирането в клиентската част - След .ThenBy() слагаме .AsEnumerable() и .Where() отива след него
         * II. Използваме .FromSql(), за да започнем с чиста SQL заявка, която съдържа .Where() */
        // Може да използваме .Join(), за да премахнем излишните cross join данни от заявката
        var songs = dbContext.Songs
            //.FromSqlInterpolated($"SELECT * FROM [Songs] WHERE DATEPART(SECOND, [Duration]) + 60 * DATEPART(MINUTE, [Duration]) + 3600 * DATEPART(HOUR, [Duration]) > {duration}")
            .AsNoTracking()
            .Select(s => new
            {
                SongName = s.Name,
                Performers = s.SongPerformers
                    .Select(sp => sp.Performer)
                    .Select(p => p.FirstName + " " + p.LastName)
                    .OrderBy(p => p)
                    .ToArray(),
                WriterName = s.Writer.Name,
                AlbumProducerName = (s.Album != null && s.Album.Producer != null) ?
                    s.Album.Producer.Name : null,
                s.Duration,
            })
            .OrderBy(s => s.SongName)
            .ThenBy(s => s.WriterName)
            .AsEnumerable()
            .Where(s => s.Duration.TotalSeconds > duration)
            .ToArray();

        int songCounter = 1;
        foreach (var song in songs)
        {
            result.AppendLine($"-Song #{songCounter++}")
                .AppendLine($"---SongName: {song.SongName}")
                .AppendLine($"---Writer: {song.WriterName}");

            foreach (string performerFullName in song.Performers)
            {
                result.AppendLine($"---Performer: {performerFullName}");
            }

            result.AppendLine($"---AlbumProducer: {song.AlbumProducerName}")
                .AppendLine($"---Duration: {song.Duration.ToString("c")}");
        }

        return result.ToString().TrimEnd();
    }
}
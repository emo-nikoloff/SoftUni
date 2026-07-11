using P02_FootballBetting.Data;

namespace P02_FootballBetting;

public class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            using FootballBettingContext dbContext = new();

            // Development only solution (Решение само за разработка)! - не е хубаво да се извършват в production - временно решение
            // Съвет: използвайте Migartion API за това
            dbContext.Database.EnsureDeleted(); // първо изтриваме базата, ако съществува, за да се осигури синхронизация с последните промени

            // Development only solution
            // Съвет: използвайте Migartion API за това
            dbContext.Database.EnsureCreated(); // опитва се да създаде базата от последните Code First промени

            Console.WriteLine("Database created from Code-First model!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            if (e.InnerException != null)
            {
                Console.WriteLine(e.InnerException.Message);
            }
        }
    }
}

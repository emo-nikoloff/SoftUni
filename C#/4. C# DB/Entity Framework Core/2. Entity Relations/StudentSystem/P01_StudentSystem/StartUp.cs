using P01_StudentSystem.Data;

namespace P01_StudentSystem;

public class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            using StudentSystemContext dbContext = new();

            dbContext.Database.EnsureDeleted();

            dbContext.Database.EnsureCreated();
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

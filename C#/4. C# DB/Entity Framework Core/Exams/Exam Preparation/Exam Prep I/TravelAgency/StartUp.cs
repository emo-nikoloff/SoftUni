using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using TravelAgency.Data;

namespace TravelAgency;

public class StartUp
{
    static void Main(string[] args)
    {
        using TravelAgencyContext dbContext = new TravelAgencyContext();

        //ResetDatabase(dbContext, shouldDropDatabse: true);

        object projectDir = GetProjectDirectory();

        //ImportEntities(dbContext, projectDir + @"Datasets/", projectDir + @"ImportResults/");
        ExportEntities(dbContext, projectDir + @"ExportResults/");

        using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
        {
            transaction.Rollback();
        }
    }

    private static void ExportEntities(TravelAgencyContext dbContext, string exportDir)
    {
        string GuidesWithSpanishLanguageWithAllTheirTourPackages = DataProcessor
            .Serializer.ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(dbContext);

        Console
            .WriteLine(GuidesWithSpanishLanguageWithAllTheirTourPackages);
        File
            .WriteAllText(exportDir + "Actual Result - Export Guides With Spanish Language With All Their Tour Packages.xml", GuidesWithSpanishLanguageWithAllTheirTourPackages);

        string CustomersThatHaveBookedHorseRidingTourPackage = DataProcessor
            .Serializer.ExportCustomersThatHaveBookedHorseRidingTourPackage(dbContext);

        Console
            .WriteLine(CustomersThatHaveBookedHorseRidingTourPackage);
        File
            .WriteAllText(exportDir + "Actual Result - Export Customers With Their Bookings.json", CustomersThatHaveBookedHorseRidingTourPackage);
    }

    private static void ImportEntities(TravelAgencyContext dbContext, string baseDir, string exportDir)
    {
        string customers = DataProcessor.Deserializer
            .ImportCustomers(dbContext, File.ReadAllText(baseDir + "customers.xml"));

        PrintAndExportEntityToFile(customers, exportDir + "Actual Result - Import Customers.txt");

        string bookings = DataProcessor.Deserializer
            .ImportBookings(dbContext, File.ReadAllText(baseDir + "bookings.json"));

        PrintAndExportEntityToFile(bookings, exportDir + "Actual Result - Import Bookings.txt");
    }

    private static void PrintAndExportEntityToFile(string entityOutput, string outputPath)
    {
        Console.WriteLine(entityOutput);
        File.WriteAllText(outputPath, entityOutput.TrimEnd());
    }

    private static object GetProjectDirectory()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string directoryName = Path.GetFileName(currentDirectory);
        string relativePath = directoryName.StartsWith("net8.0") ? @"../../../" : string.Empty;

        return relativePath;
    }

    private static void ResetDatabase(TravelAgencyContext dbContext, bool shouldDropDatabse = false)
    {
        if (shouldDropDatabse)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
        else
        {
            if (dbContext.Database.EnsureCreated())
            {
                return;
            }

            string disableIntegrityChecksQuery = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
            dbContext.Database.ExecuteSqlRaw(disableIntegrityChecksQuery);

            string deleteRowsQuery = "EXEC sp_MSforeachtable @command1='SET QUOTED_IDENTIFIER ON;DELETE FROM ?'";
            dbContext.Database.ExecuteSqlRaw(deleteRowsQuery);

            string enableIntegrityChecksQuery = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
            dbContext.Database.ExecuteSqlRaw(enableIntegrityChecksQuery);

            string reseedQuery = "EXEC sp_MSforeachtable @command1='IF OBJECT_ID(''?'') IN (SELECT OBJECT_ID FROM SYS.IDENTITY_COLUMNS) DBCC CHECKIDENT(''?'', RESEED, 0)'";
            dbContext.Database.ExecuteSqlRaw(reseedQuery);
        }
    }
}

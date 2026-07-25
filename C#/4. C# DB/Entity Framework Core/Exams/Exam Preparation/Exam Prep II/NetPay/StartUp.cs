using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using NetPay.Data;

namespace NetPay;

public class StartUp
{
    static void Main(string[] args)
    {
        using NetPayContext dbContext = new NetPayContext();

        ResetDatabase(dbContext, shouldDropDatabase: true);

        object projectDir = GetProjectDirectory();

        ImportEntities(dbContext, projectDir + @"Datasets/", projectDir + @"ImportResults/");
        ExportEntities(dbContext, projectDir + @"ExportResults/");

        using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
        {
            transaction.Rollback();
        }
    }

    private static void ImportEntities(NetPayContext dbContext, string baseDir, string exportDir)
    {
        string households = DataProcessor.Deserializer
            .ImportHouseholds(dbContext, File.ReadAllText(baseDir + "households.xml"));

        PrintAndExportEntityToFile(households, exportDir + "Actual-Result-ImportHouseholds.txt");

        string expences = DataProcessor.Deserializer
            .ImportExpenses(dbContext, File.ReadAllText(baseDir + "expences.json"));

        PrintAndExportEntityToFile(expences, exportDir + "Actual-Result-ImportExpenses.txt");
    }

    private static void ExportEntities(NetPayContext dbContext, string exportDir)
    {
        string HouseholdsHavingExpensesToPayWithAllUnpaidExpences =
            DataProcessor.Serializer.ExportHouseholdsWhichHaveExpensesToPay(dbContext);

        Console.WriteLine(HouseholdsHavingExpensesToPayWithAllUnpaidExpences);
        File.WriteAllText(exportDir + "Actual-Result-ExportHouseholds.xml", HouseholdsHavingExpensesToPayWithAllUnpaidExpences);

        string ServicesWithSuppliers =
            DataProcessor.Serializer.ExportAllServicesWithSuppliers(dbContext);

        Console.WriteLine(ServicesWithSuppliers);
        File.WriteAllText(exportDir + "Actual-Result-ExportServicesWithSuppliers.json", ServicesWithSuppliers);
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
        string relativePath = directoryName.StartsWith("net8.0")
            ? @"../../../"
            : string.Empty;

        return relativePath;
    }

    private static void ResetDatabase(NetPayContext dbContext, bool shouldDropDatabase = false)
    {
        if (shouldDropDatabase)
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

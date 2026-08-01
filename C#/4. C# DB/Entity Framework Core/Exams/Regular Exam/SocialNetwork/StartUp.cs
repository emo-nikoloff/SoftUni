using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using SocialNetwork.Data;

namespace SocialNetwork;

public class StartUp
{
    static void Main(string[] args)
    {
        using SocialNetworkDbContext dbContext = new SocialNetworkDbContext();

        ResetDatabase(dbContext, shouldDropDatabase: true);

        object projectDir = GetProjectDirectory();

        ImportEntities(dbContext, projectDir + @"Datasets/", projectDir + @"ImportResults/");
        ExportEntities(dbContext, projectDir + @"ExportResults/");

        using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
        {
            transaction.Rollback();
        }
    }

    private static void ImportEntities(SocialNetworkDbContext dbContext, string baseDir, string exportDir)
    {
        string messages = DataProcessor.Deserializer
            .ImportMessages(dbContext, File.ReadAllText(baseDir + "messages.xml"));

        PrintAndExportEntityToFile(messages, exportDir + "ActualResult_ImportMessages.txt");

        string posts = DataProcessor.Deserializer
            .ImportPosts(dbContext, File.ReadAllText(baseDir + "posts.json"));

        PrintAndExportEntityToFile(posts, exportDir + "ActualResult_ImportPosts.txt");
    }

    private static void ExportEntities(SocialNetworkDbContext dbContext, string exportDir)
    {
        string UsersWithTheirPosts = DataProcessor.Serializer
            .ExportUsersWithFriendShipsCountAndTheirPosts(dbContext);

        Console.WriteLine(UsersWithTheirPosts);
        File.WriteAllText(exportDir + "ActualResult_ExportUsersWithTheirPosts.xml", UsersWithTheirPosts);

        string Conversations = DataProcessor.Serializer
            .ExportConversationsWithMessagesChronologically(dbContext);

        Console.WriteLine(Conversations);
        File.WriteAllText(exportDir + "ActualResult_ExportConversationsWithMessages.json", Conversations);
    }

    private static void PrintAndExportEntityToFile(string entityOutput, string outputPath)
    {
        Console.WriteLine(entityOutput);
        File.WriteAllText(outputPath, entityOutput.TrimEnd());
    }

    private static object GetProjectDirectory()
    {
        string directory = Directory.GetCurrentDirectory();
        string directoryName = Path.GetFileName(directory);
        string relativePath = directoryName.StartsWith("net8.0") ? @"../../../" : string.Empty;

        return relativePath;
    }

    private static void ResetDatabase(SocialNetworkDbContext dbContext, bool shouldDropDatabase = false)
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

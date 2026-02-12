using System.IO.Compression;

namespace _06._Zip_and_Extracts;

class Program
{
    static void Main(string[] args)
    {
        string inputFile = @"..\..\..\Files\copyMe.png";
        string zipArchiveFile = @"..\..\..\Files\archive.zip";
        string extractedFile = @"..\..\..\Files\extracted.png";

        ZipFileToArchive(inputFile, zipArchiveFile);

        var fileNameOnly = Path.GetFileName(inputFile);
        ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
    }

    public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
    {
        using ZipArchive archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Update);

        archive.CreateEntryFromFile(inputFilePath, Path.GetFileName(inputFilePath));
    }

    public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
    {
        using ZipArchive archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Read);

        ZipArchiveEntry entry = archive.GetEntry(fileName);

        if (entry is not null)
        {
            entry.ExtractToFile(outputFilePath);
        }
    }
}

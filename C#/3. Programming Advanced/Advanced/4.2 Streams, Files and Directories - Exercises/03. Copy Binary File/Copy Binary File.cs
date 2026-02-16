/*Write a program that copies the contents of a binary file (e. g. copyMe.png) to another binary file (e. g. copyMe-copy.png) using FileStream. You are not allowed to use the File class or
similar helper classes.*/
namespace _03._Copy_Binary_File;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = @"..\..\..\Files\copyMe.png";
        string outputFilePath = @"..\..\..\Files\copyMe-copy.png";

        CopyFile(inputFilePath, outputFilePath);
    }

    public static void CopyFile(string inputFilePath, string outputFilePath)
    {
        using FileStream reader = new(inputFilePath, FileMode.Open);
        using FileStream writer = new(outputFilePath, FileMode.Create);

        byte[] buffer = new byte[reader.Length];
        reader.ReadExactly(buffer);
        writer.Write(buffer);
    }
}

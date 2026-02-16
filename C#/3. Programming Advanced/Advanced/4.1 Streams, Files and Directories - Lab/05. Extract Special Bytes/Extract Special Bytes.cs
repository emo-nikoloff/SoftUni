/*You are given a binary file (e. g. example.png) and a text file (e. g. bytes.txt), holding a list of bytes in the range [0…255]. Write a program to extract occurrences of all given bytes from
the input file to an output binary file (e. g. output.bin).*/
using System.Text;

namespace _05._Extract_Special_Bytes;

class Program
{
    static void Main(string[] args)
    {
        string binaryFilePath = @"..\..\..\Files\example.png";
        string bytesFilePath = @"..\..\..\Files\bytes.txt";
        string outputPath = @"..\..\..\Files\output.bin";

        ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
    }

    public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
    {
        using StreamReader reader = new(bytesFilePath);
        byte[] bytes = File.ReadAllBytes(binaryFilePath);
        List<string> occurrences = new List<string>();
        while (!reader.EndOfStream)
        {
            occurrences.Add(reader.ReadLine());
        }

        StringBuilder builder = new StringBuilder();
        foreach (byte @byte in bytes)
        {
            if (occurrences.Contains(@byte.ToString()))
            {
                builder.AppendLine(@byte.ToString());
            }
        }
        using StreamWriter writer = new StreamWriter(outputPath);
        writer.WriteLine(builder.ToString().Trim());
    }
}

namespace _06._Split__Merge_Binary_Files;

class Program
{
    static void Main(string[] args)
    {
        string sourceFilePath = @"..\..\..\Files\example.png";
        string joinedFilePath = @"..\..\..\Files\example-joined.png";
        string partOnePath = @"..\..\..\Files\part-1.bin";
        string partTwoPath = @"..\..\..\Files\part-2.bin";

        SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
        MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
    }

    public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
    {
        using FileStream reader = new FileStream(sourceFilePath, FileMode.Open);
        long lengthFirstFile = (long)Math.Ceiling(reader.Length / 2.0);
        long lengthSecondFile = reader.Length - lengthFirstFile;

        using FileStream writerFirstFile = new FileStream(partOneFilePath, FileMode.Create);
        byte[] bufferFirstFile = new byte[lengthFirstFile];
        reader.ReadExactly(bufferFirstFile);
        writerFirstFile.Write(bufferFirstFile);

        using FileStream writerSecondFile = new FileStream(partTwoFilePath, FileMode.Create);
        byte[] bufferSecondFile = new byte[lengthSecondFile];
        reader.ReadExactly(bufferSecondFile);
        writerSecondFile.Write(bufferSecondFile);
    }

    public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
    {
        using FileStream writer = new FileStream(joinedFilePath, FileMode.Create);

        using FileStream readerFirstFile = new FileStream(partOneFilePath, FileMode.Open);
        byte[] bufferFirstFile = new byte[readerFirstFile.Length];
        readerFirstFile.ReadExactly(bufferFirstFile);
        writer.Write(bufferFirstFile);

        using FileStream readerSecondFile = new FileStream(partTwoFilePath, FileMode.Open);
        byte[] bufferSecondFile = new byte[readerSecondFile.Length];
        readerSecondFile.ReadExactly(bufferSecondFile);
        writer.Write(bufferSecondFile);
    }
}

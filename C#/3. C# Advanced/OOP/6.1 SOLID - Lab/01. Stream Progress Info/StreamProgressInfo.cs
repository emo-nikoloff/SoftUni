namespace StreamProgressInfo;

public class StreamProgressInfo
{
    private IStreamable streamableFile;

    public StreamProgressInfo(IStreamable streamableFile)
    {
        this.streamableFile = streamableFile;
    }

    public int CalculateCurrentPercent()
    {
        return (streamableFile.BytesSent * 100) / streamableFile.Length;
    }
}

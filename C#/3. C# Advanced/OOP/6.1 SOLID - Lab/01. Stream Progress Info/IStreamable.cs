namespace StreamProgressInfo;

public interface IStreamable
{
    int Length { get; }
    int BytesSent { get; }
}

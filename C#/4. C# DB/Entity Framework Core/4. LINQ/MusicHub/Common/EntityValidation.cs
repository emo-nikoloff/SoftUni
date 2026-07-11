namespace MusicHub.Common;

public static class EntityValidation
{
    // Song
    public const int SongNameMaxLength = 20;
    public const string SongPriceColumnType = "DECIMAL(9, 4)";
    public const string SongCreatedOnColumnType = "SMALLDATETIME";

    // Album
    public const int AlbumNameMaxLength = 40;
    public const string AlbumRealeaseDateColumnType = "SMALLDATETIME";

    // Performer
    public const int PerformerFirstNameMaxLength = 20;
    public const int PerformerLastNameMaxLength = 20;
    public const string PerformerNetWorthColumnType = "DECIMAL(13, 4)";

    // Producer
    public const int ProducerNameMaxLength = 30;
    public const int ProducerPseudonymMaxLength = 30;
    public const int ProducerPhoneNumberMaxLength = 20;

    // Writer
    public const int WriterNameMaxLength = 20;
    public const int WriterPseudonymMaxLength = 20;
}

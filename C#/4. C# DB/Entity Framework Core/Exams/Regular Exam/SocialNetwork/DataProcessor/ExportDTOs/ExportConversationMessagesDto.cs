namespace SocialNetwork.DataProcessor.ExportDTOs;

public class ExportConversationMessagesDto
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string StartedAt { get; set; } = null!;

    public ExportConversationMessageDto[] Messages { get; set; } = Array.Empty<ExportConversationMessageDto>();
}

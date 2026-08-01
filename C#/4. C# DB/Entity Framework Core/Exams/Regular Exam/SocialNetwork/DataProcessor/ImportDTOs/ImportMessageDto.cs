using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static SocialNetwork.Common.ValidConstants;

namespace SocialNetwork.DataProcessor.ImportDTOs;

[XmlType("Message")]
public class ImportMessageDto
{
    [Required]
    [StringLength(MessageContentMaxLength,
        MinimumLength = MessageContentMinLength)]
    [XmlElement("Content")]
    public string Content { get; set; } = null!;

    [Required]
    [XmlElement("Status")]
    public string Status { get; set; } = null!;

    [XmlElement("ConversationId")]
    public int ConversationId { get; set; }

    [XmlElement("SenderId")]
    public int SenderId { get; set; }

    [Required]
    [XmlAttribute("SentAt")]
    public string SentAt { get; set; } = null!;
}

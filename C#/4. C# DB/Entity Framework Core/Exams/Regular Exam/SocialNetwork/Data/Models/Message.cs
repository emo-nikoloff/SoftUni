using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SocialNetwork.Data.Models.Enums;
using static SocialNetwork.Common.ValidConstants;

namespace SocialNetwork.Data.Models;

public class Message
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(MessageContentMaxLength)]
    public string Content { get; set; } = null!;

    public DateTime SentAt { get; set; }

    public MessageStatus Status { get; set; }

    [ForeignKey(nameof(Conversation))]
    public int ConversationId { get; set; }

    public virtual Conversation Conversation { get; set; } = null!;

    [ForeignKey(nameof(Sender))]
    public int SenderId { get; set; }

    public virtual User Sender { get; set; } = null!;
}

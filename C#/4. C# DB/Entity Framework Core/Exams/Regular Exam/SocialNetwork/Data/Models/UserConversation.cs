using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Data.Models;

[PrimaryKey(nameof(UserId), nameof(ConversationId))]
public class UserConversation
{
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(Conversation))]
    public int ConversationId { get; set; }

    public virtual Conversation Conversation { get; set; } = null!;
}

using System.ComponentModel.DataAnnotations;

using static SocialNetwork.Common.ValidConstants;

namespace SocialNetwork.Data.Models;

public class Conversation
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ConversationTitleMaxLength)]
    public string Title { get; set; } = null!;

    public DateTime StartedAt { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new HashSet<Message>();

    public virtual ICollection<UserConversation> UsersConversations { get; set; } = new HashSet<UserConversation>();
}

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using SocialNetwork.Data;
using SocialNetwork.DataProcessor.ExportDTOs;
using SocialNetwork.Utilities;

namespace SocialNetwork.DataProcessor;

public class Serializer
{
    public static string ExportUsersWithFriendShipsCountAndTheirPosts(SocialNetworkDbContext dbContext)
    {
        ExportUserFriendshipsAndPostsDto[] usersFriendshipsAndPosts = dbContext.Users
            .AsNoTracking()
            .OrderBy(u => u.Username)
            .Select(u => new ExportUserFriendshipsAndPostsDto()
            {
                Friendships = dbContext.Friendships.Count(f => f.UserOneId == u.Id || f.UserTwoId == u.Id),
                Username = u.Username,
                Posts = u.Posts
                    .OrderBy(p => p.Id)
                    .Select(p => new ExportUserPostsDto()
                    {
                        Content = p.Content,
                        CreatedAt = p.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                    })
                    .ToArray(),
            })
            .ToArray();

        string result = XmlSerializerWrapper.Serialize(usersFriendshipsAndPosts, "Users");

        return result.TrimEnd();
    }

    public static string ExportConversationsWithMessagesChronologically(SocialNetworkDbContext dbContext)
    {
        ExportConversationMessagesDto[] conversationsMessages = dbContext.Conversations
            .AsNoTracking()
            .OrderBy(c => c.StartedAt)
            .Select(c => new ExportConversationMessagesDto
            {
                Id = c.Id,
                Title = c.Title,
                StartedAt = c.StartedAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                Messages = c.Messages
                    .OrderBy(m => m.SentAt)
                    .Select(m => new ExportConversationMessageDto
                    {
                        Content = m.Content,
                        SentAt = m.SentAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                        Status = (int)m.Status,
                        SenderUsername = m.Sender.Username,
                    })
                    .ToArray(),
            })
            .ToArray();

        string result = JsonConvert.SerializeObject(conversationsMessages, Formatting.Indented);

        return result.ToString().TrimEnd();
    }
}

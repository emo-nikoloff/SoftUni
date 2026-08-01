using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.Enums;
using SocialNetwork.DataProcessor.ImportDTOs;
using SocialNetwork.Utilities;

namespace SocialNetwork.DataProcessor;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data format.";
    private const string DuplicatedDataMessage = "Duplicated data.";
    private const string SuccessfullyImportedMessageEntity = "Successfully imported message (Sent at: {0}, Status: {1})";
    private const string SuccessfullyImportedPostEntity = "Successfully imported post (Creator {0}, Created at: {1})";

    public static string ImportMessages(SocialNetworkDbContext dbContext, string xmlString)
    {
        StringBuilder result = new();

        IEnumerable<ImportMessageDto>? messagesDtos = XmlSerializerWrapper.Deserialize<ImportMessageDto[]>(xmlString, "Messages");
        if (messagesDtos == null)
        {
            return result.ToString();
        }

        ICollection<Message> validMessages = dbContext.Messages
            .AsNoTracking()
            .ToArray();
        ICollection<int> validConversationIds = dbContext.Conversations
            .AsNoTracking()
            .Select(c => c.Id)
            .ToArray();
        ICollection<int> validUserIds = dbContext.Users
            .AsNoTracking()
            .Select(u => u.Id)
            .ToArray();

        ICollection<Message> messagesToPersist = new List<Message>();
        foreach (ImportMessageDto messageDto in messagesDtos)
        {
            if (!IsValid(messageDto))
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            bool isSentAtValid = DateTime.TryParseExact(
                messageDto.SentAt,
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime sentAt);
            bool isStatusValid = Enum.TryParse(messageDto.Status, out MessageStatus status);
            if (!isSentAtValid || !isStatusValid)
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            if (!validConversationIds.Contains(messageDto.ConversationId)
                || !validUserIds.Contains(messageDto.SenderId))
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            bool isDuplicate = validMessages
                                .Where(m => m.ConversationId == messageDto.ConversationId)
                                .Any(m =>
                                    m.Content == messageDto.Content
                                    && m.SentAt == sentAt
                                    && m.Status == status
                                    && m.SenderId == messageDto.SenderId)
                            || messagesToPersist
                                .Where(m => m.ConversationId == messageDto.ConversationId)
                                .Any(m =>
                                    m.Content == messageDto.Content
                                    && m.SentAt == sentAt
                                    && m.Status == status
                                    && m.SenderId == messageDto.SenderId);
            if (isDuplicate)
            {
                result.AppendLine(DuplicatedDataMessage);
                continue;
            }

            Message message = new()
            {
                Content = messageDto.Content,
                Status = status,
                ConversationId = messageDto.ConversationId,
                SenderId = messageDto.SenderId,
                SentAt = sentAt,
            };

            messagesToPersist.Add(message);
            result.AppendLine(string.Format(SuccessfullyImportedMessageEntity, message.SentAt.ToString("yyyy-MM-ddTHH:mm:ss"), message.Status));
        }

        dbContext.Messages.AddRange(messagesToPersist);
        dbContext.SaveChanges();

        return result.ToString().TrimEnd();
    }

    public static string ImportPosts(SocialNetworkDbContext dbContext, string jsonString)
    {
        StringBuilder result = new();

        IEnumerable<ImportPostDto>? postDtos = JsonConvert.DeserializeObject<ImportPostDto[]>(jsonString);
        if (postDtos == null)
        {
            return result.ToString();
        }

        ICollection<Post> validPosts = dbContext.Posts
            .AsNoTracking()
            .ToArray();
        ICollection<User> validCreators = dbContext.Users
            .AsNoTracking()
            .ToArray();

        ICollection<Post> postsToPersist = new List<Post>();
        foreach (ImportPostDto postDto in postDtos)
        {
            if (!IsValid(postDto))
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            bool isCreatedAtValid = DateTime.TryParseExact(
                postDto.CreatedAt,
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime createdAt);
            if (!isCreatedAtValid)
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            User? creator = validCreators.FirstOrDefault(c => c.Id == postDto.CreatorId);
            if (creator == null)
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            bool isDuplicate = validPosts.Any(p =>
                                    p.Content == postDto.Content
                                    && p.CreatedAt == createdAt
                                    && p.CreatorId == postDto.CreatorId)
                            || postsToPersist.Any(p =>
                                    p.Content == postDto.Content
                                    && p.CreatedAt == createdAt
                                    && p.CreatorId == postDto.CreatorId);
            if (isDuplicate)
            {
                result.AppendLine(DuplicatedDataMessage);
                continue;
            }

            Post post = new()
            {
                Content = postDto.Content,
                CreatedAt = createdAt,
                CreatorId = postDto.CreatorId,
            };

            postsToPersist.Add(post);
            result.AppendLine(string.Format(SuccessfullyImportedPostEntity,
                creator.Username,
                post.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss")));
        }

        dbContext.Posts.AddRange(postsToPersist);
        dbContext.SaveChanges();

        return result.ToString().TrimEnd();
    }

    public static bool IsValid(object dto)
    {
        ValidationContext validationContext = new ValidationContext(dto);
        List<ValidationResult> validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

        foreach (ValidationResult validationResult in validationResults)
        {
            if (validationResult.ErrorMessage != null)
            {
                string currentMessage = validationResult.ErrorMessage;
            }
        }

        return isValid;
    }
}

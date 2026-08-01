using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ExportDTOs;

[XmlType("User")]
public class ExportUserFriendshipsAndPostsDto
{
    [XmlAttribute("Friendships")]
    public int Friendships { get; set; }

    [XmlElement("Username")]
    public string Username { get; set; } = null!;

    [XmlArray("Posts")]
    public ExportUserPostsDto[] Posts { get; set; } = Array.Empty<ExportUserPostsDto>();
}

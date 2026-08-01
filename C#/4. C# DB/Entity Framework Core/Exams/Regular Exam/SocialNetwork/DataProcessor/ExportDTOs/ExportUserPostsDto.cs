using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ExportDTOs;

[XmlType("Post")]
public class ExportUserPostsDto
{
    [XmlElement("Content")]
    public string Content { get; set; } = null!;

    [XmlElement("CreatedAt")]
    public string CreatedAt { get; set; } = null!;
}

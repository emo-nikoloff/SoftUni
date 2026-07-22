using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

public class ExportUsersWithProductsCountDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("users")]
    public ExportUserWithProductsDto[] Users { get; set; } = Array.Empty<ExportUserWithProductsDto>();
}

using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("SoldProducts")]
public class ExportSoldProductsCountDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("products")]
    public ExportProductUserDto[] Products { get; set; } = Array.Empty<ExportProductUserDto>();
}

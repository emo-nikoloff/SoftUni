using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Sale")]
public class ImportSaleDto
{
    [Range(0, int.MaxValue)]
    [XmlElement("carId")]
    public int CarId { get; set; }

    [Range(0, int.MaxValue)]
    [XmlElement("customerId")]
    public int CustomerId { get; set; }

    [XmlElement("discount")]
    public decimal Discount { get; set; }
}

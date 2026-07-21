using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Customer")]
public class ImportCustomerDto
{
    [Required]
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    // Съвет: Когато работим с DateTime, TimeSpan и т.н., препоръчително е да се използва string за десериализация и да се парсне с custom формат
    [XmlElement("birthDate")]
    public DateTime BirthDate { get; set; }

    [XmlElement("isYoungDriver")]
    public bool IsYoungDriver { get; set; }
}

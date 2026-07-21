using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Supplier")] // XmlSerializer няма как да се досети, че искаме да десериализираме XML типа Supplier към C# типа ImportSupplierDto
public class ImportSupplierDto
{
    [Required]
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    /* Два подхода за пропърти типовете:
     * 1. Използване на същия тип, който е в моделния клас (в случая bool) - може да предизвика проблеми с десериализацията и да прекъсне цялата десериализация поради некоректни стойности
     * 2. Използване на стринг тип - позволява ни да пропуснем DTO-то с некоректни стойности и да продължим десериализацията, като използваме TryParse() метод
    */
    [Required]
    [XmlElement("isImporter")]
    public string IsImporter { get; set; } = null!;
}

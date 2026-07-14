using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Import;

public class ImportCustomerDto
{
    [Required]
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [Required]
    [JsonProperty("birthDate")]
    public string BirthDate { get; set; } = null!;

    [JsonRequired]
    [JsonProperty("isYoungDriver")]
    public bool IsYoungDriver { get; set; }
}

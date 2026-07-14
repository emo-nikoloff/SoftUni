using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Import;

public class ImportPartDto
{
    [Required]
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonRequired]
    [JsonProperty("price")]
    public decimal Price { get; set; }

    [JsonRequired]
    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    [JsonRequired]
    [JsonProperty("supplierId")]
    public int SupplierId { get; set; }
}

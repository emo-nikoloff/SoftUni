using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Import;

public class ImportCarDto
{
    [Required]
    [JsonProperty("make")]
    public string Make { get; set; } = null!;

    [Required]
    [JsonProperty("model")]
    public string Model { get; set; } = null!;

    [JsonProperty("traveledDistance")]
    public long TraveledDistance { get; set; }

    [JsonProperty("partsId")]
    public int[] PartsIds { get; set; } = Array.Empty<int>();
}

using Newtonsoft.Json;

namespace ProductShop.DTOs.Export;

public class ExportUserWithSoldProducts
{
    [JsonProperty("firstName")]
    public string? FirstName { get; set; } = null!;

    [JsonProperty("lastName")]
    public string LastName { get; set; } = null!;

    [JsonProperty("soldProducts")]
    public ExportSoldProductDto[] SoldProducts { get; set; } = null!;
}

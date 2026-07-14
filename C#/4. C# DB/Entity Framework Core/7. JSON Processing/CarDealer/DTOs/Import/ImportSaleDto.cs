using Newtonsoft.Json;

namespace CarDealer.DTOs.Import;

public class ImportSaleDto
{
    [JsonRequired]
    [JsonProperty("carId")]
    public int CarId { get; set; }

    [JsonRequired]
    [JsonProperty("customerId")]
    public int CustomerId { get; set; }

    [JsonRequired]
    [JsonProperty("discount")]
    public int Discount { get; set; }
}

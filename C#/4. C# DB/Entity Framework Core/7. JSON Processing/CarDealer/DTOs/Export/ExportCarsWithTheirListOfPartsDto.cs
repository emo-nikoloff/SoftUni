using Newtonsoft.Json;

namespace CarDealer.DTOs.Export;

public class ExportCarsWithTheirListOfPartsDto
{
    [JsonProperty("car")]
    public ExportCarInfoDto Car { get; set; } = null!;

    [JsonProperty("parts")]
    public IEnumerable<ExportPartInfoDto> Parts { get; set; } = null!;
}

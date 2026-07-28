using Newtonsoft.Json;

namespace TravelAgency.DataProcessor.ExportDtos;

public class ExportBookingHorseRidingTourPackage
{
    [JsonProperty("TourPackageName")]
    public string TourPackageName { get; set; } = null!;

    [JsonProperty("Date")]
    public string Date { get; set; } = null!;
}

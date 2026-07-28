using Newtonsoft.Json;

namespace TravelAgency.DataProcessor.ExportDtos;

public class ExportCustomerWithHorseRidingTourPackageDto
{
    [JsonProperty("FullName")]
    public string FullName { get; set; } = null!;

    [JsonProperty("PhoneNumber")]
    public string PhoneNumber { get; set; } = null!;

    [JsonProperty("Bookings")]
    public ExportBookingHorseRidingTourPackage[] Bookings { get; set; } = null!;
}

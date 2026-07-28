using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

using static TravelAgency.Common.EntityValidationConstants;

namespace TravelAgency.DataProcessor.ImportDtos;

public class ImportBookingDto
{
    [Required]
    [JsonProperty("BookingDate")]
    public string BookingDate { get; set; } = null!;

    [Required]
    [StringLength(CustomerFullNameMaxLength,
        MinimumLength = CustomerFullNameMinLength)]
    [JsonProperty("CustomerName")]
    public string CustomerName { get; set; } = null!;

    [Required]
    [StringLength(TourPackagePackageNameMaxLength,
        MinimumLength = TourPackagePackageNameMinLength)]
    [JsonProperty("TourPackageName")]
    public string TourPackageName { get; set; } = null!;
}

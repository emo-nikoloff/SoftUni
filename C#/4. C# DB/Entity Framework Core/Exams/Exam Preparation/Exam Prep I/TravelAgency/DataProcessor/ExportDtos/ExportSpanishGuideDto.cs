using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos;

[XmlType("Guide")]
public class ExportSpanishGuideDto
{
    [XmlElement("FullName")]
    public string FullName { get; set; } = null!;

    [XmlArray("TourPackages")]
    public ExportGuideTourPackageDto[] TourPackages { get; set; } = Array.Empty<ExportGuideTourPackageDto>();
}

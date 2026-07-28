using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor;

public class Serializer
{
    public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext dbContext)
    {
        ExportSpanishGuideDto[] spanishGuides = dbContext.Guides
            .AsNoTracking()
            .Where(g => g.Language == Language.Spanish)
            .Select(g => new ExportSpanishGuideDto()
            {
                FullName = g.FullName,
                TourPackages = g.TourPackagesGuides.Select(tpg => new ExportGuideTourPackageDto()
                {
                    PackageName = tpg.TourPackage.PackageName,
                    Description = tpg.TourPackage.Description,
                    Price = tpg.TourPackage.Price,
                })
                .OrderByDescending(tp => tp.Price)
                .ThenBy(tp => tp.PackageName)
                .ToArray(),
            })
            .OrderByDescending(g => g.TourPackages.Length)
            .ThenBy(g => g.FullName)
            .ToArray();

        string result = XmlSerializerWrapper.Serialize(spanishGuides, "Guides");

        return result;
    }

    public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext dbContext)
    {
        ExportCustomerWithHorseRidingTourPackageDto[] customersHorseRiding = dbContext.Customers
            .AsNoTracking()
            .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
            .Select(c => new ExportCustomerWithHorseRidingTourPackageDto()
            {
                FullName = c.FullName,
                PhoneNumber = c.PhoneNumber,
                Bookings = c.Bookings
                    .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                    .OrderBy(b => b.BookingDate)
                    .Select(b => new ExportBookingHorseRidingTourPackage()
                    {
                        TourPackageName = b.TourPackage.PackageName,
                        Date = b.BookingDate.ToString("yyyy-MM-dd"),
                    })
                    .ToArray(),
            })
            .OrderByDescending(c => c.Bookings.Length)
            .ThenBy(c => c.FullName)
            .ToArray();

        string result = JsonConvert.SerializeObject(customersHorseRiding, Formatting.Indented);

        return result.TrimEnd();
    }
}


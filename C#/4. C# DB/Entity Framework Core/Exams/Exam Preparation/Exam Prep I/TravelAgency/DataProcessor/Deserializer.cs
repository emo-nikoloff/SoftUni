using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Globalization;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using TravelAgency.Utilities;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data format!";
    private const string DuplicationDataMessage = "Error! Data duplicated.";
    private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
    private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

    public static string ImportCustomers(TravelAgencyContext dbContext, string xmlString)
    {
        StringBuilder result = new();

        IEnumerable<ImportCustomerDto>? customerDtos = XmlSerializerWrapper.Deserialize<ImportCustomerDto[]>(xmlString, "Customers");
        if (customerDtos == null)
        {
            return result.ToString();
        }

        ICollection<Customer> validCustomers = dbContext.Customers
            .AsNoTracking()
            .ToArray();

        ICollection<Customer> customers = new List<Customer>();
        foreach (ImportCustomerDto customerDto in customerDtos)
        {
            if (!IsValid(customerDto))
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            bool isDuplication = validCustomers.Any(c => c.FullName == customerDto.FullName
                                                    || c.Email == customerDto.Email
                                                    || c.PhoneNumber == customerDto.PhoneNumber)
                                || customers.Any(c => c.FullName == customerDto.FullName
                                                    || c.Email == customerDto.Email
                                                    || c.PhoneNumber == customerDto.PhoneNumber);
            if (isDuplication)
            {
                result.AppendLine(DuplicationDataMessage);
                continue;
            }

            Customer customer = new()
            {
                FullName = customerDto.FullName,
                Email = customerDto.Email,
                PhoneNumber = customerDto.PhoneNumber,
            };

            customers.Add(customer);
            result.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
        }

        dbContext.Customers.AddRange(customers);
        dbContext.SaveChanges();

        return result.ToString().TrimEnd();
    }

    public static string ImportBookings(TravelAgencyContext dbContext, string jsonString)
    {
        StringBuilder result = new();

        IEnumerable<ImportBookingDto>? bookingDtos = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);
        if (bookingDtos == null)
        {
            return result.ToString();
        }

        ICollection<Customer> validCustomers = dbContext.Customers
            .AsNoTracking()
            .ToArray();
        ICollection<TourPackage> validTourPackages = dbContext.TourPackages
            .AsNoTracking()
            .ToArray();

        ICollection<Booking> bookings = new List<Booking>();
        foreach (ImportBookingDto bookingDto in bookingDtos)
        {
            if (!IsValid(bookingDto))
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            bool isBookingDateValid = DateTime.TryParseExact(bookingDto.BookingDate,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime bookingDate);
            if (!isBookingDateValid)
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            Customer? customer = validCustomers.FirstOrDefault(c => c.FullName == bookingDto.CustomerName);
            TourPackage? tourPackage = validTourPackages.FirstOrDefault(tp => tp.PackageName == bookingDto.TourPackageName);
            if (customer == null || tourPackage == null)
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            Booking booking = new()
            {
                BookingDate = bookingDate,
                CustomerId = customer.Id,
                TourPackageId = tourPackage.Id,
            };

            bookings.Add(booking);
            result.AppendLine(string.Format(SuccessfullyImportedBooking,
                tourPackage.PackageName,
                booking.BookingDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
        }

        dbContext.Bookings.AddRange(bookings);
        dbContext.SaveChanges();

        return result.ToString().TrimEnd();
    }

    public static bool IsValid(object dto)
    {
        var validateContext = new ValidationContext(dto);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

        foreach (var validationResult in validationResults)
        {
            string currValidationMessage = validationResult.ErrorMessage;
        }

        return isValid;
    }
}

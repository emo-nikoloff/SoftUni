using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using NetPay.Utilities;

namespace NetPay.DataProcessor;

public class Serializer
{
    public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext dbContext)
    {
        ExportHouseholdUnpaidExpensesDto[] householdsWithExpensesToPay = dbContext.Households
            .AsNoTracking()
            .Include(h => h.Expenses)
            .ThenInclude(e => e.Service)
            .Where(h => h.Expenses.Any(e => e.PaymentStatus != PaymentStatus.Paid))
            .OrderBy(h => h.ContactPerson)
            .AsEnumerable()
            .Select(h => new ExportHouseholdUnpaidExpensesDto()
            {
                ContactPerson = h.ContactPerson,
                Email = h.Email,
                PhoneNumber = h.PhoneNumber,
                UnpaidExpenses = h.Expenses
                    .Where(e => e.PaymentStatus != PaymentStatus.Paid)
                    .Select(e => new ExportUnpaidExpenseDto()
                    {
                        ExpenseName = e.ExpenseName,
                        Amount = e.Amount.ToString("f2"),
                        DueDate = e.DueDate.ToString("yyyy-MM-dd"),
                        ServiceName = e.Service.ServiceName,
                    })
                    .OrderBy(e => e.DueDate)
                    .ThenBy(e => e.Amount)
                    .ToArray(),
            })
            .ToArray();

        string result = XmlSerializerWrapper.Serialize(householdsWithExpensesToPay, "Households");

        return result;
    }

    public static string ExportAllServicesWithSuppliers(NetPayContext dbContext)
    {
        var servicesSuppliers = dbContext.Services
             .AsNoTracking()
             .Select(s => new
             {
                 s.ServiceName,
                 Suppliers = s.SuppliersServices
                     .Select(ss => new
                     {
                         ss.Supplier.SupplierName,
                     })
                     .OrderBy(sup => sup.SupplierName)
                     .ToArray(),
             })
             .OrderBy(s => s.ServiceName)
             .ToArray();

        string result = JsonConvert.SerializeObject(servicesSuppliers, Formatting.Indented);

        return result;
    }
}

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

using Microsoft.EntityFrameworkCore;

using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;

namespace NetPay.DataProcessor;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data format!";
    private const string DuplicationDataMessage = "Error! Data duplicated.";
    private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
    private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

    public static string ImportHouseholds(NetPayContext dbContext, string xmlString)
    {
        StringBuilder result = new();

        IEnumerable<ImportHouseholdDto>? householdDtos = XmlSerializerWrapper.Deserialize<ImportHouseholdDto[]>(xmlString, "Households");
        if (householdDtos == null)
        {
            return result.ToString();
        }

        IEnumerable<Household> validHouseholds = dbContext.Households
            .AsNoTracking()
            .ToArray();

        ICollection<Household> householdsToPersist = new List<Household>();
        foreach (ImportHouseholdDto householdDto in householdDtos)
        {
            if (!IsValid(householdDto))
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            bool isDuplicate = validHouseholds.Any(h => h.ContactPerson == householdDto.ContactPerson
                                                || h.Email == householdDto.Email
                                                || h.PhoneNumber == householdDto.PhoneNumber)
                                // Съвет: винаги проверявайте за дубликати и в колекцията за имтортване в базата
                                || householdsToPersist.Any(h => h.ContactPerson == householdDto.ContactPerson
                                                || h.Email == householdDto.Email
                                                || h.PhoneNumber == householdDto.PhoneNumber);
            if (isDuplicate)
            {
                result.AppendLine(DuplicationDataMessage);
                continue;
            }

            Household newHousehold = new()
            {
                ContactPerson = householdDto.ContactPerson,
                Email = householdDto.Email,
                PhoneNumber = householdDto.PhoneNumber,
            };

            householdsToPersist.Add(newHousehold);

            result.AppendLine(string.Format(SuccessfullyImportedHousehold, newHousehold.ContactPerson));
        }

        dbContext.Households.AddRange(householdsToPersist);
        dbContext.SaveChanges();

        return result.ToString().TrimEnd();
    }

    public static string ImportExpenses(NetPayContext dbContext, string jsonString)
    {
        StringBuilder result = new();

        IEnumerable<ImportExpenseDto>? expenseDtos = JsonConvert.DeserializeObject<ImportExpenseDto[]>(jsonString);
        if (expenseDtos == null)
        {
            return result.ToString();
        }

        IEnumerable<int> validHouseholdIds = dbContext.Households
            .AsNoTracking()
            .Select(h => h.Id)
            .ToArray();
        IEnumerable<int> validServiceIds = dbContext.Services
            .AsNoTracking()
            .Select(s => s.Id)
            .ToArray();

        ICollection<Expense> expensesToPersist = new List<Expense>();
        foreach (ImportExpenseDto expenseDto in expenseDtos)
        {
            if (!IsValid(expenseDto))
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            bool isDueDateValidFormat = DateTime.TryParseExact(expenseDto.DueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime expenseDueDate);
            bool isPaymentStatusValid = Enum.TryParse(expenseDto.PaymentStatus, out PaymentStatus expensePaymentStatus);
            if (!isDueDateValidFormat || !isPaymentStatusValid)
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            if (!validHouseholdIds.Contains(expenseDto.HouseholdId)
                || !validServiceIds.Contains(expenseDto.ServiceId))
            {
                result.AppendLine(ErrorMessage);
                continue;
            }

            Expense newExpense = new()
            {
                ExpenseName = expenseDto.ExpenseName,
                Amount = expenseDto.Amount,
                DueDate = expenseDueDate,
                PaymentStatus = expensePaymentStatus,
                HouseholdId = expenseDto.HouseholdId,
                ServiceId = expenseDto.ServiceId,
            };

            expensesToPersist.Add(newExpense);

            result.AppendLine(string.Format(SuccessfullyImportedExpense, newExpense.ExpenseName, newExpense.Amount.ToString("f2")));
        }

        dbContext.Expenses.AddRange(expensesToPersist);
        dbContext.SaveChanges();

        return result.ToString().TrimEnd();
    }

    public static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

        foreach (var result in validationResults)
        {
            string currvValidationMessage = result.ErrorMessage;
        }

        return isValid;
    }
}

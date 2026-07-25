using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

using static NetPay.Common.ValidationConstants;

namespace NetPay.DataProcessor.ImportDtos;

public class ImportExpenseDto
{
    [Required]
    [StringLength(ExpenseNameMaxLength,
        MinimumLength = ExpenseNameMinLength)]
    [JsonProperty("ExpenseName")]
    public string ExpenseName { get; set; } = null!;

    [Range(typeof(decimal), ExpenseAmountRangeMinValue, ExpenseAmountRangeMaxValue)]
    [JsonProperty("Amount")]
    public decimal Amount { get; set; }

    [Required]
    [JsonProperty("DueDate")]
    public string DueDate { get; set; } = null!;

    [Required]
    [JsonProperty("PaymentStatus")]
    public string PaymentStatus { get; set; } = null!;

    [JsonProperty("HouseholdId")]
    public int HouseholdId { get; set; }

    [JsonProperty("ServiceId")]
    public int ServiceId { get; set; }
}

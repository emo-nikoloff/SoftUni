namespace NetPay.Common;

public class ValidationConstants
{
    // Household
    public const int HouseholdContactPersonMinLength = 5; // NOTE: валидация за DTO
    public const int HouseholdContactPersonMaxLength = 50; // NOTE: валидация за DB и DTO

    public const int HouseholdEmailMinLength = 6; // NOTE: валидация за DTO
    public const int HouseholdEmailMaxLength = 80; // NOTE: валидация за DB и DTO

    public const int HouseholdPhoneNumberLength = 15; // NOTE: валидация за DB и DTO
    public const string HouseholdPhoneNumberRegexPattern = @"^\+\d{3}\/\d{3}\-\d{6}$"; // NOTE: валидация за DTO

    // Expense
    public const int ExpenseNameMinLength = 5; // NOTE: валидация за DTO
    public const int ExpenseNameMaxLength = 50; // NOTE: валидация за DB и DTO

    public const string ExpenseAmountRangeMinValue = "0.01"; // NOTE: валидация за DTO
    public const string ExpenseAmountRangeMaxValue = "100000"; // NOTE: валидация за DTO

    // Service
    public const int ServiceNameMinLength = 5; // NOTE: валидация за DTO
    public const int ServiceNameMaxLength = 30; // NOTE: валидация за DB и DTO

    // Supplier
    public const int SupplierNameMinLength = 3; // NOTE: валидация за DTO
    public const int SupplierNameMaxLength = 60; // NOTE: валидация за DB и DTO
}

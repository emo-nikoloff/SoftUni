using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos;

[XmlType("Household")]
public class ExportHouseholdUnpaidExpensesDto
{
    [XmlElement("ContactPerson")]
    public string ContactPerson { get; set; } = null!;

    [XmlElement("Email")]
    public string? Email { get; set; }

    [XmlElement("PhoneNumber")]
    public string PhoneNumber { get; set; } = null!;

    [XmlArray("Expenses")]
    public ExportUnpaidExpenseDto[] UnpaidExpenses { get; set; } = Array.Empty<ExportUnpaidExpenseDto>();
}

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetPay.Data.Models;

[PrimaryKey(nameof(SupplierId), nameof(ServiceId))]
public class SupplierService
{
    [ForeignKey(nameof(Supplier))]
    public int SupplierId { get; set; }

    public virtual Supplier Supplier { get; set; } = null!;

    [ForeignKey(nameof(Service))]
    public int ServiceId { get; set; }

    public virtual Service Service { get; set; } = null!;
}

using System.ComponentModel.DataAnnotations;

using GarageApp.Data.Models.Enums;
using static GarageApp.Common.EntityValidation;

namespace GarageApp.Data.Models;

public class Car
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CarMakeMaxLength)]
    public string Make { get; set; } = null!;

    [Required]
    [MaxLength(CarMakeMaxLength)]
    public string Model { get; set; } = null!;

    public int? ProductionMonth { get; set; }

    public int Year { get; set; }

    public CarType Type { get; set; }

    public bool IsAvailable { get; set; }

    public int GarageId { get; set; }

    public virtual Garage Garage { get; set; } = null!;
}

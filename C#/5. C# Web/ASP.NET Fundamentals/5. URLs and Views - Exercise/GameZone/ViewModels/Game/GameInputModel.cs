using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using GameZone.ViewModels.Genre;
using static GameZone.Common.ValidationConstants.Game;

namespace GameZone.ViewModels.Game;

public class GameInputModel
{
    // InputModel - UNTRUSTED Client App -> TRUSTED Server App - трябва да извършим Model Validation

    // Inputs - UNTRUSTED -> TRUSTED
    [Required]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
    public string Description { get; set; } = null!;

    [Url]
    [MaxLength(ImageUrlMaxLength)]
    public string? ImageUrl { get; set; }

    [Required]
    [StringLength(PublisherMaxLength, MinimumLength = PublisherMinLength)]
    public string PublisherName { get; set; } = null!;

    public DateTime ReleasedOn { get; set; }

    public int GenreId { get; set; }
    // *****************************

    // Outputs - TRUSTED -> UNTRUSTED
    [BindNever]
    public IEnumerable<GenreDropdownViewModel> Genres { get; set; } = new List<GenreDropdownViewModel>();
    // *****************************
}

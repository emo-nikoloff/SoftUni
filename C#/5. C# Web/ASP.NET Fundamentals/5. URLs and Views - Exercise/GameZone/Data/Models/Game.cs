using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static GameZone.Common.ValidationConstants.Game;

namespace GameZone.Data.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [Required]
        [MaxLength(PublisherMaxLength)]
        public string PublisherName { get; set; } = null!;

        [Required]
        [Column(TypeName = "DATETIME2")]
        public DateTime ReleasedOn { get; set; }

        [Required]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

using static GameZone.Common.ValidationConstants.Genre;

namespace GameZone.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}

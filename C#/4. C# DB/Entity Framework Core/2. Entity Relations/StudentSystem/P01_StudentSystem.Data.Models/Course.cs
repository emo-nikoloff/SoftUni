using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data.Models;

public class Course
{
    [Key]
    public int CourseId { get; set; }

    [Required]
    [MaxLength(80)]
    [Unicode(true)]
    public string Name { get; set; } = null!;

    [Unicode(true)]
    public string? Description { get; set; }

    [Column(TypeName = "DATETIME2")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "DATETIME2")]
    public DateTime EndDate { get; set; }

    [Column(TypeName = "DECIMAL(8, 2)")]
    public decimal Price { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; } = new HashSet<StudentCourse>();

    public virtual ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();

    public virtual ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();
}

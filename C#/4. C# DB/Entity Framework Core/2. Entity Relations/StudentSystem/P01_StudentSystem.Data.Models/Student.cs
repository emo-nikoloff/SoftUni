using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data.Models;

public class Student
{
    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(100)]
    [Unicode(true)]
    public string Name { get; set; } = null!; // по подразбиране string се запазва в базата като NVARCHAR - не е задължително да описваме допълнително, че колоната поддържа Unicode символи

    [Column(TypeName = "CHAR(10)")]
    public string? PhoneNumber { get; set; }

    [Column(TypeName = "DATETIME2")]
    public DateTime RegisteredOn { get; set; }

    [Column(TypeName = "SMALLDATETIME")]
    public DateTime? Birthday { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; } = new HashSet<StudentCourse>();

    public virtual ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();
}

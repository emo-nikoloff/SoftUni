using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data;

public class StudentSystemContext : DbContext
{
    public StudentSystemContext()
    {

    }

    public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Student> Students { get; set; } = null!;

    public virtual DbSet<Course> Courses { get; set; } = null!;

    public virtual DbSet<Resource> Resources { get; set; } = null!;

    public virtual DbSet<Homework> Homeworks { get; set; } = null!;

    public virtual DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=StudentSystem;Trusted_Connection=True;TrustServerCertificate=True;")
                .LogTo(Console.WriteLine);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(sc => new { sc.StudentId, sc.CourseId });
        });
    }
}

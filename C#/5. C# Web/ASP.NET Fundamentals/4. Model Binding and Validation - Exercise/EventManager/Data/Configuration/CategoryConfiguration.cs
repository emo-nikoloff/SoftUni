using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EventManager.Data.Models;

namespace EventManager.Data.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public readonly static List<Category> Categories = new()
    {
        new Category
        {
            Id= 1,
            Name= "Conference"
        },
        new Category
        {
            Id= 2,
            Name= "Workshop"
        },
        new Category
        {
            Id= 3,
            Name= "Seminar"
        },
        new Category
        {
            Id= 4,
            Name= "Training"
        },
        new Category
        {
            Id= 5,
            Name= "Meetup"
        },
        new Category
        {
            Id= 6,
            Name= "Hackathon"
        },
        new Category
        {
            Id= 7,
            Name= "Webinar"
        },
        new Category
        {
            Id= 8,
            Name= "Bootcamp"
        }
    };

    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(Categories);
    }
}

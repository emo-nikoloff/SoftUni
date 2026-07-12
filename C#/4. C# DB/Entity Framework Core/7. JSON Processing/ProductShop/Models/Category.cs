namespace ProductShop.Models;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CategoryProduct> CategoriesProducts { get; set; } = new List<CategoryProduct>();
}
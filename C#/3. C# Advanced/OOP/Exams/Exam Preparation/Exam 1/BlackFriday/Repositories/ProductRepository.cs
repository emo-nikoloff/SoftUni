using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;

namespace BlackFriday.Repositories;

public class ProductRepository : IRepository<IProduct>
{
    private List<IProduct> models;

    public ProductRepository()
    {
        models = new();
    }

    public IReadOnlyCollection<IProduct> Models => models;

    public void AddNew(IProduct model) => models.Add(model);

    public IProduct GetByName(string name) => models.FirstOrDefault(p => p.ProductName == name)!;

    public bool Exists(string name) => models.Any(p => p.ProductName == name);
}

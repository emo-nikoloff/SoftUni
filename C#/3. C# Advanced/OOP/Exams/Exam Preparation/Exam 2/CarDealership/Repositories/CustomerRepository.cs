using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories;

public class CustomerRepository : IRepository<ICustomer>
{
    private List<ICustomer> models;

    public CustomerRepository()
    {
        models = new();
    }

    public IReadOnlyCollection<ICustomer> Models => models;

    public void Add(ICustomer customer) => models.Add(customer);

    public bool Remove(string name)
    {
        ICustomer? customer = models.FirstOrDefault(c => c.Name == name)!;
        return models.Remove(customer);
    }

    public bool Exists(string name) => models.Any(c => c.Name == name);

    public ICustomer Get(string name) => models.FirstOrDefault(c => c.Name == name)!;
}

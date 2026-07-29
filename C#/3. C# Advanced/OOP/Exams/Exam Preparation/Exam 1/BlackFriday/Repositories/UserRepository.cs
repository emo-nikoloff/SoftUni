using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;

namespace BlackFriday.Repositories;

public class UserRepository : IRepository<IUser>
{
    private List<IUser> models;

    public UserRepository()
    {
        models = new();
    }

    public IReadOnlyCollection<IUser> Models => models;

    public void AddNew(IUser model) => models.Add(model);

    public IUser GetByName(string name) => models.FirstOrDefault(u => u.UserName == name)!;

    public bool Exists(string name) => models.Any(u => u.UserName == name);
}

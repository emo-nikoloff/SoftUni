namespace BlackFriday.Models.Users;

public class Client : User
{
    private Dictionary<string, bool> purchases;

    public Client(string userName, string email) : base(userName, hasDataAccess: false, email)
    {
        purchases = new();
    }

    public IReadOnlyDictionary<string, bool> Purchases => purchases;

    public void PurchaseProduct(string productName, bool blackFridayFlag) => purchases[productName] = blackFridayFlag;
}

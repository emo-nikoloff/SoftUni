namespace BlackFriday.Models.Users;

public class Client : User
{
    private Dictionary<string, bool> purchases;

    public Client(string userName, string email) : base(userName, false, email)
    {
        purchases = new();
    }

    public override bool HasDataAccess => false;

    public IReadOnlyDictionary<string, bool> Purchases => purchases;

    public void PurchaseProduct(string productName, bool blackFridayFlag) => purchases[productName] = blackFridayFlag;
}

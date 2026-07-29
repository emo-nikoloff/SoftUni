namespace BlackFriday.Models.Users;

public class Admin : User
{
    public Admin(string userName, string email) : base(userName, true, email)
    {
    }

    public override bool HasDataAccess => true;
}

using BlackFriday.Models.Contracts;

namespace BlackFriday.Models;

public abstract class User : IUser
{
    private string userName;
    private bool hasDataAccess;
    private string email;

    protected User()
    {

    }

    public string UserName
    {
        get => userName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Username is required.");
            }
            userName = value;
        }
    }

    public bool HasDataAccess
    {
        get => hasDataAccess;
        private set => hasDataAccess = value;
    }

    public string Email
    {
        get => email;
        private set
        {
            if (HasDataAccess)
            {
                email = "hidden";
                return;
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Email is required.");
            }

            email = value;
        }
    }
}

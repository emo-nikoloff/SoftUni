using BlackFriday.Models.Contracts;
using static BlackFriday.Utilities.Messages.ExceptionMessages;

namespace BlackFriday.Models;

public abstract class User : IUser
{
    private string userName = null!;

    private bool hasDataAccess;

    private string email = null!;

    protected User(string userName, bool hasDataAccess, string email)
    {
        UserName = userName;
        HasDataAccess = hasDataAccess;
        Email = email;
    }

    public string UserName
    {
        get => userName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(UserNameRequired);
            }
            userName = value;
        }
    }

    public virtual bool HasDataAccess
    {
        get => hasDataAccess;
        private set => hasDataAccess = value;
    }

    public string Email
    {
        get => email;
        private set
        {
            if (!HasDataAccess)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(EmailRequired);
                }
                email = value;
            }
            else
            {
                email = "hidden";
            }
        }
    }

    public override string ToString() => $"{UserName} - Status: {GetType().Name}, Contact Info: {Email}";
}

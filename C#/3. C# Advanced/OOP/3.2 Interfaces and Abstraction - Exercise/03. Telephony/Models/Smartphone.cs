using Telephony.Interfaces;

namespace Telephony.Models;

public class Smartphone : ICallable, IBrowsable
{
    public string Call(string number)
    {
        if (!number.All(digit => char.IsDigit(digit)))
        {
            throw new ArgumentException($"Invalid number!");
        }
        return $"Calling... {number}";
    }

    public string Browse(string url)
    {
        if (url.Any(char.IsDigit))
        {
            throw new ArgumentException($"Invalid URL!");
        }
        return $"Browsing: {url}!";
    }
}

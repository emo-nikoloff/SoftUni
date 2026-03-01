using Telephony.Models.Interfaces;

namespace Telephony.Models;

public class StationaryPhone : ICallable
{
    public string Call(string number)
    {
        if (number.All(digit => char.IsDigit(digit)))
        {
            return $"Dialing... {number}";
        }
        return $"Invalid number!";
    }
}

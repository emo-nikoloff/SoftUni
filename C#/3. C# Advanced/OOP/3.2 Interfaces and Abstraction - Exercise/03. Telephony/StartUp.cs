using Telephony.Models;

namespace Telephony;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string phoneNumber in phoneNumbers)
        {
            try
            {
                if (phoneNumber.Length == 7)
                {
                    StationaryPhone phone = new();
                    Console.WriteLine(phone.Call(phoneNumber));
                }
                else if (phoneNumber.Length == 10)
                {
                    Smartphone phone = new();
                    Console.WriteLine(phone.Call(phoneNumber));
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (string url in urls)
        {
            try
            {

                Smartphone phone = new();
                Console.WriteLine(phone.Browse(url));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

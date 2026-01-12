/*Create a program that checks if a given password is valid.
The password validation rules are:
· It should contain 6 – 10 characters (inclusive)
· It should contain only letters and digits
· It should contain at least 2 digits
If it is not valid, for any unfulfilled rule print the corresponding message:
· "Password must be between 6 and 10 characters"
· "Password must consist only of letters and digits"
· "Password must have at least 2 digits"
*Hints
Write a method for each rule.*/
using System;

namespace _04._Password_Validator;

class Program
{
    static void Main(string[] args)
    {
        string password = Console.ReadLine();

        bool lengthCheck = CheckLength(password);
        bool symbolCheck = CheckSymbols(password);
        bool digitsCheck = CheckForDigits(password);

        if (!lengthCheck)
        {
            Console.WriteLine("Password must be between 6 and 10 characters");
        }
        if (!symbolCheck)
        {
            Console.WriteLine("Password must consist only of letters and digits");
        }
        if (!digitsCheck)
        {
            Console.WriteLine("Password must have at least 2 digits");
        }
        if (lengthCheck && symbolCheck && digitsCheck)
        {
            Console.WriteLine("Password is valid");
        }
    }

    static bool CheckLength(string password)
    {
        if (password.Length < 6 || password.Length > 10)
        {
            return false;
        }
        return true;
    }
    static bool CheckSymbols(string password)
    {
        foreach (char symbol in password)
        {
            if (symbol >= 48 && symbol <= 57 ||
            symbol >= 65 && symbol <= 90 ||
            symbol >= 97 && symbol <= 122)
            {
                continue;
            }
            return false;
        }
        return true;
    }
    static bool CheckForDigits(string password)
    {
        int digitsCounter = 0;
        foreach (char symbol in password)
        {
            if (symbol >= 48 && symbol <= 57)
            {
                digitsCounter++;
            }
        }

        if (digitsCounter < 2)
        {
            return false;
        }
        return true;
    }
}

/*Create a program that reads user names on a single line (joined by ", ") and prints all valid usernames.
A valid username
· has length between 3 and 16 characters
· contains only letters, numbers, hyphens and underscores*/
using System;
using System.Linq;

namespace _01._Valid_Usernames;

class Program
{
    static void Main(string[] args)
    {
        string[] usernames = Console.ReadLine().Split(", ");

        foreach (string username in usernames)
        {
            if (username.Length >= 3 && username.Length <= 16)
            {
                bool isValidUsername = username.All(character => char.IsLetterOrDigit(character) || character == '-' || character == '_');

                if (isValidUsername)
                {
                    Console.WriteLine(username);
                }
            }
        }
    }
}

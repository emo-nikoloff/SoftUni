/*Create a program that returns an encrypted version of the same text. Encrypt the text by shifting each character with three positions forward. For example, A would be replaced by D, B would become E
and so on. Print the encrypted text.*/
using System;

namespace _04._Caesar_Cipher;

class Program
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();

        string encryptedText = string.Empty;

        foreach (char symbol in text)
        {
            encryptedText += (char)(symbol + 3);
        }

        Console.WriteLine(encryptedText);
    }
}

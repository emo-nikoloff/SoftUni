/*You will receive a key (integer) and n characters afterward. Add the key to each of the characters and append them to a message. At the end print the message, which you decrypted.
· On the first line, you will receive the key.
· On the second line, you will receive n – the number of lines, which will follow.
· On the next n lines, you will receive lower and uppercase characters from the Latin alphabet.
Print the decrypted message.*/
using System;

namespace _05._Decrypting_Message;

class Program
{
    static void Main(string[] args)
    {
        int key = int.Parse(Console.ReadLine());
        int lines = int.Parse(Console.ReadLine());

        string result = string.Empty;
        for (int line = 1; line <= lines; line++)
        {
            char letter = char.Parse(Console.ReadLine());
            letter = (char)(letter + key);
            result += letter;
        }
        Console.WriteLine(result);
    }
}

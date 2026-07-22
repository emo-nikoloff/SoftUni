using System;
using System.Text.RegularExpressions;

namespace _02._Message_Decrypter;

class Program
{
    static void Main(string[] args)
    {
        int inputsNumber = int.Parse(Console.ReadLine());

        for (int i = 1; i <= inputsNumber; i++)
        {
            string input = Console.ReadLine();
            string pattern = @"^(?<separator>[$%])(?<tag>[A-Z][a-z]{2,})\k<separator>: \[(?<num1>\d+)\]\|\[(?<num2>\d+)\]\|\[(?<num3>\d+)\]\|$";

            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string tag = match.Groups["tag"].Value;
                int num1 = int.Parse(match.Groups["num1"].Value);
                int num2 = int.Parse(match.Groups["num2"].Value);
                int num3 = int.Parse(match.Groups["num3"].Value);

                string decryptedMessage = $"{(char)num1}{(char)num2}{(char)num3}";

                Console.WriteLine($"{tag}: {decryptedMessage}");
            }
            else
            {
                Console.WriteLine("Valid message not found!");
            }
        }
    }
}

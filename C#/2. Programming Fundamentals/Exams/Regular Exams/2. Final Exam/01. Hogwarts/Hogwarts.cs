using System;

namespace _01._Hogwarts;

class Program
{
    static void Main(string[] args)
    {
        string spell = Console.ReadLine();

        string input;

        while ((input = Console.ReadLine()) != "Abracadabra")
        {
            string[] inputParts = input.Split();

            switch (inputParts[0])
            {
                case "Abjuration":
                    spell = spell.ToUpper();
                    Console.WriteLine(spell);
                    break;
                case "Necromancy":
                    spell = spell.ToLower();
                    Console.WriteLine(spell);
                    break;
                case "Illusion":
                    int index = int.Parse(inputParts[1]);
                    char letter = char.Parse(inputParts[2]);

                    if (index >= 0 && index < spell.Length)
                    {
                        spell = spell.Substring(0, index) + letter + spell.Substring(index + 1);

                        Console.WriteLine("Done!");
                    }
                    else
                    {
                        Console.WriteLine("The spell was too weak.");
                    }
                    break;
                case "Divination":
                    string firstSubstring = inputParts[1];
                    string secondSubstring = inputParts[2];
                    if (spell.Contains(firstSubstring))
                    {
                        spell = spell.Replace(firstSubstring, secondSubstring);
                        Console.WriteLine(spell);
                    }
                    break;
                case "Alteration":
                    string substring = inputParts[1];
                    if (spell.Contains(substring))
                    {
                        int substringIndex = spell.IndexOf(substring);
                        spell = spell.Remove(substringIndex, substring.Length);
                        Console.WriteLine(spell);
                    }
                    break;
                default:
                    Console.WriteLine("The spell did not work!");
                    break;
            }
        }
    }
}

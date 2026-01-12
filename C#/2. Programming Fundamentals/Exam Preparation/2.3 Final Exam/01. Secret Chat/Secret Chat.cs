/*You have plenty of free time, so you decide to write a program that conceals and reveals your received messages. Go ahead and type it in!
On the first line of the input, you will receive the concealed message. After that, until the "Reveal" command is given, you will receive strings with instructions for different operations that need to
be performed upon the concealed message to interpret it and reveal its actual content. There are several types of instructions, split by ":|:"
· "InsertSpace:|:{index}":
    o Inserts a single space at the given index. The given index will always be valid.
· "Reverse:|:{substring}":
    o If the message contains the given substring, cut it out, reverse it and add it at the end of the message.
    o If not, print "error".
    o This operation should replace only the first occurrence of the given substring if there are two or more occurrences.
· "ChangeAll:|:{substring}:|:{replacement}":
    o Changes all occurrences of the given substring with the replacement text.
· On the first line, you will receive a string with a message.
· On the following lines, you will be receiving commands, split by ":|:".
· After each set of instructions, print the resulting string.
· After the "Reveal" command is received, print this message: "You have a new text message: {message}"*/
using System;
using System.Linq;

namespace _01._Secret_Chat;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string command;

        while ((command = Console.ReadLine()) != "Reveal")
        {
            string[] commandParts = command.Split(":|:");

            string action = commandParts[0];

            switch (action)
            {
                case "InsertSpace":
                    int indexToInsert = int.Parse(commandParts[1]);
                    input = InsertSpace(input, indexToInsert);
                    break;
                case "Reverse":
                    string partToReverse = commandParts[1];
                    input = Reverse(input, partToReverse);
                    break;
                case "ChangeAll":
                    string originalLetter = commandParts[1];
                    string replacementLetter = commandParts[2];
                    input = ChangeAll(input, originalLetter, replacementLetter);
                    break;
            }
        }

        Console.WriteLine($"You have a new text message: {input}");
    }

    static string InsertSpace(string input, int index)
    {
        input = input.Insert(index, " ");

        Console.WriteLine(input);

        return input;
    }

    static string Reverse(string input, string reverse)
    {
        int reversePartIndex = input.IndexOf(reverse);
        if (reversePartIndex != -1)
        {
            string beforeSubstring = input.Substring(0, reversePartIndex);
            string afterSubstring = input.Substring(reversePartIndex + reverse.Length);
            string reversed = new(reverse.Reverse().ToArray());
            input = beforeSubstring + afterSubstring + reversed;

            Console.WriteLine(input);
        }
        else
        {
            Console.WriteLine("error");
        }
        return input;
    }

    static string ChangeAll(string input, string original, string replacement)
    {
        input = input.Replace(original, replacement);

        Console.WriteLine(input);

        return input;
    }
}

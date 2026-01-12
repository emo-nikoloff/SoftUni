/*Create a program that reads N lines of strings and extracts the name and age of a given person. The name of the person will be between '@' and '|'. The person's age will be between '#' and '*'.
Example: "Hello my name is @Peter| and I am #20* years old."
For each found name and age print a line in the following format "{name} is {age} years old."*/
using System;

namespace _01._Extract_Person_Information;

class Program
{
    static void Main(string[] args)
    {
        int stringsNumber = int.Parse(Console.ReadLine());

        for (int i = 1; i <= stringsNumber; i++)
        {
            string sentence = Console.ReadLine();

            int startName = sentence.IndexOf('@') + 1;
            int endName = sentence.IndexOf('|');
            string name = sentence.Substring(startName, endName - startName);

            int startAge = sentence.IndexOf('#') + 1;
            int endAge = sentence.IndexOf('*');
            string age = sentence.Substring(startAge, endAge - startAge);

            Console.WriteLine($"{name} is {age} years old.");
        }
    }
}

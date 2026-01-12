/*Create a program that keeps track of the guests that are going to a house party. On the first line, of input you are going to receive the number of commands that will follow.
On the next lines, you are going to receive some of the following: "{name} is going!"
· You have to add the person, if they are not on the guestlist already.
· If the person is on the list print the following to the console: "{name} is already in the list!"
"{name} is not going!"
· You have to remove the person, if they are on the list.
· If not, print out: "{name} is not in the list!"
Finally, print all of the guests, each on a new line.*/
using System;
using System.Collections.Generic;

namespace _03._House_Party;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());
        List<string> guests = new();

        for (int i = 0; i < magicNumber; i++)
        {
            string[] personAction = Console.ReadLine().Split();

            switch (personAction[2])
            {
                case "going!":
                    if (guests.Contains(personAction[0]))
                    {
                        Console.WriteLine($"{personAction[0]} is already in the list!");
                    }
                    else
                    {
                        guests.Add(personAction[0]);
                    }
                    break;
                case "not":
                    if (guests.Contains(personAction[0]))
                    {
                        guests.Remove(personAction[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{personAction[0]} is not in the list!");
                    }
                    break;
            }
        }

        for (int i = 0; i < guests.Count; i++)
        {
            Console.WriteLine(guests[i]);
        }
    }
}

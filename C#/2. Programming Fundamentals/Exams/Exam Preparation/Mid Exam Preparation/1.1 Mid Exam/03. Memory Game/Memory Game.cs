/*Write a program that recreates the Memory game.
On the first line, you will receive a sequence of elements. Each element in the sequence will have a twin. Until the player receives "end" from the console, you will receive strings with two integers
separated by a space, representing the indexes of elements in the sequence.
If the player tries to cheat and enters two equal indexes or indexes which are out of bounds of the sequence, you should add two matching elements at the middle of the sequence in the following format:
"-{number of moves until now}a"
Then print this message on the console:
"Invalid input! Adding additional elements to the board"
· On the first line, you will receive a sequence of elements
· On the following lines, you will receive integers until the command "end"
· Every time the player hit two matching elements, you should remove them from the sequence and print on the console the following message:
"Congrats! You have found matching elements - ${element}!"
· If the player hit two different elements, you should print on the console the following message:
"Try again!"
· If the player hit all matching elements before he receives "end" from the console, you should print on the console the following message:
"You have won in {number of moves until now} turns!"
· If the player receives "end" before he hits all matching elements, you should print on the console the following message:
"Sorry you lose :(
{the current sequence's state}"
· All elements in the sequence will always have a matching element.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Memory_Game;

class Program
{
    static void Main(string[] args)
    {
        List<string> elements = Console.ReadLine().Split().ToList();
        string input;

        int moves = 0;

        while ((input = Console.ReadLine()) != "end")
        {
            int[] indexes = input.Split().Select(int.Parse).ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            moves++;

            if (firstIndex == secondIndex ||
            firstIndex < 0 || secondIndex > elements.Count - 1 ||
            secondIndex < 0 || firstIndex > elements.Count - 1)
            {
                string newElement = $"-{moves}a";
                List<string> newElements = new() { newElement, newElement };

                elements.InsertRange(elements.Count / 2, newElements);

                Console.WriteLine("Invalid input! Adding additional elements to the board");
                continue;
            }

            if (elements[firstIndex] == elements[secondIndex])
            {
                string element = elements[firstIndex];
                Console.WriteLine($"Congrats! You have found matching elements - {element}!");

                if (firstIndex < secondIndex)
                {
                    elements.RemoveAt(firstIndex);
                    elements.RemoveAt(secondIndex - 1);
                }
                else
                {
                    elements.RemoveAt(secondIndex);
                    elements.RemoveAt(firstIndex - 1);
                }
            }
            else
            {
                Console.WriteLine("Try again!");
            }

            if (elements.Count == 0)
            {
                Console.WriteLine($"You have won in {moves} turns!");
                return;
            }
        }

        Console.WriteLine($"Sorry you lose :(\n{string.Join(" ", elements)}");
    }
}
/*You will be given two hands of cards, which will be represented by integers. Assume each one is held by a different player. You have to find which one has the winning deck. You start from the
beginning of both hands of cards. Compare the cards from the first deck to the cards from the second deck. The player, who holds the more powerful card on the current iteration, takes both cards and
puts them at the back of his hand - the second player's card is placed last and the first person's card (the winning one) comes after it (second to last). If both players' cards have the same
values - no one wins and the two cards must be removed from both hands. The game is over only when
one of the decks is left without any cards. You have to display the result on the console and the sum of the remaining cards: "{First/Second} player wins! Sum: {sum}".*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game;

class Program
{
    static void Main(string[] args)
    {
        List<int> firstHand = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<int> secondHand = Console.ReadLine().Split().Select(int.Parse).ToList();

        while (firstHand.Count > 0 && secondHand.Count > 0)
        {
            if (firstHand[0] > secondHand[0])
            {
                firstHand.Add(secondHand[0]);
                firstHand.Add(firstHand[0]);
                firstHand.RemoveAt(0);
                secondHand.RemoveAt(0);
            }
            else if (firstHand[0] < secondHand[0])
            {
                secondHand.Add(firstHand[0]);
                secondHand.Add(secondHand[0]);
                secondHand.RemoveAt(0);
                firstHand.RemoveAt(0);

            }
            else
            {
                firstHand.RemoveAt(0);
                secondHand.RemoveAt(0);
            }
        }

        if (firstHand.Count > secondHand.Count)
        {
            Console.WriteLine($"First player wins! Sum: {firstHand.Sum()}");
        }
        else
        {
            Console.WriteLine($"Second player wins! Sum: {secondHand.Sum()}");
        }
    }
}

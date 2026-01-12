/*Create a program, which helps you buy the games. The valid games are the following games in this table:
Name                            Price
OutFall 4                       $39.99
CS: OG                          $15.99
Zplinter Zell                   $19.99
Honored 2                       $59.99
RoverWatch                      $29.99
RoverWatch Origins Edition      $39.99
On the first line, you will receive your current balance – a floating-point number in the range [0.00…5000.00].
Until you receive the command "Game Time", you have to keep buying games. When a game is bought, the user's balance decreases by the price of the game.
Additionally, the program should obey the following conditions:
· If a game the user is trying to buy is not present in the table above, print "Not Found" and read the next line.
· If at any point, the user has $0 left, print "Out of money!" and end the program.
· Alternatively, if the user is trying to buy a game that they can't afford, print "Too Expensive" and read the next line.
· If the game exists and the player has the money for it, print "Bought {nameOfGame}".
When you receive "Game Time", print the user's remaining money and total spent on games, rounded to the 2nd decimal place.*/
using System;

namespace _03._Gaming_Store;

class Program
{
    static void Main(string[] args)
    {
        double budget = double.Parse(Console.ReadLine());
        string game;

        double spent = 0;
        while ((game = Console.ReadLine()) != "Game Time")
        {
            double gamePrice;
            switch (game)
            {
                case "OutFall 4":
                case "RoverWatch Origins Edition":
                    gamePrice = 39.99;
                    break;
                case "CS: OG":
                    gamePrice = 15.99;
                    break;
                case "Zplinter Zell":
                    gamePrice = 19.99;
                    break;
                case "Honored 2":
                    gamePrice = 59.99;
                    break;
                case "RoverWatch":
                    gamePrice = 29.99;
                    break;
                default:
                    Console.WriteLine("Not Found");
                    continue;
            }

            if (budget < gamePrice)
            {
                Console.WriteLine("Too Expensive");
                continue;
            }
            Console.WriteLine($"Bought {game}");
            spent += gamePrice;
            budget -= gamePrice;
            if (budget == 0)
            {
                Console.WriteLine("Out of money!");
                return;
            }
        }
        Console.WriteLine($"Total spent: ${spent:f2}. Remaining: ${budget:f2}");
    }
}

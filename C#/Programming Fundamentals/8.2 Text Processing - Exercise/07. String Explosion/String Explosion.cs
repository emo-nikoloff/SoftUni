/*Explosions are marked with '>'. Immediately after the mark, there will be an integer, which signifies the strength of the explosion.
You should remove x characters (where x is the strength of the explosion), starting after the punched character ('>').
If you find another explosion mark ('>') while you're deleting characters, you should add the strength to your previous explosion.
When all characters are processed, print the string without the deleted characters.
You should not delete the explosion character – '>', but you should delete the integers, which represent the strength.
You will receive a single line with the string.
Print what is left from the string after the explosions.*/
using System;
using System.Text;

namespace _07._String_Explosion;

class Program
{
    static void Main(string[] args)
    {
        string explosion = Console.ReadLine();

        StringBuilder processedExplosion = new();
        int strength = 0;

        for (int i = 0; i < explosion.Length; i++)
        {
            if (explosion[i] == '>')
            {
                strength += int.Parse(explosion[i + 1].ToString());
                processedExplosion.Append(explosion[i]);
            }
            else if (strength == 0)
            {
                processedExplosion.Append(explosion[i]);
            }
            else
            {
                strength--;
            }
        }

        Console.WriteLine(processedExplosion);
    }
}

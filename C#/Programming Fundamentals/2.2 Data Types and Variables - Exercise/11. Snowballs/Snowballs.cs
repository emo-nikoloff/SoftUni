/*Tony and Andi love playing in the snow and having snowball fights, but they always argue about which makes the best snowballs. They have decided to involve you in their fray by making you write a
program, which calculates snowball data and outputs the best snowball value.
You will receive N – an integer, the number of snowballs being made by Tony and Andi. For each snowball you will receive 3 input lines:
· On the first line, you will get the snowballSnow – an integer.
· On the second line you will get the snowballTime – an integer.
· On the third line, you will get the snowballQuality – an integer.
For each snowball you must calculate its snowballValue by the following formula:
(snowballSnow / snowballTime) ^ snowballQuality
In the end, you must print the highest calculated snowballValue.
· As output, you must print the highest calculated snowballValue, by the formula, specified above.
· The output format is: {snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})*/
using System;
using System.Numerics;

namespace _11._Snowballs;

class Program
{
    static void Main(string[] args)
    {
        int snowballs = int.Parse(Console.ReadLine());

        int highestSnowballSnow = 0, highestSnowballTime = 0, highestSnowballQuality = 0;
        BigInteger highestSnowballValue = 0;
        for (int snowball = 0; snowball < snowballs; snowball++)
        {
            int snowballSnow = int.Parse(Console.ReadLine());
            int snowballTime = int.Parse(Console.ReadLine());
            int snowballQuality = int.Parse(Console.ReadLine());

            BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

            if (snowballValue > highestSnowballValue)
            {
                highestSnowballSnow = snowballSnow;
                highestSnowballTime = snowballTime;
                highestSnowballQuality = snowballQuality;
                highestSnowballValue = snowballValue;
            }
        }
        Console.WriteLine($"{highestSnowballSnow} : {highestSnowballTime} = {highestSnowballValue:f0} ({highestSnowballQuality})");
    }
}

/*Write a program to calculate the winner of a car race. You will receive an array of numbers. Each element of the array represents the time needed to pass through that step (the index). There are
going to be two cars. One of them starts from the left side and the other one starts from the right side. The middle index of the array is the finish line. The number of elements in the array will
always be odd. Calculate the total time for each racer to reach the finish, which is the middle of the array, and print the winner with his total time (the racer with less time). If you have a zero
in the array, you have to reduce the time of the racer that reached it by 20% (from his current time).
Print the result in the following format "The winner is {left/right} with total time: {total time}".*/
using System;
using System.Linq;

namespace _02._Car_Race;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        double firstRacerTime = 0, secondRacerTime = 0;

        for (int i = 0; i < numbers.Length / 2; i++)
        {
            int number = numbers[i];
            firstRacerTime += number;
            if (number == 0)
            {
                firstRacerTime -= firstRacerTime * 0.2;
            }
        }

        for (int i = numbers.Length - 1; i > numbers.Length / 2; i--)
        {
            int number = numbers[i];
            secondRacerTime += number;
            if (number == 0)
            {
                secondRacerTime -= secondRacerTime * 0.2;
            }
        }

        if (firstRacerTime < secondRacerTime)
        {
            Console.WriteLine($"The winner is left with total time: {firstRacerTime}");
        }
        else if (firstRacerTime > secondRacerTime)
        {
            Console.WriteLine($"The winner is right with total time: {secondRacerTime}");
        }
    }
}

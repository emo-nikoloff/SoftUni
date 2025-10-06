/*You are at a shooting gallery and you need a program that helps you keep track of moving targets. On the first line, you will receive a sequence of targets with their integer values, split by a
single space. Then, you will start receiving commands for manipulating the targets until the "End" command. The commands are the following:
· "Shoot {index} {power}"
    o Shoot the target at the index, if it exists, by reducing its value by the given power (integer value).
    o Remove the target, if it is shot. A target is considered shot when its value reaches 0.
· "Add {index} {value}"
    o Insert a target with the received value at the received index, if it exists.
    o If not, print: "Invalid placement!".
· "Strike {index} {radius}"
    o Remove the target at the given index and the ones before and after it, depending on the radius.
    o If any of the indices in the range is invalid, print: "Strike missed!" and skip this command.
    Example: "Strike 2 2"
        {radius} {radius} {strikeIndex} {radius} {radius}
· "End"
    o Print the sequence with targets in the following format and end the program:
    "{target1}|{target2}…|{targetn}"
· On the first line, you will receive the sequence of targets – integer values [1…10000].
· On the following lines, until the "End" command, you will be receiving the commands described above – strings.
· There will never be a case when the "Strike" command would empty the whole sequence.
· Print the appropriate message in case of any command if necessary.
· In the end, print the sequence of targets in the format described above.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target;

class Program
{
    static void Main(string[] args)
    {
        List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
        string actions;

        while ((actions = Console.ReadLine()) != "End")
        {
            string[] action = actions.Split();

            switch (action[0])
            {
                case "Shoot":
                    int shootIndex = int.Parse(action[1]);
                    int shootPower = int.Parse(action[2]);

                    Shoot(targets, shootIndex, shootPower);
                    break;
                case "Add":
                    int addIndex = int.Parse(action[1]);
                    int addValue = int.Parse(action[2]);

                    Add(targets, addIndex, addValue);
                    break;
                case "Strike":
                    int strikeIndex = int.Parse(action[1]);
                    int strikeRadius = int.Parse(action[2]);

                    Strike(targets, strikeIndex, strikeRadius);
                    break;
            }
        }
        PrintTargets(targets);
    }

    static bool IsValidIndex(List<int> targets, int index)
    {
        return index >= 0 && index < targets.Count;
    }

    static bool IsValidStrikeRange(List<int> targets, int index, int radius)
    {
        return index - radius >= 0 && index + radius < targets.Count;
    }

    static void Shoot(List<int> targets, int index, int power)
    {
        if (IsValidIndex(targets, index))
        {
            targets[index] -= power;
            if (targets[index] <= 0)
            {
                targets.RemoveAt(index);
            }
        }
    }

    static void Add(List<int> targets, int index, int value)
    {
        if (IsValidIndex(targets, index))
        {
            targets.Insert(index, value);
        }
        else
        {
            Console.WriteLine("Invalid placement!");
        }
    }

    static void Strike(List<int> targets, int index, int radius)
    {
        if (IsValidIndex(targets, index))
        {
            if (IsValidStrikeRange(targets, index, radius))
            {
                targets.RemoveRange(index - radius, radius * 2 + 1);
            }
            else
            {
                Console.WriteLine("Strike missed!");
            }
        }
    }

    static void PrintTargets(List<int> targets)
    {
        Console.WriteLine(string.Join("|", targets));
    }
}

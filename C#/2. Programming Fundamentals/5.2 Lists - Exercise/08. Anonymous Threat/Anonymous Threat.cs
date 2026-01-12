/*Anonymous has created a cyber hyper virus, which steals data from the CIA. You, as the lead security developer in the CIA, have been tasked to analyze the software of the virus and observe its
actions on the data. The virus is known for its innovative and unbelievably clever technique of merging and dividing data into partitions.
You will receive a single input line, containing strings, separated by spaces. The strings may contain any ASCII character except whitespace. Then you will begin receiving commands in one of the
following formats:
· merge {startIndex} {endIndex}
· divide {index} {partitions}
Every time you receive the merge command, you must merge all elements from the startIndex to the endIndex. In other words, you should concatenate them. Example:
{abc, def, ghi} -> merge 0 1 -> {abcdef, ghi}
If any of the given indexes is out of the array, you must take only the range that is inside the array and merge it.
Every time you receive the divide command, you must divide the element at the given index, into several small substrings with equal length. The count of the substrings should be equal to the given
partitions.
Example: {abcdef, ghi, jkl} -> divide 0 3 -> {ab, cd, ef, ghi, jkl}
If the string cannot be exactly divided into the given partitions, make all partitions except the last with equal lengths and make the last one – the longest.
Example: {abcd, efgh, ijkl} -> divide 0 3 -> {a, b, cd, efgh, ijkl}
The input ends when you receive the command "3:1". At that point, you must print the resulting elements, joined by a space.
· The first input line will contain the array of data.
· On the next several input lines, you will receive commands in the format specified above.
· The input ends when you receive the command "3:1".
· As output, you must print a single line containing the elements of the array, joined by a space.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat;

class Program
{
    static void Main(string[] args)
    {
        List<string> strings = Console.ReadLine().Split().ToList();
        string input;

        while ((input = Console.ReadLine()) != "3:1")
        {
            string[] inputParts = input.Split();

            switch (inputParts[0])
            {
                case "merge":
                    int startIndex = int.Parse(inputParts[1]);
                    int endIndex = int.Parse(inputParts[2]);

                    startIndex = Math.Max(0, startIndex);
                    endIndex = Math.Min(strings.Count - 1, endIndex);

                    int range = endIndex - startIndex + 1;

                    if (startIndex < endIndex)
                    {
                        string mergedStrings = string.Join("", strings.GetRange(startIndex, range));
                        strings.RemoveRange(startIndex, range);
                        strings.Insert(startIndex, mergedStrings);
                    }
                    break;
                case "divide":
                    int index = int.Parse(inputParts[1]);
                    int partitions = int.Parse(inputParts[2]);

                    string partition = strings[index];
                    strings.RemoveAt(index);

                    int partitionLength = partition.Length / partitions;
                    int remainder = partition.Length % partitions;

                    List<string> divided = new();
                    int elementIndex = 0;

                    for (int i = 0; i < partitions; i++)
                    {
                        int currentPartitionLength = partitionLength;

                        if (i == partitions - 1)
                        {
                            currentPartitionLength += remainder;
                        }

                        divided.Add(partition.Substring(elementIndex, currentPartitionLength));

                        elementIndex += currentPartitionLength;
                    }

                    strings.InsertRange(index, divided);
                    break;
            }
        }
        Console.WriteLine(string.Join(" ", strings));
    }
}

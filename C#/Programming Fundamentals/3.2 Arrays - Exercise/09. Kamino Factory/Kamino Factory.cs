/*The clone factory in Kamino got another order to clone troops. But this time you are tasked to find the best DNA sequence to use in the production.
You will receive the DNA length and until you receive the command "Clone them!", you will be receiving a DNA sequence of ones and zeroes, split by '!' (one or several).
You should select the sequence with the longest subsequence of ones. If there are several sequences with the same length of the subsequence of ones, print the one with the leftmost starting index,
if there are several sequences with the same length and starting index, select the sequence with the greater sum of its elements.
After you receive the last command "Clone them!" you should print the collected information in the following format:
"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}."
"{DNA sequence, joined by space}"
· The first line holds the length of the sequences – integer in the range [1…100].
· On the next lines, until you receive "Clone them!", you will be receiving sequences (at least one) of ones and zeroes, split by '!' (one or several).
The output should be printed on the console and consists of two lines in the following format:
"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}."
"{DNA sequence, joined by space}"*/
using System;

namespace _09._Kamino_Factory;

class Program
{
    static void Main(string[] args)
    {
        int lengthDNA = int.Parse(Console.ReadLine());
        string input;

        int sample = 0, bestSample = 1, bestSequenceIndex = lengthDNA, bestSequenceLength = 0, bestSequenceSum = 0;
        string[] bestSequence = Array.Empty<string>();
        while ((input = Console.ReadLine()) != "Clone them!")
        {
            string[] sequence = input.Split("!", StringSplitOptions.RemoveEmptyEntries);
            if (bestSequence.Length == 0)
            {
                bestSequence = sequence;
            }

            sample++;

            int sequenceLength = 0, sequenceSum = 0;
            for (int i = lengthDNA - 1; i >= 0; i--)
            {
                if (sequence[i] == "1")
                {
                    sequenceLength++;
                    sequenceSum++;
                    if (sequenceLength > bestSequenceLength || i < bestSequenceIndex || sequenceSum > bestSequenceSum)
                    {
                        bestSequenceLength = sequenceLength;
                        bestSequenceIndex = i;
                        bestSequenceSum = sequenceSum;
                        bestSample = sample;
                        bestSequence = sequence;
                    }
                }
                else
                {
                    sequenceLength = 0;
                }
            }
        }
        Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSequenceSum}.\n{string.Join(" ", bestSequence)}");
    }
}

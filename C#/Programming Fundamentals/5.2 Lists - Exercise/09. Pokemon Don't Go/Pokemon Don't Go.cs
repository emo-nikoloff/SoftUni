/*Ely likes to play Pokemon Go a lot. But Pokemon Go bankrupted… So the developers made Pokemon Don't Go out of depression. And so Ely now plays Pokemon Don't Go. In Pokemon Don't Go, when you walk to
a certain pokemon, those closest to you, naturally get further, and those further from you, get closer.
You will receive a sequence of integers, separated by spaces – the distances to the pokemon. Then you will begin receiving integers, which will correspond to indexes in that sequence.
When you receive an index, you must remove the element at that index from the sequence (as if you've captured the pokemon).
· You must increase the value of all elements in the sequence, which are less or equal to the removed element, with the value of the removed element.
· You must decrease the value of all elements in the sequence, which are greater than the removed element, with the value of the removed element.
If the given index is less than 0, remove the first element of the sequence, and copy the last element to its place.
If the given index is greater than the last index of the sequence, remove the last element from the sequence, and copy the first element to its place.
The increasing and decreasing of elements should be done in these cases, also. The element, whose value you should use, is the removed element.
The program ends when the sequence has no elements (there are no pokemon left for Ely to catch).
· On the first line of input you will receive a sequence of integers, separated by spaces.
· On the next several lines, you will receive integers – the indexes.
· When the program ends, you must print the summed value of all removed elements.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

        int sumRemovedNumbers = 0;
        while (numbers.Count > 0)
        {
            int index = int.Parse(Console.ReadLine());

            int removedNumber = 0;
            if (index < 0)
            {
                int firstIndex = 0;
                int lastNumber = numbers[^1];

                removedNumber = numbers[firstIndex];
                numbers.RemoveAt(firstIndex);
                numbers.Insert(firstIndex, lastNumber);
            }
            else if (index > numbers.Count - 1)
            {
                int lastIndex = numbers.Count - 1;
                int firstNumber = numbers[0];

                removedNumber = numbers[lastIndex];
                numbers.RemoveAt(lastIndex);
                numbers.Insert(lastIndex, firstNumber);
            }
            else
            {
                removedNumber = numbers[index];
                numbers.RemoveAt(index);
            }

            sumRemovedNumbers += removedNumber;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > removedNumber)
                {
                    numbers[i] -= removedNumber;
                }
                else
                {
                    numbers[i] += removedNumber;
                }
            }
        }
        Console.WriteLine(sumRemovedNumbers);
    }
}

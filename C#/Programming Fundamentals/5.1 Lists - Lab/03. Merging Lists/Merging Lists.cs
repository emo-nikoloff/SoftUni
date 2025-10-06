/*You are going to receive two lists of numbers. Create a list that contains the numbers from both of the lists. The first element should be from the first list, the second from the second list, and
so on. If the length of the two lists is not equal, just add the remaining elements at the end of the list.
*Hint
· Read the two lists.
· Create a result list.
· Start looping through them until you reach the end of the smallest one.
· Finally, add the remaining elements (if there are any) to the end of the list.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists;

class Program
{
    static void Main(string[] args)
    {
        List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();

        int maxCount = firstList.Count > secondList.Count ? firstList.Count : secondList.Count;

        List<int> resultList = new();

        for (int i = 0; i < maxCount; i++)
        {
            if (firstList.Count > i)
            {
                resultList.Add(firstList[i]);
            }
            if (secondList.Count > i)
            {
                resultList.Add(secondList[i]);
            }
        }
        Console.WriteLine(string.Join(" ", resultList));
    }
}

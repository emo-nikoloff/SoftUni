/*The triangle may be constructed in the following manner: In row 0 (the topmost row), there is a unique nonzero entry 1. Each entry of each subsequent row is constructed by adding the number above and
to the left with the number above and to the right, treating blank entries as 0. For example, the initial number in the first (or any other) row is 1 (the sum of 0 and 1), whereas the numbers 1 and 3
in the third row are added to produce the number 4 in the fourth row.
If you want more info about it: https://en.wikipedia.org/wiki/Pascal's_triangle
Print each row element separated with whitespace.
*Hints
· The input number n will be 1 <= n <= 60.
· Think about the proper type for the elements of the array.
· Don't be scared to use more and more arrays.*/
using System;

namespace _02._Pascal_Triangle;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());
        long[][] pascalTriangle = new long[magicNumber][];

        for (int row = 0; row < magicNumber; row++)
        {
            pascalTriangle[row] = new long[row + 1];
            pascalTriangle[row][0] = 1;  // first element is 1
            pascalTriangle[row][^1] = 1; // last element is 1
            for (int col = 1; col < row; col++)
            {
                pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
            }
            Console.WriteLine(string.Join(" ", pascalTriangle[row]));
        }
    }
}

/*Create a program, which emulates typing an SMS, following this guide:
1    2    3
     abc  def

4    5    6
ghi  jkl  mno

7    8    9
pqrs tuv  wxyz

     0
     space
Following the guide, 2 becomes 'a', 22 becomes 'b' and so on.

*Hints
· A naive approach would be to just put all the possible combinations of digits in a giant switch statement.
· A cleverer approach would be to come up with a mathematical formula, which converts a number to its alphabet representation:
Digit   2       3       4       5           6           7              8           9
Index   0 1 2   3 4 5   6 7 8   9 10 11    12 13 14    15 16 17 18    19 20 21    22 23 24 25
Letter  a b c   d e f   g h i   j k l      m n o       p q r s        t u v       w x y z
· Let's take the number 222 (c) for example. Our algorithm would look like this:
    o Find the number of digits the number has, e.g. 222 🡺 3 digits
    o Find the main digit of the number, e.g. 222 🡺 2
    o Find the offset of the number. To do that, you can use the formula: (main digit - 2) * 3
    o If the main digit is 8 or 9, you need to add 1 to the offset, since the digits 7 and 9 have 4 letters each
    o Finally, find the letter index (a 🡺 0, c 🡺 2, etc.). To do that, you can use the following formula: (offset + digit length - 1).
    o After you've found the letter index, you can just add that to the ASCII code of the lowercase letter 'a' (97)*/
using System;

namespace _05._Messages_No_expire_time;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());

        string word = string.Empty;
        for (int i = 0; i < magicNumber; i++)
        {
            string input = Console.ReadLine();

            if (input == "0")
            {
                word += " ";
                continue;
            }

            int digitLength = input.Length;
            int mainDigit = int.Parse(input[0].ToString());

            if (mainDigit >= 2 && mainDigit <= 9)
            {
                if (mainDigit == 7 || mainDigit == 9)
                {
                    if (digitLength > 4)
                    {
                        digitLength -= 4;
                    }
                }
                else
                {
                    if (digitLength > 3)
                    {
                        digitLength -= 3;
                    }
                }

                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset += 1;
                }

                int letterIndex = offset + digitLength - 1;
                char letter = (char)(97 + letterIndex);
                word += letter;
            }
        }
        Console.WriteLine(word);
    }
}

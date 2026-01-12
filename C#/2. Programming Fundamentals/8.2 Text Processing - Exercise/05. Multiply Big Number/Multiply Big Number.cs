/*You are given two lines – the first one can be a really big number (0 to 1050). The second one will be a single-digit number (0 to 9). Your task is to display the product of these numbers.
Note: do not use the BigInteger class.*/
using System;

namespace _05._Multiply_Big_Number;

class Program
{
    static void Main(string[] args)
    {
        string bigNumber = Console.ReadLine();
        string multiplyNumber = Console.ReadLine();

        string result = string.Empty;
        char[] resultChars = new char[bigNumber.Length + 1];

        if (bigNumber == "0" || multiplyNumber == "0")
        {
            result = "0";
        }
        else
        {
            int multiplier = int.Parse(multiplyNumber);
            int carry = 0;

            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(bigNumber[i].ToString());
                int product = digit * multiplier + carry;

                resultChars[i + 1] = (char)(product % 10 + '0');
                carry = product / 10;
            }

            if (carry > 0)
            {
                resultChars[0] = (char)(carry + '0');
            }

            result = new string(resultChars).Trim('\0');
        }

        Console.WriteLine(result);
    }
}

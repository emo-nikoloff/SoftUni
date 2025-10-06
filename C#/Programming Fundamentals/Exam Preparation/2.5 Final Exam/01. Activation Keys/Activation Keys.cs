/*You are about to make some good money, but first, you need to think of a way to verify who paid for your product and who didn't. You have decided to let people use the software for a free trial
period and then require an activation key to continue using the product. Before you can cash out, the last step is to design a program that creates unique activation keys for each user. So, waste no
more time and start typing!
The first line of the input will be your raw activation key. It will consist of letters and numbers only.
After that, until the "Generate" command is given, you will be receiving strings with instructions for different operations that need to be performed upon the raw activation key.
There are several types of instructions, split by ">>>":
· "Contains>>>{substring}":
    o If the raw activation key contains the given substring, print "{raw activation key} contains {substring}".
    o Otherwise, print "Substring not found!"
· "Flip>>>Upper/Lower>>>{startIndex}>>>{endIndex}":
    o Changes the substring between the given indices (the end index is exclusive) to upper or lower case and then prints the activation key.
    o All given indexes will be valid.
· "Slice>>>{startIndex}>>>{endIndex}":
    o Deletes the characters between the start and end indices (the end index is exclusive) and prints the activation key.
    o Both indices will be valid.
· The first line of the input will be a string consisting of letters and numbers only.
· After the first line, until the "Generate" command is given, you will be receiving strings.
· After the "Generate" command is received, print:
    o "Your activation key is: {activation key}"*/
using System;

namespace _01._Activation_Keys;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

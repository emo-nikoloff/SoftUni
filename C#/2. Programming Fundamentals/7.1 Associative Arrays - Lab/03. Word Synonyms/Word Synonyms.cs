/*Create a program, which keeps a dictionary with synonyms. The key of the dictionary will be the word. The value will be a list of all the synonyms of that word. You will be given a number n – the
count of the words. After each word, you will be given a synonym, so the count of lines you have to read from the console is 2 * n. You will be receiving a word and a synonym each on a separate line
like this:
· {word}
· {synonym}
If you get the same word twice, just add the new synonym to the list.
Print the words in the following format:
"{word} - {synonym1, synonym2, …, synonymN}"*/
using System;
using System.Collections.Generic;

namespace _03._Word_Synonyms;

class Program
{
    static void Main(string[] args)
    {
        int wordsNumber = int.Parse(Console.ReadLine());
        Dictionary<string, List<string>> wordsSynonyms = new();

        for (int i = 1; i <= wordsNumber; i++)
        {
            string word = Console.ReadLine();
            string synonym = Console.ReadLine();

            if (!wordsSynonyms.ContainsKey(word))
            {
                wordsSynonyms[word] = new List<string>();
            }

            wordsSynonyms[word].Add(synonym);
        }

        foreach ((string word, List<string> synonyms) in wordsSynonyms)
        {
            Console.WriteLine($"{word} - {string.Join(", ", synonyms)}");
        }
    }
}

/*Create a program that generates random fake advertisement messages to advertise a product. The messages must consist of 4 parts: phrase + event + author + city. Use the following predefined parts:
· Phrases – {"Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product."}
· Events – {"Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.",
"I feel great!"}
· Authors – {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"}
· Cities – {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"}
The format of the output message is the following: "{phrase} {event} {author} – {city}."
You will receive the number of messages to be generated. Print each random message at a separate line.*/
using System;
using System.Collections.Generic;

namespace _01._Advertisement_Message;

class Program
{
    static void Main(string[] args)
    {
        int messages = int.Parse(Console.ReadLine());
        List<string> phrases = new()
        {
            "Excellent product.",
            "Such a great product.",
            "I always use that product.",
            "Best product of its category.",
            "Exceptional product.",
            "I can't live without this product."
        };
        List<string> events = new()
        {
            "Now I feel good.",
            "I have succeeded with this product.",
            "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.",
            "I feel great!"
        }; List<string> authors = new()
        {
            "Diana",
            "Petya",
            "Stella",
            "Elena",
            "Katya",
            "Iva",
            "Annie",
            "Eva"
        };
        List<string> cities = new()
        {
            "Burgas",
            "Sofia",
            "Plovdiv",
            "Varna",
            "Ruse"
        };

        for (int i = 0; i < messages; i++)
        {
            Random random = new();
            int randomPhraseIndex = random.Next(phrases.Count);
            int randomEventIndex = random.Next(events.Count);
            int randomAuthorIndex = random.Next(authors.Count);
            int randomCityIndex = random.Next(cities.Count);

            string phrase = phrases[randomPhraseIndex];
            string @event = events[randomEventIndex];
            string author = authors[randomAuthorIndex];
            string city = cities[randomCityIndex];

            Console.WriteLine($"{phrase} {@event} {author} - {city}");
        }
    }
}

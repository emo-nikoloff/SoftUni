using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Plan;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("--------Обекти и класове--------");

        // Обекти и класове:
        Dog ivan = new() { Name = "Ivan", Breed = "Husky", Age = 3 }; // обект
        Console.WriteLine($"Dog name: {ivan.Name}");
        Console.WriteLine($"Dog breed: {ivan.Breed}");
        ivan.Bark();

        Dice diceD6 = new Dice();
        diceD6.Sides = 6;
        Console.WriteLine($"Roll dice with 6 sides: {diceD6.Roll()}");

        int sides = 8;
        Dice diceD8 = new Dice(sides);
        Console.WriteLine($"Roll dice with {sides} sides: {diceD8.Roll()}");

        Person person = new("John", "Doe");
        Console.WriteLine(person.FullName);

        Console.WriteLine("--------Асоциативни масиви--------");

        // Асоциативни масиви: масиви индексирани по ключове(ключовете са уникални)
        Dictionary<int, string> numbersWords = new()
        {
            {1,"one"}, // ключ, стойност
            {2,"two"},
            {3,"three"},
            {4,"four"},
            {5,"five"}
        };

        foreach (KeyValuePair<int, string> numberWord in numbersWords)
        {
            Console.WriteLine($"{numberWord.Key} -> {numberWord.Value}");
        }

        Console.WriteLine("--------lambda функции--------");

        // lambda(анонимни) функции: методи на един ред; съкратен запис на функция
        List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        List<int> evenNumbers = numbers.FindAll(x => x % 2 == 0); // lambda израз в скобите на FindAll; параметър => резултат

        Console.WriteLine(string.Join(" ", evenNumbers));

        Console.WriteLine("--------StringBuilder--------");

        // StringBuilder - клас; пази място в паметта за всеки случай; наподобява List
        StringBuilder newString = new();

        newString.Append("Hello, ");
        newString.Append("Emiliyan ");
        newString.Append("Nikolov!");

        Console.WriteLine(newString);

        Console.WriteLine("--------Регулярни изрази--------");

        // Регулярни изрази: помагат да намерим съвпадения в текст по някакъв модел; тестер: https://regex101.com/
        // -> квантификатори:
        // => * - открива даден елемент нула или повече пъти
        // => + - открива даден елемент един или повече пъти
        // => ? - открива даден елемент нула или един път
        // => {число} - открива даден елемент точно определен брой пъти
        string info = "Emiliyan Nikolov is 18 years old";

        Regex namePattern = new(@"[A-Z][a-z]+ [A-Z][a-z]+"); // открива всички съчетания от главни + малки букви
        Regex agePattern = new(@"[0-9]+"); // открива всички числа
        Regex fixedPattern = new(@"[ENd]+"); // открива всички символи, които съвпададат със зададените
        Regex anyPattern = new(@"[^ENd]+"); // открива всички символи, които НЕ съвпададат със зададените

        Console.WriteLine(info);
        Console.WriteLine($"Name: {namePattern.Match(info)}");
        Console.WriteLine($"Age: {agePattern.Match(info)}");
        Console.WriteLine($"{fixedPattern.Match(info)}"); // ще принтира първото съвпадение, ако не е зададена колекция от съвпадения
        Console.WriteLine($"{anyPattern.Match(info)}");

        Console.WriteLine("------------------------");

        List<string> names = new() { "Asen", "Ivan", "Peter", "A" };

        Regex firstNamePattern = new(@"[A-Z][a-z]*");
        Regex secondNamePattern = new(@"[A-Z][a-z]+");
        Regex thirdNamePattern = new(@"[A-Z][a-z]?");
        Regex fourthNamePattern = new(@"[A-Z][a-z]{2}");

        for (int i = 0; i < names.Count; i++)
        {
            string name = names[i];
            Console.WriteLine(firstNamePattern.Match(name));
            Console.WriteLine(secondNamePattern.Match(name));
            Console.WriteLine(thirdNamePattern.Match(name));
            Console.WriteLine(fourthNamePattern.Match(name));
            if (i != names.Count - 1)
            {
                Console.WriteLine("Следващ->");
            }
        }

        Console.WriteLine("------------------------");

        List<string> phoneNumbers = new()
        {
            "+359887222111666",
            "+35988722211166",
            "+359887222111656",
            "359887222111666",
            "+359887222111656768",
        };

        Regex phonePattern = new(@"\+\d{15}\b"); // \b - слагаме граници - ако изразът е извън границите, то целият израз е невалиден

        Console.WriteLine("Valid phone numbers:");
        foreach (string phoneNumber in phoneNumbers)
        {
            Match match = phonePattern.Match(phoneNumber);
            if (match.Success)
            {
                Console.WriteLine(match.Value);
            }
        }

        Console.WriteLine("\nInvalid phone numbers:");
        foreach (string phoneNumber in phoneNumbers)
        {
            Match match = phonePattern.Match(phoneNumber);
            if (!match.Success)
            {
                Console.WriteLine(phoneNumber);
            }
        }

        Console.WriteLine("------------------------");

        // -> предефинирани класове:
        // => \w - открива всички символи, които са знакови
        // => \W - открива всички символи, които НЕ са знакови
        // => \s - открива всички символи, които се използват за празни места
        // => \S - открива всички символи, които НЕ се използват за празни места
        // => \d - открива всички символи, които са цифри
        // => \D - открива всички символи, които НЕ са цифри
        string text = "Hello123! Sample_text\t\n";

        Regex wPattern = new(@"\w+");
        Regex WPattern = new(@"\W+");
        Regex sPattern = new(@"\s+");
        Regex SPattern = new(@"\S+");
        Regex dPattern = new(@"\d+");
        Regex DPattern = new(@"\D+");

        Console.WriteLine(wPattern.Match(text));
        Console.WriteLine(WPattern.Match(text));
        Console.WriteLine(sPattern.Match(text));
        Console.WriteLine(SPattern.Match(text));
        Console.WriteLine(dPattern.Match(text));
        Console.WriteLine(DPattern.Match(text));

        Console.WriteLine("------------------------");

        // -> групиращи конструктори:
        // => (подизраз) - взима конкретния подизраз като номерирана група
        // => (?:подизраз) - определя необхващаща група
        // => (?<име>подизраз) - определя именувана обхващаща група
        string date = "25-Mar-2005";
        string greeting = "Hi, Emiliyan";

        Regex firstGroup = new(@"\d{2}-(\w{3})-\d{4}");
        Regex secondGroup = new(@"^(?:Hi|Hello),\s*(\w+)$"); // ^ - заявява начало, $ - заявява край
        Regex namedGroup = new(@"(?<day>\d{2})-(?<month>\w{3})-(?<year>\d{4})");

        Console.WriteLine(firstGroup.Match(date).Groups[1].Value); // индексът на първата валидна група; 0 връща името на цялата група
        Console.WriteLine(secondGroup.Match(greeting).Groups[1].Value);

        Match dateMatch = namedGroup.Match(date);

        Console.WriteLine($"Day: {dateMatch.Groups["day"].Value}");
        Console.WriteLine($"Month: {dateMatch.Groups["month"].Value}");
        Console.WriteLine($"Year: {dateMatch.Groups["year"].Value}");

        Console.WriteLine("------------------------");

        StringBuilder body = new();

        body.Append("<b>Regular Expressions</b> are cool!");
        body.Append("<p>I am a paragraph</p> … some text after");
        body.Append("Hello, <div>I am a<code>DIV</code></div>!");
        body.Append("<span>Hello, I am Span</span>");
        body.Append("<a href=\"https://softuni.bg/\">SoftUni</a>");

        string html = body.ToString();

        Regex contentPattern = new(@"<(\w+)[^>]*>.*?<\/\1>", RegexOptions.Singleline); // <> - отварящ/затварящ таг => () - група, [^>] - допуска допълнителни атрибути без да съдържа >; 
                                                                                       // .*? - съдържанието на елемента (non-greedy – до най-близкия затварящ таг)
                                                                                       //                                (. - открива всичко, което не е нов ред); 
                                                                                       // 1(номер на група) играе ролята на \k<име на група>

        MatchCollection matches = contentPattern.Matches(html);

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }

        Console.WriteLine("------------------------");
    }
}

// Обекти и класове:
class Dog // Структура за обекти (шаблон)
{
    public string Name { get; set; } // членове - характеристики - съхраняват състояние
    public string Breed { get; set; }
    public int Age { get; set; }

    public void Bark() // метод - пояснява поведение
    {
        Console.WriteLine("Bark!");
    }
}

class Dice
{
    public Dice() // конструктор
    {
    }

    public Dice(int sides)
    {
        Sides = sides;
    }

    public int Sides { get; set; }
    public string Type { get; set; }

    public int Roll()
    {
        Random random = new();
        return random.Next(1, Sides + 1);
    }
}

class Person
{
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName
    {
        get
        {
            return FirstName + " " + LastName;
        }
    }
}
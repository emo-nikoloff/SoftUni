/*Create a class Article with the following properties:
· Title – a string
· Content – a string
· Author – a string
The class should have a constructor and the following methods:
· Edit (new content) – change the old content with the new one
· ChangeAuthor (new author) – change the author
· Rename (new title) – change the title of the article
· Override the ToString method – print the article in the following format:
"{title} - {content}: {author}"
Create a program that reads an article in the following format "{title}, {content}, {author}". On the next line, you will receive a number n, representing the number of commands, which will follow
after it. On the next n lines, you will be receiving the following commands:
· "Edit: {new content}"
· "ChangeAuthor: {new author}"
· "Rename: {new title}"
In the end, print the final state of the article.*/
using System;

namespace _02._Articles;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(", ");
        Article article = new(input[0], input[1], input[2]);
        int commands = int.Parse(Console.ReadLine());

        for (int i = 1; i <= commands; i++)
        {
            string command = Console.ReadLine();

            string[] commandParts = command.Split(": ");

            switch (commandParts[0])
            {
                case "Edit":
                    string newContent = commandParts[1];
                    article.Edit(newContent);
                    break;
                case "ChangeAuthor":
                    string newAuthor = commandParts[1];
                    article.ChangeAuthor(newAuthor);
                    break;
                case "Rename":
                    string newTitle = commandParts[1];
                    article.Rename(newTitle);
                    break;
            }
        }

        Console.WriteLine(article.ToString());
    }
}

class Article
{
    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }

    public void Edit(string newContent)
    {
        Content = newContent;
    }
    public void ChangeAuthor(string newAuthor)
    {
        Author = newAuthor;
    }
    public void Rename(string newTitle)
    {
        Title = newTitle;
    }
    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}

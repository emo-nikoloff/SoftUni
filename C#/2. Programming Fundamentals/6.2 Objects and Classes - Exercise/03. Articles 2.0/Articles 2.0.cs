/*Change the program from the previous problem in such a way, that you will be able to store a list of articles. You will not need to use the previous methods anymore (except the "ToString()").
On the first line, you will receive the number of articles. On the next lines, you will receive the articles in the same format as in the previous problem: "{title}, {content}, {author}".
Print thearticles.*/
using System;
using System.Collections.Generic;

namespace _03._Articles_2._0;

class Program
{
    static void Main(string[] args)
    {
        int articlesNumber = int.Parse(Console.ReadLine());
        List<Article> articles = new();

        for (int i = 1; i <= articlesNumber; i++)
        {
            string[] input = Console.ReadLine().Split(", ");

            Article article = new(input[0], input[1], input[2]);

            articles.Add(article);
        }

        Console.WriteLine(string.Join("\n", articles));
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

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}

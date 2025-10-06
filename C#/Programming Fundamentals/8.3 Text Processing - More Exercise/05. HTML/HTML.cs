/*You will receive 3 lines of input. On the first line you will receive a title of an article. On the next line you will receive the content of that article. On the next n lines, until you receive
"end of comments", you will get the comments about the article. Print the whole information in HTML format. The title should be in h1 tag (<h1></h1>); the content in article tag (<article></article>);
each comment should be in div tag (<div></div>). For more clarification see the example below.*/
using System;
using System.Collections.Generic;

namespace _05._HTML;

class Program
{
    static void Main(string[] args)
    {
        string articleTitle = Console.ReadLine();
        string articleContent = Console.ReadLine();

        Article article = new(articleTitle, articleContent);

        string articleComment;

        while ((articleComment = Console.ReadLine()) != "end of comments")
        {
            article.Comments.Add(articleComment);
        }

        Console.WriteLine(article);
    }
}

class Article
{
    public Article(string title, string content)
    {
        Title = title;
        Content = content;
        Comments = new();
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public List<string> Comments { get; set; }

    public override string ToString()
    {
        string result = $"<h1>\n  {Title}\n</h1>\n";
        result += $"<article>\n  {Content}\n</article>\n";
        foreach (string comment in Comments)
        {
            result += $"<div>\n  {comment}\n</div>\n";
        }
        return result;
    }
}

using System;

namespace IteratorsAndComparators;

public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] authors)
    {
        Title = title;
        Year = year;
        Authors = new(authors);
    }

    public string Title { get; }
    public int Year { get; }
    public List<string> Authors { get; }

    public int CompareTo(Book other)
    {
        int yearComparison = Year.CompareTo(other.Year);
        if (yearComparison != 0)
        {
            return yearComparison;
        }
        return Title.CompareTo(other.Title);
    }

    public override string ToString()
    {
        return $"{Title} - {Year}";
    }
}

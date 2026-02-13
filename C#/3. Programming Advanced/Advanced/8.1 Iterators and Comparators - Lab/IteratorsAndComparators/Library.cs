using System;
using System.Collections;

namespace IteratorsAndComparators;

public class Library : IEnumerable<Book>
{
    // private List<Book> books;
    private SortedSet<Book> books;

    public Library(params Book[] books)
    {
        // this.books = new(books);
        this.books = new(books, new BookComparator());
    }

    public IEnumerator<Book> GetEnumerator()
    {
        // return new LibraryIterator(books.ToList());
        return new LibraryIterator(books.ToList());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentIndex;

        public LibraryIterator(List<Book> books)
        {
            this.books = books;
            Reset();
        }

        public Book Current
        {
            get
            {
                return books[currentIndex];
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            currentIndex++;
            if (currentIndex >= books.Count)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}

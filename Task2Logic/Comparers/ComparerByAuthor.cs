using System;
using System.Collections.Generic;
namespace Task2Logic.Comparers
{
    public class ComparerByAuthor: IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
            if (!ReferenceEquals(firstBook, null))
                return firstBook.Author.CompareTo(secondBook.Author);
            if (ReferenceEquals(secondBook, null))
                return 0;
            return -1;
        }
    }
}

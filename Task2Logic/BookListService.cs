using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2Logic
{
    public class BookListService
    {
        private IFileStorage<Book> repository;
        private List<Book> books = new List<Book>();

        public BookListService(IFileStorage<Book> repository)
        {
            if (ReferenceEquals(repository, null))
                throw new ArgumentNullException();
            this.repository = repository;
        }
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();
            if (BookExistence(book))
                throw new ArgumentNullException();
            books.Add(book);
            repository.Save(books);
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();
            if (!BookExistence(book))
                throw new ArgumentNullException();
            books.Remove(book);
            repository.Save(books);
        }
        public IEnumerable<Book> GetBooks()
        {
            return repository.Load();
        }
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException();
            books = repository.Load().ToList();
            books.Sort(comparer);
            repository.Save(books);
        }
        public Book FindByTag(Func<Book, bool> func)
        {
            if (ReferenceEquals(func, null))
                throw new ArgumentNullException();
            Book findBook = null;
            books = repository.Load().ToList();
            findBook = books.FirstOrDefault(func);
            return findBook;
        }
        private bool BookExistence(Book book)
        {
            Book existBook = books.FirstOrDefault(x => x.Equals(book));
            if (ReferenceEquals(existBook, null)) return false;
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2Logic
{
    /// <summary>
    /// Provides functionality of service for work with list of books.
    /// </summary>
    public class BookListService
    {
        #region Fields

        private IFileStorage<Book> storage;
        private List<Book> books = new List<Book>();

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new BookListService instance.
        /// </summary>
        /// <param name="repository"> Storage</param>
        public BookListService(IFileStorage<Book> repository)
        {
            if (ReferenceEquals(repository, null))
                throw new ArgumentNullException();
            storage = repository;
            books = storage.Load().ToList();
        }

        #endregion


        #region Public methods

        /// <summary>
        /// Adds a book to the list of books and to the storage.
        /// </summary>
        /// <param name="book"> Book</param>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();
            if (IsBookExist(book))
                throw new ArgumentException();
            books.Add(book);
            storage.Save(books);
        }

        /// <summary>
        /// Removes a book from the list of books and from the storage.
        /// </summary>
        /// <param name="book"> Book</param>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();
            if (!IsBookExist(book))
                throw new ArgumentException();
            books.Remove(book);
            storage.Save(books);
        }

        /// <summary>
        /// Searches the book by tag.
        /// </summary>
        /// <param name="tagPregicate"> Tag pregicate</param>
        /// <returns> Founded book</returns>
        public Book FindByTag(Predicate<Book> tagPregicate)
        {
            if (ReferenceEquals(tagPregicate, null))
                throw new ArgumentNullException();
            return books.Find(tagPregicate);
        }

        /// <summary>
        /// Sorts the list of books by tag.
        /// </summary>
        /// <param name="comparer"> Comparer</param>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException();
            books.Sort(comparer);
            storage.Save(books);
        }
        
        #endregion


        #region Private methods

        /// <summary>
        /// Checks if book exist in storage.
        /// </summary>
        /// <param name="book"> Book</param>
        /// <returns> true if book exist, otherwise false</returns>
        private bool IsBookExist(Book book)
        {
            Book existBook = books.FirstOrDefault(x => x.Equals(book));
            if (ReferenceEquals(existBook, null))
                return false;
            return true;
        }

        #endregion
    }
}

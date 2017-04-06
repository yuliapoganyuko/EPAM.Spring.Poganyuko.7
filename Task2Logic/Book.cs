using System;

namespace Task2Logic
{
    /// <summary>
    /// Class describing a book.
    /// </summary>
    public class Book: IComparable<Book>, IEquatable<Book>
    {
        #region Fields

        private string author;
        private string title;
        private string publishingHouse;
        private int year;
        private string genre;

        #endregion


        #region Properties

        public string Author
        {
            get { return author; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                author = value;
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                title = value;
            }
        }

        public string PublishingHouse
        {
            get { return publishingHouse; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                publishingHouse = value;
            }
        }

        public int Year
        {
            get { return year; }
            set
            {
                if (value <= 0 || value == DateTime.Now.Year)
                    throw new ArgumentOutOfRangeException();
                year = value;
            }
        }

        public string Genre
        {
            get { return genre; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                genre = value;
            }
        }

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes the new Book instance.
        /// </summary>
        /// <param name="author"> Author</param>
        /// <param name="title"> Title</param>
        /// <param name="publishingHouse"> Publishing house</param>
        /// <param name="year"> Year</param>
        /// <param name="genre"> Genre</param>
        public Book(string author, string title, string publishingHouse, int year, string genre)
        {
            Author = author;
            Title = title;
            PublishingHouse = publishingHouse;
            Year = year;
            Genre = genre;
        }

        /// <summary>
        /// Initializes the new Book instance with default values.
        /// </summary>
        public Book() : this("Undefined", "Undefined", "Undefined", 1970, "Undefined") { }

        /// <summary>
        /// Initializes the new Book instance.
        /// </summary>
        /// <param name="author"> Author</param>
        /// <param name="title"> Title</param>
        public Book(string author, string title) : this(author, title, "Undefined", 1970, "Undefined") { }

        #endregion


        #region Public methods

        /// <summary>
        /// Compares books by Title.
        /// </summary>
        /// <param name="other"> Book to compare with</param>
        /// <returns> Integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order</returns>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
                return 1;
            if (Equals(other))
                return 0;
            return String.Compare(Title, other.Title, true);
        }

        /// <summary>
        /// Compares books on equality.
        /// </summary>
        /// <param name="other"> Book to compare with</param>
        /// <returns> true if equal, otherwise false</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (String.Compare(Author, other.Author, true) != 0 || String.Compare(Title, other.Title, true) != 0 ||
                String.Compare(PublishingHouse, other.PublishingHouse, true) != 0 || (Year != other.Year) ||
                String.Compare(Genre, other.Genre, true) != 0)
                return false;
            return true;
        }

        /// <summary>
        /// Compares books on equality.
        /// </summary>
        /// <param name="firstBook"> First book to compare</param>
        /// <param name="secondBook"> Second book to compare</param>
        /// <returns> true if equal, otherwise false</returns>
        public static bool Equals(Book firstBook, Book secondBook)
        {
            if (ReferenceEquals(firstBook, null))
                return false;
            return firstBook.Equals(secondBook);
        }

        #endregion
        

        #region Override System.Object methods

        /// <summary>
        /// Compares books on equality.
        /// </summary>
        /// <param name="other"> Object to compare with</param>
        /// <returns> true if equal, otherwise false</returns>
        public override bool Equals(object other)
        {
            Book book = other as Book;
            return Equals(book);
        }

        /// <summary>
        /// Represents Book in a string format.
        /// </summary>
        /// <returns> Book in a string format</returns>
        public override string ToString()
        {
            return $"Author: {Author}, Title: {Title}, Publishing House:{PublishingHouse}, Year: {Year.ToString()}, Genre: {Genre}";
        }

        /// <summary>
        /// Gets Hash Code for current Book instance.
        /// </summary>
        /// <returns> Hash Code</returns>
        public override int GetHashCode()
        {
            int hash = ((((Author.GetHashCode() * 31 + Title.GetHashCode()) * 31 + PublishingHouse.GetHashCode()) * 31 +
                         Year.GetHashCode()) * 31 + Genre.GetHashCode())* 31;
            return hash;
        }

        #endregion
    }
}

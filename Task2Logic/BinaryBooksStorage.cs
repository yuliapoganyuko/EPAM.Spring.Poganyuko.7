using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task2Logic
{
    /// <summary>
    /// Class describing a binary files storage containing Books.
    /// </summary>
    public class BinaryBooksStorage: IFileStorage<Book>
    {
        #region Fields

        private readonly string filePath;

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new BinaryBooksStorage instance.
        /// </summary>
        public BinaryBooksStorage()
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            filePath = Path.Combine(folderPath, "books.bin");
            if (!File.Exists(filePath))
                File.Create(filePath);
        }

        /// <summary>
        /// Initializes a new BinaryBooksStorage instance with the path to the storage (repository).
        /// </summary>
        /// <param name="path"> Path to the storage</param>
        public BinaryBooksStorage(string path)
        {
            if (String.IsNullOrEmpty(path))
                throw new ArgumentNullException();
            filePath = path;
            if (!File.Exists(filePath))
                File.Create(filePath);
        }

        #endregion


        #region Public methods

        /// <summary>
        /// Loads files from the storage.
        /// </summary>
        /// <returns> IEnumerable containing books</returns>
        public IEnumerable<Book> Load()
        {
            List<Book> books = new List<Book>();

            if (!File.Exists(filePath))
                throw new FileNotFoundException();
            Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using (BinaryReader reader = new BinaryReader(stream))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    Book book = new Book();
                    book.Author = reader.ReadString();
                    book.Title = reader.ReadString();
                    book.PublishingHouse = reader.ReadString();
                    book.Year = reader.ReadInt32();
                    book.Genre = reader.ReadString();
                    books.Add(book);
                }
            }
            return books;
        }

        /// <summary>
        /// Saves IEnumerable containing books to storage.
        /// </summary>
        /// <param name="files"> IEnumerable containing books</param>
        public void Save(IEnumerable<Book> books)
        {
            if (ReferenceEquals(books, null))
                throw new ArgumentNullException();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                foreach (Book book in books)
                {
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.PublishingHouse);
                    writer.Write(book.Year);
                    writer.Write(book.Genre);
                }
            }
        }

        #endregion  
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Logic
{
    public class BinaryBooksStorage: IFileStorage<Book>
    {
        private readonly string filePath;

        public BinaryBooksStorage()
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            filePath = Path.Combine(folderPath, "books");
        }

        public BinaryBooksStorage(string path)
        {
            if (String.IsNullOrEmpty(filePath))
                throw new ArgumentNullException();
            filePath = path;
        }

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
    }
}

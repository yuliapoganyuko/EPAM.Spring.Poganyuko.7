using System;
using System.Collections.Generic;
using System.Linq;
using Task2Logic;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryBooksStorage storage = new BinaryBooksStorage();
            BookListService service = new BookListService(storage);

            service.AddBook(new Book("First author", "First book", "First publishing house", 2001, "First genre"));
            service.AddBook(new Book("Second author", "Second book", "Second publishing house", 2002, "Second genre"));
            service.AddBook(new Book("Third author", "Third book", "Third publishing house", 2003, "Third genre"));

            List<Book> books = storage.Load().ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }

            Book foundedBook = service.FindByTag(x => x.Author == "Second author");
            Console.WriteLine(foundedBook.ToString());
            foundedBook = service.FindByTag(x => x.Title == "Third book");
            Console.WriteLine(foundedBook.ToString());
            Console.ReadKey();
        }
    }
}

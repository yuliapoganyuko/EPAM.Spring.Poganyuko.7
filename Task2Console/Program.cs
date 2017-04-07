using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Task2Logic;
using Task2Logic.Comparers;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryBooksStorage storage = new BinaryBooksStorage();
            BookListService service = new BookListService(storage);

            Book bookToRemove = new Book("First author", "First book", "First publishing house", 2001, "First genre");

            service.AddBook(bookToRemove);
            service.AddBook(new Book("Undefined author", "Second book", "Second publishing house", 2002, "Second genre"));
            service.AddBook(new Book("Third author", "Third book", "Third publishing house", 2003, "Third genre"));

            Console.WriteLine("Books in the storage:");
            List<Book> books = storage.Load().ToList();
            foreach (var book in books)
                Console.WriteLine(book.ToString());
            Console.WriteLine();

            Console.WriteLine("Book founded by tag Author == \"First author\":");
            Book foundedBook = service.FindByTag(x => x.Author == "First author");
            Console.WriteLine(foundedBook.ToString());

            Console.WriteLine("Book founded by tag Title == \"Third book\":");
            foundedBook = service.FindByTag(x => x.Title == "Third book");
            Console.WriteLine(foundedBook.ToString() + "\n");

            service.SortBooksByTag(new ComparerByAuthor());
            Console.WriteLine("Sorted by author books in the storage:");
            books = storage.Load().ToList();
            foreach (var book in books)
                Console.WriteLine(book.ToString());
            Console.WriteLine();

            service.RemoveBook(bookToRemove);
            Console.WriteLine("Books in the storage after removing first book:");
            books = storage.Load().ToList();
            foreach (var book in books)
                Console.WriteLine(book.ToString());

            Console.ReadKey();
        }
    }
}

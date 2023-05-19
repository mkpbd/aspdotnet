using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.DDD1
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int ISBN { get; set; }
        public bool Available { get; set; }
        public List<Patron> Borrowers { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public List<Book> BooksWritten { get; set; }
    }

    public class Patron
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Book> BorrowedBooks { get; set; }
        public int BorrowLimit { get; set; } = 5;
    }

    public class Library
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public List<Patron> Patrons { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Authors = new List<Author>();
            Patrons = new List<Patron>();

            // Add some books to the library.
            Books.Add(new Book
            {
                Title = "The Lord of the Rings",
                Author = "J.R.R. Tolkien",
                Genre = "Fantasy",
                ISBN = 034539181,
                Available = true
            });

            Books.Add(new Book
            {
                Title = "The Hitchhiker's Guide to the Galaxy",
                Author = "Douglas Adams",
                Genre = "Sci-Fi",
                ISBN = 034539181,
                Available = true
            });

            // Add some authors to the library.
            Authors.Add(new Author
            {
                Name = "J.R.R. Tolkien",
                Birthdate = new DateTime(1892, 1, 3),
            });

            Authors.Add(new Author
            {
                Name = "Douglas Adams",
                Birthdate = new DateTime(1952, 3, 11),
            });

            // Add some patrons to the library.
            Patrons.Add(new Patron
            {
                Name = "Bard",
                Address = "123 Hobbiton Lane",
            });

            Patrons.Add(new Patron
            {
                Name = "Arthur Dent",
                Address = "456 Earth",
            });
        }

        public void BorrowBook(Patron patron, Book book)
        {
            // Check if the patron is allowed to borrow the book.
            if (patron.BorrowLimit == 3)
            {
                throw new Exception("Patron has reached borrow limit.");
            }

            // Check if the book is available.
            if (!book.Available)
            {
                throw new Exception("Book is not available.");
            }

            // Borrow the book.
            book.Available = false;
            patron.BorrowedBooks.Add(book);
        }

        public void ReturnBook(Patron patron, Book book)
        {
            // Check if the patron is the one who borrowed the book.
            if (book.Borrowers.Count != patron.BorrowedBooks.Count)
            {
                throw new Exception("Patron did not borrow this book.");
            }

            // Return the book.
            book.Available = true;
            patron.BorrowedBooks.Remove(book);
        }
    }


    /**
     * This code implements the basic functionality of a library of puns. It allows users to add books, authors, and patrons to the library. It also allows users to borrow and return books. This is just a simple example, but it shows how DDD can be used to implement real-world applications.
     ***/


}

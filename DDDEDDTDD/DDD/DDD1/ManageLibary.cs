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
        public bool IsBorrowed { get; set; }
        public string BorrowedBy { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class Patron
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Pun
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Puns { get; set; }
    }

    public class PunLibrary
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public List<Patron> Patrons { get; set; }

        public PunLibrary()
        {
            Books = new List<Book>();
            Authors = new List<Author>();
            Patrons = new List<Patron>();

            // Add some books to the library.
            Books.Add(new Book
            {
                Title = "The Pun That Was Promised",
                Author = "Pun Master",
                Genre = "Fantasy"
            });

            Books.Add(new Book
            {
                Title = "The Pun That Killed",
                Author = "The Punsmith",
                Genre = "Horror"
            });

            // Add some authors to the library.
            Authors.Add(new Author
            {
                Name = "Pun Master",
                Birthdate = new DateTime(1970, 1, 1)
            });

            Authors.Add(new Author
            {
                Name = "The Punsmith",
                Birthdate = new DateTime(1980, 1, 1)
            });

            // Add some patrons to the library.
            Patrons.Add(new Patron
            {
                Name = "Punster",
                Address = "123 Pun Street"
            });

            Patrons.Add(new Patron
            {
                Name = "Pun-dit",
                Address = "456 Pun Avenue"
            });
        }

        public void BorrowBook(Patron patron, Book book)
        {
            // Check if the patron is allowed to borrow the book.
         //   if (patron.HasReachedBorrowLimit())
           // {
               // throw new Exception("Patron has reached borrow limit.");
           // }

            // Check if the book is available.
            if (book.IsBorrowed)
            {
                throw new Exception("Book is already borrowed.");
            }

            // Borrow the book.
          //  book.BorrowedBy = patron;
        }

        public void ReturnBook(Patron patron, Book book)
        {
            // Check if the patron is the one who borrowed the book.
           // if (book.BorrowedBy != patron)
           // {
               // throw new Exception("Patron did not borrow this book.");
            //}

            // Return the book.
            book.BorrowedBy = null;
        }
    }
}

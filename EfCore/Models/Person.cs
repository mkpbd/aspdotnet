using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        [InverseProperty("Librarian")]
        public ICollection<LibraryBook>
        LibrarianBooks  { get; set; }
        [InverseProperty("OnLoanTo")]
        public ICollection<LibraryBook>
        BooksBorrowedByMe { get; set; }
    }
}
